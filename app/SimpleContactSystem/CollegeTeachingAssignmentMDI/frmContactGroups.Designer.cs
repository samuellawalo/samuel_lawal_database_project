namespace SimpleContactSystem
{
    partial class frmContactGroups
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
            grpCourses = new GroupBox();
            txtMaxContacts = new TextBox();
            txtGroupId = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            btnLast = new Button();
            btnAdd = new Button();
            label4 = new Label();
            btnDelete = new Button();
            btnFirst = new Button();
            btnSave = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            txtDescription = new TextBox();
            label3 = new Label();
            txtGroupName = new TextBox();
            label2 = new Label();
            grpCourses.SuspendLayout();
            SuspendLayout();
            // 
            // grpCourses
            // 
            grpCourses.Controls.Add(txtMaxContacts);
            grpCourses.Controls.Add(txtGroupId);
            grpCourses.Controls.Add(label1);
            grpCourses.Controls.Add(btnCancel);
            grpCourses.Controls.Add(btnLast);
            grpCourses.Controls.Add(btnAdd);
            grpCourses.Controls.Add(label4);
            grpCourses.Controls.Add(btnDelete);
            grpCourses.Controls.Add(btnFirst);
            grpCourses.Controls.Add(btnSave);
            grpCourses.Controls.Add(btnPrevious);
            grpCourses.Controls.Add(btnNext);
            grpCourses.Controls.Add(txtDescription);
            grpCourses.Controls.Add(label3);
            grpCourses.Controls.Add(txtGroupName);
            grpCourses.Controls.Add(label2);
            grpCourses.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCourses.Location = new Point(138, 109);
            grpCourses.Margin = new Padding(6, 7, 6, 7);
            grpCourses.Name = "grpCourses";
            grpCourses.Padding = new Padding(6, 7, 6, 7);
            grpCourses.Size = new Size(931, 818);
            grpCourses.TabIndex = 10;
            grpCourses.TabStop = false;
            grpCourses.Text = "Group Details";
            // 
            // txtMaxContacts
            // 
            txtMaxContacts.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaxContacts.Location = new Point(110, 424);
            txtMaxContacts.Margin = new Padding(6, 7, 6, 7);
            txtMaxContacts.Name = "txtMaxContacts";
            txtMaxContacts.Size = new Size(724, 32);
            txtMaxContacts.TabIndex = 30;
            txtMaxContacts.Tag = "";
            // 
            // txtGroupId
            // 
            txtGroupId.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGroupId.Location = new Point(106, 101);
            txtGroupId.Margin = new Padding(6, 7, 6, 7);
            txtGroupId.Name = "txtGroupId";
            txtGroupId.ReadOnly = true;
            txtGroupId.Size = new Size(724, 32);
            txtGroupId.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 55);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(48, 31);
            label1.TabIndex = 27;
            label1.Text = "Id:";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(668, 632);
            btnCancel.Margin = new Padding(6, 7, 6, 7);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(176, 115);
            btnCancel.TabIndex = 26;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(667, 512);
            btnLast.Margin = new Padding(6, 7, 6, 7);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(176, 107);
            btnLast.TabIndex = 22;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(102, 633);
            btnAdd.Margin = new Padding(6, 7, 6, 7);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(176, 115);
            btnAdd.TabIndex = 23;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 374);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(201, 31);
            label4.TabIndex = 4;
            label4.Text = "Max Contacts:";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(290, 633);
            btnDelete.Margin = new Padding(6, 7, 6, 7);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(176, 115);
            btnDelete.TabIndex = 24;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(102, 512);
            btnFirst.Margin = new Padding(6, 7, 6, 7);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(176, 107);
            btnFirst.TabIndex = 21;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(479, 633);
            btnSave.Margin = new Padding(6, 7, 6, 7);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(176, 115);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(290, 512);
            btnPrevious.Margin = new Padding(6, 7, 6, 7);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(176, 107);
            btnPrevious.TabIndex = 20;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(479, 512);
            btnNext.Margin = new Padding(6, 7, 6, 7);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(176, 107);
            btnNext.TabIndex = 19;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(106, 313);
            txtDescription.Margin = new Padding(6, 7, 6, 7);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(724, 32);
            txtDescription.TabIndex = 3;
            txtDescription.Tag = "Credits";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 267);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(162, 31);
            label3.TabIndex = 2;
            label3.Text = "Description";
            // 
            // txtGroupName
            // 
            txtGroupName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGroupName.Location = new Point(106, 206);
            txtGroupName.Margin = new Padding(6, 7, 6, 7);
            txtGroupName.Name = "txtGroupName";
            txtGroupName.Size = new Size(724, 32);
            txtGroupName.TabIndex = 1;
            txtGroupName.Tag = "Contact Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 162);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(187, 31);
            label2.TabIndex = 0;
            label2.Text = "Group Name:";
            // 
            // frmContactGroups
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 1241);
            Controls.Add(grpCourses);
            Name = "frmContactGroups";
            Text = "frmContactGroups";
            Load += frmContactGroups_Load;
            grpCourses.ResumeLayout(false);
            grpCourses.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpCourses;
        private TextBox txtMaxContacts;
        private TextBox txtGroupId;
        private Label label1;
        private Button btnCancel;
        private Button btnLast;
        private Button btnAdd;
        private Label label4;
        private Button btnDelete;
        private Button btnFirst;
        private Button btnSave;
        private Button btnPrevious;
        private Button btnNext;
        private TextBox txtDescription;
        private Label label3;
        private TextBox txtGroupName;
        private Label label2;
    }
}