using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TiktokenSharp;

namespace winui_project
{
    public partial class logClassificationForm : Form
    {
        private delegate void ToolStripMenuItemEventHandler(int weight);
        private event ToolStripMenuItemEventHandler ToolStripMenuItemClicked;
        private string logFileName;
        private string origTitle;

        public logClassificationForm(string filePath)
        {
            InitializeComponent();

            origTitle = string.Format("Log Line Classification v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.Text = origTitle;

            logFileName = filePath;

            setupContextMenu();
            readLogFile(filePath);
            this.Activate();
        }

        #region Methods
        private void setupContextMenu()
        {
            for (int i = 1; i <= 10; i++)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Text = string.Format("Set weight to {0}", i);
                toolStripMenuItem.Tag = i;
                toolStripMenuItem.Click += toolStripMenuItem_Click;
                logLineContextMenu.Items.Add(toolStripMenuItem);
            }
        }

        void readLogFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    addRowToLogFileDataGrid(reader.ReadLine());
                }
            }
        }

        void addRowToLogFileDataGrid(string logLineText)
        {
            string[] row = { logLineText, "1" };
            logFileDataGrid.Rows.Add(row);
        }

        private void saveLabelFile()
        {
            var fileName = Path.GetFileNameWithoutExtension(logFileName);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.RestoreDirectory = true;
                string previousSavePath = getPreviousSavePath();

                if (!string.IsNullOrEmpty(previousSavePath))
                {
                    saveFileDialog.FileName = string.Format("{0}\\{1}.csv", previousSavePath, fileName);
                }
                else
                {
                    saveFileDialog.FileName = string.Format("{0}.csv", fileName);
                }

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    setPreviousSavePath(Path.GetDirectoryName(saveFileDialog.FileName));
                    this.Text = string.Format("{0} SAVING, PLEASE WAIT!!!!", origTitle);
                    Application.DoEvents();
                    writeLabelFileLines(saveFileDialog.FileName);
                    this.Close();
                }
            }
        }

        private void writeLabelFileLines(string fileName)
        {
            TikToken tikToken = TikToken.GetEncoding("cl100k_base");
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                foreach (DataGridViewRow row in logFileDataGrid.Rows)
                {
                    string logLineText = (string)row.Cells[0].Value;
                    List<string> tensorList = tikToken.Encode(logLineText).Select(bpe => bpe.ToString()).ToList<string>();
                    string tensorString = string.Format("[{0}]", string.Join(", ", tensorList));

                    streamWriter.WriteLine(string.Format("{0}, {1}", tensorString, row.Cells[1].Value));
                }
            }
        }

        private string getPreviousSavePath()
        {
            try
            {
                return logClassificationSettings.Default.previousSavePath;
            }
            catch
            {
                //just toss it here because it probably means our settings are blank or corrupt
                return string.Empty;
            }
        }
        static void setPreviousSavePath(string previousSavePath)
        {
            if (string.IsNullOrEmpty(previousSavePath)) { return; }

            try
            {
                logClassificationSettings.Default.previousSavePath = previousSavePath;
                logClassificationSettings.Default.Save();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return;
            }
        }
        #endregion

        #region Event Handlers
        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;

            foreach (DataGridViewRow row in logFileDataGrid.SelectedRows)
            {
                row.Cells[1].Value = toolStripMenuItem.Tag;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveLabelFile();
        }
        #endregion

    }
}
