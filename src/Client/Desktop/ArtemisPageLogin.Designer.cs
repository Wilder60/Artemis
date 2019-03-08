namespace ArtemisDesktopClient
{
    partial class ArtemisPageLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtemisPageLogin));
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LogInPanel = new System.Windows.Forms.Panel();
            this.TitlePicture = new System.Windows.Forms.PictureBox();
            this.CreatePanelSwitchButton = new System.Windows.Forms.Button();
            this.CreateAccountPanel = new System.Windows.Forms.Panel();
            this.ConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.SwitchToLoginPanel = new System.Windows.Forms.Button();
            this.CreateAccountButton = new System.Windows.Forms.Button();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.CPasswordTextBox = new System.Windows.Forms.TextBox();
            this.CEmailTextBox = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.LogInPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePicture)).BeginInit();
            this.CreateAccountPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.PasswordTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.PasswordTextBox.Location = new System.Drawing.Point(24, 320);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(346, 27);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.Text = "Password";
            this.PasswordTextBox.Click += new System.EventHandler(this.TextBoxClick);
            this.PasswordTextBox.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.UsernameTextbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextbox.ForeColor = System.Drawing.Color.Gray;
            this.UsernameTextbox.Location = new System.Drawing.Point(24, 269);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(346, 27);
            this.UsernameTextbox.TabIndex = 2;
            this.UsernameTextbox.Text = "Email (email@example.com)";
            this.UsernameTextbox.Click += new System.EventHandler(this.TextBoxClick);
            this.UsernameTextbox.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(24, 368);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(346, 69);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.Text = "LogIn";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LogInPanel
            // 
            this.LogInPanel.Controls.Add(this.TitlePicture);
            this.LogInPanel.Controls.Add(this.CreatePanelSwitchButton);
            this.LogInPanel.Controls.Add(this.LoginButton);
            this.LogInPanel.Controls.Add(this.PasswordTextBox);
            this.LogInPanel.Controls.Add(this.UsernameTextbox);
            this.LogInPanel.Location = new System.Drawing.Point(0, 0);
            this.LogInPanel.Name = "LogInPanel";
            this.LogInPanel.Size = new System.Drawing.Size(400, 500);
            this.LogInPanel.TabIndex = 3;
            this.LogInPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseDown);
            this.LogInPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseMove);
            this.LogInPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseUp);
            // 
            // TitlePicture
            // 
            this.TitlePicture.ImageLocation = "C:\\Users\\awild\\Documents\\Programs\\School_Projects\\CMPS450_SeniorProject\\ArtemisIc" +
    "on256x256.png";
            this.TitlePicture.Location = new System.Drawing.Point(71, 5);
            this.TitlePicture.Name = "TitlePicture";
            this.TitlePicture.Size = new System.Drawing.Size(256, 256);
            this.TitlePicture.TabIndex = 5;
            this.TitlePicture.TabStop = false;
            // 
            // CreatePanelSwitchButton
            // 
            this.CreatePanelSwitchButton.Location = new System.Drawing.Point(90, 454);
            this.CreatePanelSwitchButton.Name = "CreatePanelSwitchButton";
            this.CreatePanelSwitchButton.Size = new System.Drawing.Size(224, 24);
            this.CreatePanelSwitchButton.TabIndex = 4;
            this.CreatePanelSwitchButton.Text = "Click Here to Create an Account";
            this.CreatePanelSwitchButton.UseVisualStyleBackColor = true;
            this.CreatePanelSwitchButton.Click += new System.EventHandler(this.CreatePanelSwitchButton_Click);
            // 
            // CreateAccountPanel
            // 
            this.CreateAccountPanel.Controls.Add(this.ConfirmPasswordTextBox);
            this.CreateAccountPanel.Controls.Add(this.SwitchToLoginPanel);
            this.CreateAccountPanel.Controls.Add(this.CreateAccountButton);
            this.CreateAccountPanel.Controls.Add(this.LastNameTextBox);
            this.CreateAccountPanel.Controls.Add(this.FirstNameTextBox);
            this.CreateAccountPanel.Controls.Add(this.CPasswordTextBox);
            this.CreateAccountPanel.Controls.Add(this.CEmailTextBox);
            this.CreateAccountPanel.Controls.Add(this.TitleLabel);
            this.CreateAccountPanel.Location = new System.Drawing.Point(0, 0);
            this.CreateAccountPanel.Name = "CreateAccountPanel";
            this.CreateAccountPanel.Size = new System.Drawing.Size(400, 500);
            this.CreateAccountPanel.TabIndex = 4;
            this.CreateAccountPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseDown);
            this.CreateAccountPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseMove);
            this.CreateAccountPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseUp);
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(65, 270);
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(270, 27);
            this.ConfirmPasswordTextBox.TabIndex = 5;
            this.ConfirmPasswordTextBox.Text = "Re-enter Password";
            this.ConfirmPasswordTextBox.Click += new System.EventHandler(this.TextBoxClick);
            this.ConfirmPasswordTextBox.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // SwitchToLoginPanel
            // 
            this.SwitchToLoginPanel.Location = new System.Drawing.Point(90, 434);
            this.SwitchToLoginPanel.Name = "SwitchToLoginPanel";
            this.SwitchToLoginPanel.Size = new System.Drawing.Size(220, 25);
            this.SwitchToLoginPanel.TabIndex = 7;
            this.SwitchToLoginPanel.Text = "Back to Login Page";
            this.SwitchToLoginPanel.UseVisualStyleBackColor = true;
            this.SwitchToLoginPanel.Click += new System.EventHandler(this.SwitchToLoginPanel_Click);
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.Location = new System.Drawing.Point(90, 358);
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.Size = new System.Drawing.Size(220, 50);
            this.CreateAccountButton.TabIndex = 6;
            this.CreateAccountButton.Text = "Create Account";
            this.CreateAccountButton.UseVisualStyleBackColor = true;
            this.CreateAccountButton.Click += new System.EventHandler(this.CreateAccountButton_Click);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.LastNameTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.LastNameTextBox.Location = new System.Drawing.Point(205, 108);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(130, 27);
            this.LastNameTextBox.TabIndex = 2;
            this.LastNameTextBox.Text = "Last Name";
            this.LastNameTextBox.Click += new System.EventHandler(this.TextBoxClick);
            this.LastNameTextBox.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.FirstNameTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.FirstNameTextBox.Location = new System.Drawing.Point(65, 108);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(130, 27);
            this.FirstNameTextBox.TabIndex = 1;
            this.FirstNameTextBox.Text = "First Name";
            this.FirstNameTextBox.Click += new System.EventHandler(this.TextBoxClick);
            this.FirstNameTextBox.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // CPasswordTextBox
            // 
            this.CPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.CPasswordTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPasswordTextBox.ForeColor = System.Drawing.Color.Gray;
            this.CPasswordTextBox.Location = new System.Drawing.Point(65, 214);
            this.CPasswordTextBox.Name = "CPasswordTextBox";
            this.CPasswordTextBox.Size = new System.Drawing.Size(270, 27);
            this.CPasswordTextBox.TabIndex = 4;
            this.CPasswordTextBox.Text = "Password";
            this.CPasswordTextBox.Click += new System.EventHandler(this.TextBoxClick);
            this.CPasswordTextBox.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // CEmailTextBox
            // 
            this.CEmailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.CEmailTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CEmailTextBox.ForeColor = System.Drawing.Color.Gray;
            this.CEmailTextBox.Location = new System.Drawing.Point(65, 159);
            this.CEmailTextBox.Name = "CEmailTextBox";
            this.CEmailTextBox.Size = new System.Drawing.Size(270, 27);
            this.CEmailTextBox.TabIndex = 3;
            this.CEmailTextBox.Text = "Email (email@example.com)";
            this.CEmailTextBox.Click += new System.EventHandler(this.TextBoxClick);
            this.CEmailTextBox.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(129)))));
            this.TitleLabel.Location = new System.Drawing.Point(64, 45);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(271, 27);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Create an Account, it\'s Free!";
            // 
            // ArtemisPageLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.CreateAccountPanel);
            this.Controls.Add(this.LogInPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ArtemisPageLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artemis";
            this.Load += new System.EventHandler(this.ArtemisDesktop_Load);
            this.LogInPanel.ResumeLayout(false);
            this.LogInPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePicture)).EndInit();
            this.CreateAccountPanel.ResumeLayout(false);
            this.CreateAccountPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Panel LogInPanel;
        private System.Windows.Forms.Button CreatePanelSwitchButton;
        private System.Windows.Forms.Panel CreateAccountPanel;
        private System.Windows.Forms.TextBox CEmailTextBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button SwitchToLoginPanel;
        private System.Windows.Forms.Button CreateAccountButton;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox CPasswordTextBox;
        private System.Windows.Forms.TextBox ConfirmPasswordTextBox;
        private System.Windows.Forms.PictureBox TitlePicture;
    }
}

