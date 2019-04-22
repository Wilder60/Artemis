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
            this.TextBoxLoginPassword = new System.Windows.Forms.TextBox();
            this.TextBoxLoginEmail = new System.Windows.Forms.TextBox();
            this.PanelLogin = new System.Windows.Forms.Panel();
            this.LabelLoginError = new System.Windows.Forms.Label();
            this.TitlePicture = new System.Windows.Forms.PictureBox();
            this.ButtonSwitchToCreatePanel = new System.Windows.Forms.Button();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.PanelCreateAccount = new System.Windows.Forms.Panel();
            this.LabelConfirmPassword = new System.Windows.Forms.Label();
            this.LabelPasswordRequirements = new System.Windows.Forms.Label();
            this.TextBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.PanelSwitchToLogin = new System.Windows.Forms.Button();
            this.ButtonCreateAccount = new System.Windows.Forms.Button();
            this.TextBoxLastName = new System.Windows.Forms.TextBox();
            this.TextBoxFirstName = new System.Windows.Forms.TextBox();
            this.TextBoxCreatePassword = new System.Windows.Forms.TextBox();
            this.TextBoxNewEmail = new System.Windows.Forms.TextBox();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.PanelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePicture)).BeginInit();
            this.PanelCreateAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxLoginPassword
            // 
            this.TextBoxLoginPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TextBoxLoginPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxLoginPassword.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxLoginPassword.Location = new System.Drawing.Point(25, 350);
            this.TextBoxLoginPassword.Name = "TextBoxLoginPassword";
            this.TextBoxLoginPassword.Size = new System.Drawing.Size(350, 27);
            this.TextBoxLoginPassword.TabIndex = 3;
            this.TextBoxLoginPassword.Text = "Password";
            this.TextBoxLoginPassword.Click += new System.EventHandler(this.TextBoxClick);
            this.TextBoxLoginPassword.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // TextBoxLoginEmail
            // 
            this.TextBoxLoginEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TextBoxLoginEmail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxLoginEmail.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxLoginEmail.Location = new System.Drawing.Point(25, 300);
            this.TextBoxLoginEmail.Name = "TextBoxLoginEmail";
            this.TextBoxLoginEmail.Size = new System.Drawing.Size(350, 27);
            this.TextBoxLoginEmail.TabIndex = 2;
            this.TextBoxLoginEmail.Text = "Email (email@example.com)";
            this.TextBoxLoginEmail.Click += new System.EventHandler(this.TextBoxClick);
            this.TextBoxLoginEmail.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // PanelLogin
            // 
            this.PanelLogin.Controls.Add(this.LabelLoginError);
            this.PanelLogin.Controls.Add(this.TitlePicture);
            this.PanelLogin.Controls.Add(this.ButtonSwitchToCreatePanel);
            this.PanelLogin.Controls.Add(this.ButtonLogin);
            this.PanelLogin.Controls.Add(this.TextBoxLoginPassword);
            this.PanelLogin.Controls.Add(this.TextBoxLoginEmail);
            this.PanelLogin.Location = new System.Drawing.Point(0, 0);
            this.PanelLogin.Name = "PanelLogin";
            this.PanelLogin.Size = new System.Drawing.Size(400, 600);
            this.PanelLogin.TabIndex = 3;
            this.PanelLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseDown);
            this.PanelLogin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseMove);
            this.PanelLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseUp);
            // 
            // LabelLoginError
            // 
            this.LabelLoginError.ForeColor = System.Drawing.Color.Red;
            this.LabelLoginError.Location = new System.Drawing.Point(25, 540);
            this.LabelLoginError.MaximumSize = new System.Drawing.Size(350, 0);
            this.LabelLoginError.Name = "LabelLoginError";
            this.LabelLoginError.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelLoginError.Size = new System.Drawing.Size(350, 13);
            this.LabelLoginError.TabIndex = 6;
            this.LabelLoginError.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TitlePicture
            // 
            this.TitlePicture.ImageLocation = "C:\\Users\\awild\\Documents\\Programs\\School_Projects\\CMPS450_SeniorProject\\Icons\\New" +
    "Icon\\ArtemisBlue256x256.png";
            this.TitlePicture.Location = new System.Drawing.Point(72, 25);
            this.TitlePicture.Name = "TitlePicture";
            this.TitlePicture.Size = new System.Drawing.Size(256, 256);
            this.TitlePicture.TabIndex = 5;
            this.TitlePicture.TabStop = false;
            // 
            // ButtonSwitchToCreatePanel
            // 
            this.ButtonSwitchToCreatePanel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ButtonSwitchToCreatePanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ButtonSwitchToCreatePanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ButtonSwitchToCreatePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSwitchToCreatePanel.Image = global::ArtemisDesktopClient.Properties.Resources.SwitchToCreatePanelButton;
            this.ButtonSwitchToCreatePanel.Location = new System.Drawing.Point(75, 490);
            this.ButtonSwitchToCreatePanel.Name = "ButtonSwitchToCreatePanel";
            this.ButtonSwitchToCreatePanel.Size = new System.Drawing.Size(250, 25);
            this.ButtonSwitchToCreatePanel.TabIndex = 4;
            this.ButtonSwitchToCreatePanel.UseVisualStyleBackColor = true;
            this.ButtonSwitchToCreatePanel.Click += new System.EventHandler(this.CreatePanelSwitchButton_Click);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ButtonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Image = global::ArtemisDesktopClient.Properties.Resources.LogInButton;
            this.ButtonLogin.Location = new System.Drawing.Point(25, 400);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(350, 70);
            this.ButtonLogin.TabIndex = 1;
            this.ButtonLogin.UseVisualStyleBackColor = true;
            this.ButtonLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonDownClick);
            this.ButtonLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonRelease);
            // 
            // PanelCreateAccount
            // 
            this.PanelCreateAccount.Controls.Add(this.LabelConfirmPassword);
            this.PanelCreateAccount.Controls.Add(this.LabelPasswordRequirements);
            this.PanelCreateAccount.Controls.Add(this.TextBoxConfirmPassword);
            this.PanelCreateAccount.Controls.Add(this.PanelSwitchToLogin);
            this.PanelCreateAccount.Controls.Add(this.ButtonCreateAccount);
            this.PanelCreateAccount.Controls.Add(this.TextBoxLastName);
            this.PanelCreateAccount.Controls.Add(this.TextBoxFirstName);
            this.PanelCreateAccount.Controls.Add(this.TextBoxCreatePassword);
            this.PanelCreateAccount.Controls.Add(this.TextBoxNewEmail);
            this.PanelCreateAccount.Controls.Add(this.LabelTitle);
            this.PanelCreateAccount.Location = new System.Drawing.Point(0, 0);
            this.PanelCreateAccount.Name = "PanelCreateAccount";
            this.PanelCreateAccount.Size = new System.Drawing.Size(400, 600);
            this.PanelCreateAccount.TabIndex = 4;
            this.PanelCreateAccount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseDown);
            this.PanelCreateAccount.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseMove);
            this.PanelCreateAccount.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseUp);
            // 
            // LabelConfirmPassword
            // 
            this.LabelConfirmPassword.AutoSize = true;
            this.LabelConfirmPassword.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.LabelConfirmPassword.Location = new System.Drawing.Point(70, 385);
            this.LabelConfirmPassword.Name = "LabelConfirmPassword";
            this.LabelConfirmPassword.Size = new System.Drawing.Size(131, 15);
            this.LabelConfirmPassword.TabIndex = 9;
            this.LabelConfirmPassword.Text = "Must match box above";
            // 
            // LabelPasswordRequirements
            // 
            this.LabelPasswordRequirements.AutoSize = true;
            this.LabelPasswordRequirements.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPasswordRequirements.ForeColor = System.Drawing.Color.White;
            this.LabelPasswordRequirements.Location = new System.Drawing.Point(70, 260);
            this.LabelPasswordRequirements.Name = "LabelPasswordRequirements";
            this.LabelPasswordRequirements.Size = new System.Drawing.Size(180, 75);
            this.LabelPasswordRequirements.TabIndex = 8;
            this.LabelPasswordRequirements.Text = "Password must contain atleast:\r\n8 - 32 Characters\r\n1 Uppercase Character\r\n1 Lower" +
    "Case Character\r\n1 Special Character";
            // 
            // TextBoxConfirmPassword
            // 
            this.TextBoxConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TextBoxConfirmPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxConfirmPassword.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxConfirmPassword.Location = new System.Drawing.Point(65, 350);
            this.TextBoxConfirmPassword.Name = "TextBoxConfirmPassword";
            this.TextBoxConfirmPassword.Size = new System.Drawing.Size(270, 27);
            this.TextBoxConfirmPassword.TabIndex = 5;
            this.TextBoxConfirmPassword.Text = "Re-enter Password";
            this.TextBoxConfirmPassword.Click += new System.EventHandler(this.TextBoxClick);
            this.TextBoxConfirmPassword.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.TextBoxConfirmPassword.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // PanelSwitchToLogin
            // 
            this.PanelSwitchToLogin.Location = new System.Drawing.Point(90, 500);
            this.PanelSwitchToLogin.Name = "PanelSwitchToLogin";
            this.PanelSwitchToLogin.Size = new System.Drawing.Size(220, 25);
            this.PanelSwitchToLogin.TabIndex = 7;
            this.PanelSwitchToLogin.Text = "Back to Login Page";
            this.PanelSwitchToLogin.UseVisualStyleBackColor = true;
            this.PanelSwitchToLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonDownClick);
            this.PanelSwitchToLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonRelease);
            // 
            // ButtonCreateAccount
            // 
            this.ButtonCreateAccount.Location = new System.Drawing.Point(75, 420);
            this.ButtonCreateAccount.Name = "ButtonCreateAccount";
            this.ButtonCreateAccount.Size = new System.Drawing.Size(250, 50);
            this.ButtonCreateAccount.TabIndex = 6;
            this.ButtonCreateAccount.Text = "Create Account";
            this.ButtonCreateAccount.UseVisualStyleBackColor = true;
            this.ButtonCreateAccount.Click += new System.EventHandler(this.CreateAccountButton_Click);
            // 
            // TextBoxLastName
            // 
            this.TextBoxLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TextBoxLastName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxLastName.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxLastName.Location = new System.Drawing.Point(205, 115);
            this.TextBoxLastName.Name = "TextBoxLastName";
            this.TextBoxLastName.Size = new System.Drawing.Size(130, 27);
            this.TextBoxLastName.TabIndex = 2;
            this.TextBoxLastName.Text = "Last Name";
            this.TextBoxLastName.Click += new System.EventHandler(this.TextBoxClick);
            this.TextBoxLastName.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // TextBoxFirstName
            // 
            this.TextBoxFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TextBoxFirstName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxFirstName.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxFirstName.Location = new System.Drawing.Point(65, 115);
            this.TextBoxFirstName.Name = "TextBoxFirstName";
            this.TextBoxFirstName.Size = new System.Drawing.Size(130, 27);
            this.TextBoxFirstName.TabIndex = 1;
            this.TextBoxFirstName.Text = "First Name";
            this.TextBoxFirstName.Click += new System.EventHandler(this.TextBoxClick);
            this.TextBoxFirstName.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // TextBoxCreatePassword
            // 
            this.TextBoxCreatePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TextBoxCreatePassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCreatePassword.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxCreatePassword.Location = new System.Drawing.Point(65, 230);
            this.TextBoxCreatePassword.Name = "TextBoxCreatePassword";
            this.TextBoxCreatePassword.Size = new System.Drawing.Size(270, 27);
            this.TextBoxCreatePassword.TabIndex = 4;
            this.TextBoxCreatePassword.Text = "Password";
            this.TextBoxCreatePassword.Click += new System.EventHandler(this.TextBoxClick);
            this.TextBoxCreatePassword.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.TextBoxCreatePassword.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // TextBoxNewEmail
            // 
            this.TextBoxNewEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.TextBoxNewEmail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNewEmail.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxNewEmail.Location = new System.Drawing.Point(65, 171);
            this.TextBoxNewEmail.Name = "TextBoxNewEmail";
            this.TextBoxNewEmail.Size = new System.Drawing.Size(270, 27);
            this.TextBoxNewEmail.TabIndex = 3;
            this.TextBoxNewEmail.Text = "Email (email@example.com)";
            this.TextBoxNewEmail.Click += new System.EventHandler(this.TextBoxClick);
            this.TextBoxNewEmail.LostFocus += new System.EventHandler(this.ResetTextBox);
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
            this.LabelTitle.ForeColor = System.Drawing.Color.White;
            this.LabelTitle.Location = new System.Drawing.Point(64, 50);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(271, 27);
            this.LabelTitle.TabIndex = 0;
            this.LabelTitle.Text = "Create an Account, it\'s Free!";
            // 
            // ArtemisPageLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.PanelLogin);
            this.Controls.Add(this.PanelCreateAccount);
            this.Icon = global::ArtemisDesktopClient.Properties.Resources.ArtemisBlue256x256TaskBar;
            this.Name = "ArtemisPageLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artemis";
            this.Load += new System.EventHandler(this.ArtemisDesktop_Load);
            this.PanelLogin.ResumeLayout(false);
            this.PanelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePicture)).EndInit();
            this.PanelCreateAccount.ResumeLayout(false);
            this.PanelCreateAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxLoginPassword;
        private System.Windows.Forms.TextBox TextBoxLoginEmail;
        private System.Windows.Forms.Button ButtonLogin;
        private System.Windows.Forms.Panel PanelLogin;
        private System.Windows.Forms.Button ButtonSwitchToCreatePanel;
        private System.Windows.Forms.Panel PanelCreateAccount;
        private System.Windows.Forms.TextBox TextBoxNewEmail;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Button PanelSwitchToLogin;
        private System.Windows.Forms.Button ButtonCreateAccount;
        private System.Windows.Forms.TextBox TextBoxLastName;
        private System.Windows.Forms.TextBox TextBoxFirstName;
        private System.Windows.Forms.TextBox TextBoxCreatePassword;
        private System.Windows.Forms.TextBox TextBoxConfirmPassword;
        private System.Windows.Forms.PictureBox TitlePicture;
        private System.Windows.Forms.Label LabelLoginError;
        private System.Windows.Forms.Label LabelPasswordRequirements;
        private System.Windows.Forms.Label LabelConfirmPassword;
    }
}

