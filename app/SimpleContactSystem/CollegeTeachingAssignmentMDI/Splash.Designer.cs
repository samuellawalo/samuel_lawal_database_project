namespace SimpleContactSystem
{
    partial class Splash
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
            btnClose = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnClose.Location = new Point(782, 17);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(53, 46);
            btnClose.TabIndex = 5;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 3000;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(292, 418);
            label1.Name = "label1";
            label1.Size = new Size(241, 32);
            label1.TabIndex = 1;
            label1.Text = "Samuel Lawal WMAD";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 18F);
            label2.Location = new Point(169, 127);
            label2.Name = "label2";
            label2.Size = new Size(512, 65);
            label2.TabIndex = 6;
            label2.Text = "Simple Contact System";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(378, 201);
            label3.Name = "label3";
            label3.Size = new Size(82, 32);
            label3.TabIndex = 7;
            label3.Text = "v 0.0.1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(353, 299);
            label4.Name = "label4";
            label4.Size = new Size(121, 32);
            label4.TabIndex = 8;
            label4.Text = "Loading ...";
            // 
            // Splash
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(856, 471);
            ControlBox = false;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnClose);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Splash";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Splash";
            Load += Splash_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClose;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}