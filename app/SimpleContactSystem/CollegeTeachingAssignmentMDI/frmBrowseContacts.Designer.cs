namespace SimpleContactSystem
{
    partial class frmBrowseContacts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbGroups = new ComboBox();
            btnBrowseContacts = new Button();
            dgvContacts = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            SuspendLayout();
            // 
            // cmbGroups
            // 
            cmbGroups.FormattingEnabled = true;
            cmbGroups.Location = new Point(46, 44);
            cmbGroups.Name = "cmbGroups";
            cmbGroups.Size = new Size(334, 40);
            cmbGroups.TabIndex = 0;
            // 
            // btnBrowseContacts
            // 
            btnBrowseContacts.Location = new Point(471, 38);
            btnBrowseContacts.Name = "btnBrowseContacts";
            btnBrowseContacts.Size = new Size(214, 46);
            btnBrowseContacts.TabIndex = 1;
            btnBrowseContacts.Text = "Display Contacts";
            btnBrowseContacts.UseVisualStyleBackColor = true;
            btnBrowseContacts.Click += btnBrowseContact_Click;
            // 
            // dgvContacts
            // 
            dgvContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContacts.Location = new Point(28, 115);
            dgvContacts.Name = "dgvContacts";
            dgvContacts.RowHeadersWidth = 82;
            dgvContacts.Size = new Size(1322, 495);
            dgvContacts.TabIndex = 2;
            // 
            // frmBrowseContacts
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1407, 693);
            Controls.Add(dgvContacts);
            Controls.Add(btnBrowseContacts);
            Controls.Add(cmbGroups);
            Name = "frmBrowseContacts";
            Tag = "browseContacts";
            Text = "frmBrowseContacts";
            Load += frmBrowseContacts_Load;
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbGroups;
        private Button btnBrowseContacts;
        private DataGridView dgvContacts;
    }
}