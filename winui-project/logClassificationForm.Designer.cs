namespace winui_project
{
    partial class logClassificationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            logLineContextMenu = new ContextMenuStrip(components);
            logFileDataGrid = new DataGridView();
            logLineColumn = new DataGridViewTextBoxColumn();
            logClassColumn = new DataGridViewTextBoxColumn();
            mainTableLayoutPanel = new TableLayoutPanel();
            lowerTableLayoutPanel = new TableLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            btnHelp = new Button();
            ((System.ComponentModel.ISupportInitialize)logFileDataGrid).BeginInit();
            mainTableLayoutPanel.SuspendLayout();
            lowerTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // logLineContextMenu
            // 
            logLineContextMenu.Name = "logLineContextMenu";
            logLineContextMenu.Size = new Size(61, 4);
            // 
            // logFileDataGrid
            // 
            logFileDataGrid.AllowUserToAddRows = false;
            logFileDataGrid.AllowUserToDeleteRows = false;
            logFileDataGrid.AllowUserToResizeColumns = false;
            logFileDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            logFileDataGrid.Columns.AddRange(new DataGridViewColumn[] { logLineColumn, logClassColumn });
            logFileDataGrid.Dock = DockStyle.Fill;
            logFileDataGrid.Location = new Point(3, 3);
            logFileDataGrid.Name = "logFileDataGrid";
            logFileDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            logFileDataGrid.Size = new Size(1142, 836);
            logFileDataGrid.TabIndex = 0;
            // 
            // logLineColumn
            // 
            logLineColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            logLineColumn.ContextMenuStrip = logLineContextMenu;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            logLineColumn.DefaultCellStyle = dataGridViewCellStyle1;
            logLineColumn.HeaderText = "Log Line Text";
            logLineColumn.Name = "logLineColumn";
            logLineColumn.ReadOnly = true;
            // 
            // logClassColumn
            // 
            logClassColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            logClassColumn.ContextMenuStrip = logLineContextMenu;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            logClassColumn.DefaultCellStyle = dataGridViewCellStyle2;
            logClassColumn.HeaderText = "Weight";
            logClassColumn.Name = "logClassColumn";
            logClassColumn.Resizable = DataGridViewTriState.False;
            logClassColumn.Width = 70;
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.AutoSize = true;
            mainTableLayoutPanel.ColumnCount = 1;
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTableLayoutPanel.Controls.Add(logFileDataGrid, 0, 0);
            mainTableLayoutPanel.Controls.Add(lowerTableLayoutPanel, 0, 1);
            mainTableLayoutPanel.Dock = DockStyle.Fill;
            mainTableLayoutPanel.Location = new Point(0, 0);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 2;
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainTableLayoutPanel.Size = new Size(1148, 882);
            mainTableLayoutPanel.TabIndex = 0;
            // 
            // lowerTableLayoutPanel
            // 
            lowerTableLayoutPanel.AutoSize = true;
            lowerTableLayoutPanel.ColumnCount = 3;
            lowerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            lowerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            lowerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
            lowerTableLayoutPanel.Controls.Add(btnSave, 2, 0);
            lowerTableLayoutPanel.Controls.Add(btnCancel, 1, 0);
            lowerTableLayoutPanel.Controls.Add(btnHelp, 0, 0);
            lowerTableLayoutPanel.Dock = DockStyle.Fill;
            lowerTableLayoutPanel.Location = new Point(3, 845);
            lowerTableLayoutPanel.Name = "lowerTableLayoutPanel";
            lowerTableLayoutPanel.RowCount = 1;
            lowerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            lowerTableLayoutPanel.Size = new Size(1142, 34);
            lowerTableLayoutPanel.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(1047, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(92, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Label File";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(967, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(74, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(3, 3);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(75, 23);
            btnHelp.TabIndex = 2;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = true;
            // 
            // logClassificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 882);
            Controls.Add(mainTableLayoutPanel);
            Name = "logClassificationForm";
            Text = "Log Line Classification";
            ((System.ComponentModel.ISupportInitialize)logFileDataGrid).EndInit();
            mainTableLayoutPanel.ResumeLayout(false);
            mainTableLayoutPanel.PerformLayout();
            lowerTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip logLineContextMenu;
        private DataGridView logFileDataGrid;
        private DataGridViewTextBoxColumn logLineColumn;
        private DataGridViewTextBoxColumn logClassColumn;
        private TableLayoutPanel mainTableLayoutPanel;
        private TableLayoutPanel lowerTableLayoutPanel;
        private Button btnSave;
        private Button btnCancel;
        private Button btnHelp;
    }
}
