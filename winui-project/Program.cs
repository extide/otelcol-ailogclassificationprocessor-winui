using System.Diagnostics;

namespace winui_project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            string filePath;

            if (args.Length <= 0)
            {
                filePath = showOpenFileDialog();
            }
            else
            {
                filePath = args[0];
            }

            if (!string.IsNullOrEmpty(filePath))
            {
                Application.Run(new logClassificationForm(filePath));
            }
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine(e.ToString());
            MessageBox.Show(string.Format("Oh No! Fatal Error!{0}{1}", Environment.NewLine, e.ToString()));
        }

        static string showOpenFileDialog()
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string previousPath = getPreviousFilePath();

                if (!string.IsNullOrEmpty(previousPath))
                {
                    openFileDialog.InitialDirectory = previousPath;
                }
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    setPreviousPath(Path.GetDirectoryName(openFileDialog.FileName));
                }
            }

            return filePath;

        }

        static string getPreviousFilePath()
        {
            try
            {
                return logClassificationSettings.Default.previousFilePath;
            }
            catch
            {
                //just toss it here because it probably means our settings are blank or corrupt
                return string.Empty;
            }
        }
        static void setPreviousPath(string previousPath)
        {
            if (string.IsNullOrEmpty(previousPath)) { return; }

            try
            {
                logClassificationSettings.Default.previousFilePath = previousPath;
                logClassificationSettings.Default.Save();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return;
            }
        }
    }
}