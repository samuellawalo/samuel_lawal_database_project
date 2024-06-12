namespace SimpleContactSystem
{
    partial class frmContactDetails
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
            components = new System.ComponentModel.Container();
            grpCourses = new GroupBox();
            clbGroups = new CheckedListBox();
            txtDescription = new TextBox();
            label6 = new Label();
            txtAddress = new TextBox();
            label5 = new Label();
            txtContactId = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            btnLast = new Button();
            btnAdd = new Button();
            txtEmail = new TextBox();
            label4 = new Label();
            btnDelete = new Button();
            btnFirst = new Button();
            btnSave = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            txtPhoneNumber = new TextBox();
            label3 = new Label();
            txtContactName = new TextBox();
            label2 = new Label();
            errorProvider = new ErrorProvider(components);
            label7 = new Label();
            grpCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // grpCourses
            // 
            grpCourses.Controls.Add(label7);
            grpCourses.Controls.Add(clbGroups);
            grpCourses.Controls.Add(txtDescription);
            grpCourses.Controls.Add(label6);
            grpCourses.Controls.Add(txtAddress);
            grpCourses.Controls.Add(label5);
            grpCourses.Controls.Add(txtContactId);
            grpCourses.Controls.Add(label1);
            grpCourses.Controls.Add(btnCancel);
            grpCourses.Controls.Add(btnLast);
            grpCourses.Controls.Add(btnAdd);
            grpCourses.Controls.Add(txtEmail);
            grpCourses.Controls.Add(label4);
            grpCourses.Controls.Add(btnDelete);
            grpCourses.Controls.Add(btnFirst);
            grpCourses.Controls.Add(btnSave);
            grpCourses.Controls.Add(btnPrevious);
            grpCourses.Controls.Add(btnNext);
            grpCourses.Controls.Add(txtPhoneNumber);
            grpCourses.Controls.Add(label3);
            grpCourses.Controls.Add(txtContactName);
            grpCourses.Controls.Add(label2);
            grpCourses.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCourses.Location = new Point(58, 47);
            grpCourses.Margin = new Padding(6, 7, 6, 7);
            grpCourses.Name = "grpCourses";
            grpCourses.Padding = new Padding(6, 7, 6, 7);
            grpCourses.Size = new Size(1297, 1022);
            grpCourses.TabIndex = 9;
            grpCourses.TabStop = false;
            grpCourses.Text = "Contact Details";
            // 
            // clbGroups
            // 
            clbGroups.FormattingEnabled = true;
            clbGroups.Location = new Point(948, 177);
            clbGroups.Name = "clbGroups";
            clbGroups.Size = new Size(304, 179);
            clbGroups.TabIndex = 33;
            clbGroups.SelectedIndexChanged += clbGroups_SelectedIndexChanged;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(109, 427);
            txtDescription.Margin = new Padding(6, 7, 6, 7);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(724, 32);
            txtDescription.TabIndex = 32;
            txtDescription.Tag = "Hours";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(102, 379);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(171, 31);
            label6.TabIndex = 31;
            label6.Text = "Description:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(110, 647);
            txtAddress.Margin = new Padding(6, 7, 6, 7);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(724, 32);
            txtAddress.TabIndex = 30;
            txtAddress.Tag = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(103, 599);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(130, 31);
            label5.TabIndex = 29;
            label5.Text = "Address:";
            // 
            // txtContactId
            // 
            txtContactId.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContactId.Location = new Point(106, 101);
            txtContactId.Margin = new Padding(6, 7, 6, 7);
            txtContactId.Name = "txtContactId";
            txtContactId.ReadOnly = true;
            txtContactId.Size = new Size(724, 32);
            txtContactId.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 51);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(48, 31);
            label1.TabIndex = 27;
            label1.Text = "Id:";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(658, 872);
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
            btnLast.Location = new Point(657, 752);
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
            btnAdd.Location = new Point(92, 873);
            btnAdd.Margin = new Padding(6, 7, 6, 7);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(176, 115);
            btnAdd.TabIndex = 23;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(109, 546);
            txtEmail.Margin = new Padding(6, 7, 6, 7);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(724, 32);
            txtEmail.TabIndex = 5;
            txtEmail.Tag = "Hours";
            txtEmail.Validating += txt_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 498);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(95, 31);
            label4.TabIndex = 4;
            label4.Text = "Email:";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(280, 873);
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
            btnFirst.Location = new Point(92, 752);
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
            btnSave.Location = new Point(469, 873);
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
            btnPrevious.Location = new Point(280, 752);
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
            btnNext.Location = new Point(469, 752);
            btnNext.Margin = new Padding(6, 7, 6, 7);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(176, 107);
            btnNext.TabIndex = 19;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNumber.Location = new Point(106, 313);
            txtPhoneNumber.Margin = new Padding(6, 7, 6, 7);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(724, 32);
            txtPhoneNumber.TabIndex = 3;
            txtPhoneNumber.Tag = "Credits";
            txtPhoneNumber.Validating += txt_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 263);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(213, 31);
            label3.TabIndex = 2;
            label3.Text = "Mobile number:";
            // 
            // txtContactName
            // 
            txtContactName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContactName.Location = new Point(106, 206);
            txtContactName.Margin = new Padding(6, 7, 6, 7);
            txtContactName.Name = "txtContactName";
            txtContactName.Size = new Size(724, 32);
            txtContactName.TabIndex = 1;
            txtContactName.Tag = "Contact Name";
            txtContactName.Validating += txt_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 158);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(209, 31);
            label2.TabIndex = 0;
            label2.Text = "Contact Name:";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(950, 118);
            label7.Name = "label7";
            label7.Size = new Size(204, 31);
            label7.TabIndex = 34;
            label7.Text = "Contact Group";
            // 
            // frmContactDetails
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1413, 1087);
            Controls.Add(grpCourses);
            Margin = new Padding(6, 7, 6, 7);
            Name = "frmContactDetails";
            Tag = "contactdetails";
            Text = "frmContactDetails";
            Load += frmCourses_Load;
            grpCourses.ResumeLayout(false);
            grpCourses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpCourses;
        private System.Windows.Forms.TextBox txtContactId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private TextBox txtAddress;
        private Label label5;
        private TextBox txtDescription;
        private Label label6;
        private CheckedListBox clbGroups;
        private Label label7;
    }
}
