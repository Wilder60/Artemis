namespace ArtemisDesktopClient
{
    partial class ArtemisMainPage
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
            this.ButtonLogOut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CloseSideMenu = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ButtonAccountSettings = new System.Windows.Forms.Button();
            this.ButtonArtemis = new System.Windows.Forms.Button();
            this.ButtonKeyHook = new System.Windows.Forms.Button();
            this.PanelArtemisVoice = new System.Windows.Forms.Panel();
            this.LabelGreating = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelSideMenu = new System.Windows.Forms.Panel();
            this.PanelKeyHook = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelAccountSettings = new System.Windows.Forms.Panel();
            this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.LabelNewPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SettingEmailLabel = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LabelAccountTitle = new System.Windows.Forms.Label();
            this.ButtonAccountShowMenu = new System.Windows.Forms.Button();
            this.ButtonCalender = new System.Windows.Forms.Button();
            this.PanelArtemisVoice.SuspendLayout();
            this.PanelSideMenu.SuspendLayout();
            this.PanelKeyHook.SuspendLayout();
            this.PanelAccountSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonLogOut
            // 
            this.ButtonLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogOut.Location = new System.Drawing.Point(0, 750);
            this.ButtonLogOut.Name = "ButtonLogOut";
            this.ButtonLogOut.Size = new System.Drawing.Size(250, 50);
            this.ButtonLogOut.TabIndex = 2;
            this.ButtonLogOut.TabStop = false;
            this.ButtonLogOut.Text = "Log out";
            this.ButtonLogOut.UseVisualStyleBackColor = false;
            this.ButtonLogOut.Click += new System.EventHandler(this.ButtonLogOutClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 75);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "ShowSidePanel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1Click);
            // 
            // CloseSideMenu
            // 
            this.CloseSideMenu.Location = new System.Drawing.Point(0, 0);
            this.CloseSideMenu.Name = "CloseSideMenu";
            this.CloseSideMenu.Size = new System.Drawing.Size(250, 50);
            this.CloseSideMenu.TabIndex = 0;
            this.CloseSideMenu.TabStop = false;
            this.CloseSideMenu.Text = "Close";
            this.CloseSideMenu.UseVisualStyleBackColor = true;
            this.CloseSideMenu.Click += new System.EventHandler(this.Button2Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 75);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Text = "ShowSideMenu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ButtonAccountSettings
            // 
            this.ButtonAccountSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonAccountSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAccountSettings.Location = new System.Drawing.Point(0, 700);
            this.ButtonAccountSettings.Name = "ButtonAccountSettings";
            this.ButtonAccountSettings.Size = new System.Drawing.Size(250, 50);
            this.ButtonAccountSettings.TabIndex = 4;
            this.ButtonAccountSettings.TabStop = false;
            this.ButtonAccountSettings.Text = "Account";
            this.ButtonAccountSettings.UseVisualStyleBackColor = false;
            this.ButtonAccountSettings.Click += new System.EventHandler(this.ButtonAccountPanelSwitch);
            // 
            // ButtonArtemis
            // 
            this.ButtonArtemis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonArtemis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonArtemis.Location = new System.Drawing.Point(0, 100);
            this.ButtonArtemis.Name = "ButtonArtemis";
            this.ButtonArtemis.Size = new System.Drawing.Size(250, 50);
            this.ButtonArtemis.TabIndex = 1;
            this.ButtonArtemis.TabStop = false;
            this.ButtonArtemis.Text = "Artemis";
            this.ButtonArtemis.UseVisualStyleBackColor = false;
            this.ButtonArtemis.Click += new System.EventHandler(this.ButtonArtemisClick);
            // 
            // ButtonKeyHook
            // 
            this.ButtonKeyHook.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonKeyHook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonKeyHook.Location = new System.Drawing.Point(0, 50);
            this.ButtonKeyHook.Name = "ButtonKeyHook";
            this.ButtonKeyHook.Size = new System.Drawing.Size(250, 50);
            this.ButtonKeyHook.TabIndex = 3;
            this.ButtonKeyHook.TabStop = false;
            this.ButtonKeyHook.Text = "KeyHook";
            this.ButtonKeyHook.UseVisualStyleBackColor = false;
            this.ButtonKeyHook.Click += new System.EventHandler(this.ButtonKeyHookClick);
            // 
            // PanelArtemisVoice
            // 
            this.PanelArtemisVoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.PanelArtemisVoice.Controls.Add(this.LabelGreating);
            this.PanelArtemisVoice.Controls.Add(this.label2);
            this.PanelArtemisVoice.Controls.Add(this.button1);
            this.PanelArtemisVoice.Location = new System.Drawing.Point(0, 0);
            this.PanelArtemisVoice.Name = "PanelArtemisVoice";
            this.PanelArtemisVoice.Size = new System.Drawing.Size(1300, 800);
            this.PanelArtemisVoice.TabIndex = 2;
            this.PanelArtemisVoice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseDown);
            this.PanelArtemisVoice.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseMove);
            this.PanelArtemisVoice.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseUp);
            // 
            // LabelGreating
            // 
            this.LabelGreating.AutoSize = true;
            this.LabelGreating.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGreating.ForeColor = System.Drawing.Color.White;
            this.LabelGreating.Location = new System.Drawing.Point(105, 3);
            this.LabelGreating.Name = "LabelGreating";
            this.LabelGreating.Size = new System.Drawing.Size(796, 39);
            this.LabelGreating.TabIndex = 2;
            this.LabelGreating.Text = "Good Afternoon 01234567890123456789012345678912345";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1204, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Voice";
            // 
            // PanelSideMenu
            // 
            this.PanelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.PanelSideMenu.Controls.Add(this.ButtonCalender);
            this.PanelSideMenu.Controls.Add(this.CloseSideMenu);
            this.PanelSideMenu.Controls.Add(this.ButtonArtemis);
            this.PanelSideMenu.Controls.Add(this.ButtonLogOut);
            this.PanelSideMenu.Controls.Add(this.ButtonKeyHook);
            this.PanelSideMenu.Controls.Add(this.ButtonAccountSettings);
            this.PanelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelSideMenu.Name = "PanelSideMenu";
            this.PanelSideMenu.Size = new System.Drawing.Size(250, 800);
            this.PanelSideMenu.TabIndex = 1;
            this.PanelSideMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseDown);
            this.PanelSideMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseMove);
            this.PanelSideMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseUp);
            // 
            // PanelKeyHook
            // 
            this.PanelKeyHook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.PanelKeyHook.Controls.Add(this.label1);
            this.PanelKeyHook.Controls.Add(this.button3);
            this.PanelKeyHook.Location = new System.Drawing.Point(0, 0);
            this.PanelKeyHook.Name = "PanelKeyHook";
            this.PanelKeyHook.Size = new System.Drawing.Size(1300, 800);
            this.PanelKeyHook.TabIndex = 0;
            this.PanelKeyHook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseDown);
            this.PanelKeyHook.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseMove);
            this.PanelKeyHook.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1160, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "KeyHook";
            // 
            // PanelAccountSettings
            // 
            this.PanelAccountSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.PanelAccountSettings.Controls.Add(this.ConfirmPasswordLabel);
            this.PanelAccountSettings.Controls.Add(this.LabelNewPassword);
            this.PanelAccountSettings.Controls.Add(this.label3);
            this.PanelAccountSettings.Controls.Add(this.radioButton2);
            this.PanelAccountSettings.Controls.Add(this.radioButton1);
            this.PanelAccountSettings.Controls.Add(this.SettingEmailLabel);
            this.PanelAccountSettings.Controls.Add(this.textBox3);
            this.PanelAccountSettings.Controls.Add(this.textBox2);
            this.PanelAccountSettings.Controls.Add(this.textBox1);
            this.PanelAccountSettings.Controls.Add(this.LabelAccountTitle);
            this.PanelAccountSettings.Controls.Add(this.ButtonAccountShowMenu);
            this.PanelAccountSettings.Location = new System.Drawing.Point(0, 0);
            this.PanelAccountSettings.Name = "PanelAccountSettings";
            this.PanelAccountSettings.Size = new System.Drawing.Size(1300, 800);
            this.PanelAccountSettings.TabIndex = 0;
            this.PanelAccountSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseDown);
            this.PanelAccountSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseMove);
            this.PanelAccountSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackGroundMouseUp);
            // 
            // ConfirmPasswordLabel
            // 
            this.ConfirmPasswordLabel.AutoSize = true;
            this.ConfirmPasswordLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmPasswordLabel.ForeColor = System.Drawing.Color.White;
            this.ConfirmPasswordLabel.Location = new System.Drawing.Point(100, 165);
            this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            this.ConfirmPasswordLabel.Size = new System.Drawing.Size(267, 33);
            this.ConfirmPasswordLabel.TabIndex = 10;
            this.ConfirmPasswordLabel.Text = "Confirm New Password";
            // 
            // LabelNewPassword
            // 
            this.LabelNewPassword.AutoSize = true;
            this.LabelNewPassword.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNewPassword.ForeColor = System.Drawing.Color.White;
            this.LabelNewPassword.Location = new System.Drawing.Point(100, 65);
            this.LabelNewPassword.Name = "LabelNewPassword";
            this.LabelNewPassword.Size = new System.Drawing.Size(174, 33);
            this.LabelNewPassword.TabIndex = 9;
            this.LabelNewPassword.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(100, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "Style";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(202, 271);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(94, 23);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "Functional";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(100, 269);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 23);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.Text = "Modern";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // SettingEmailLabel
            // 
            this.SettingEmailLabel.AutoSize = true;
            this.SettingEmailLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingEmailLabel.ForeColor = System.Drawing.Color.White;
            this.SettingEmailLabel.Location = new System.Drawing.Point(100, 312);
            this.SettingEmailLabel.Name = "SettingEmailLabel";
            this.SettingEmailLabel.Size = new System.Drawing.Size(75, 33);
            this.SettingEmailLabel.TabIndex = 5;
            this.SettingEmailLabel.Text = "Email";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(100, 200);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(700, 20);
            this.textBox3.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(100, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(700, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 350);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(700, 20);
            this.textBox1.TabIndex = 2;
            // 
            // LabelAccountTitle
            // 
            this.LabelAccountTitle.AutoSize = true;
            this.LabelAccountTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAccountTitle.ForeColor = System.Drawing.Color.White;
            this.LabelAccountTitle.Location = new System.Drawing.Point(1056, 8);
            this.LabelAccountTitle.Name = "LabelAccountTitle";
            this.LabelAccountTitle.Size = new System.Drawing.Size(236, 39);
            this.LabelAccountTitle.TabIndex = 1;
            this.LabelAccountTitle.Text = "Account Settings";
            // 
            // ButtonAccountShowMenu
            // 
            this.ButtonAccountShowMenu.Location = new System.Drawing.Point(0, 0);
            this.ButtonAccountShowMenu.Name = "ButtonAccountShowMenu";
            this.ButtonAccountShowMenu.Size = new System.Drawing.Size(100, 50);
            this.ButtonAccountShowMenu.TabIndex = 0;
            this.ButtonAccountShowMenu.Text = "Menu";
            this.ButtonAccountShowMenu.UseVisualStyleBackColor = true;
            this.ButtonAccountShowMenu.Click += new System.EventHandler(this.button4_Click);
            // 
            // ButtonCalender
            // 
            this.ButtonCalender.BackColor = System.Drawing.Color.White;
            this.ButtonCalender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCalender.Location = new System.Drawing.Point(0, 150);
            this.ButtonCalender.Name = "ButtonCalender";
            this.ButtonCalender.Size = new System.Drawing.Size(250, 50);
            this.ButtonCalender.TabIndex = 5;
            this.ButtonCalender.Text = "Calender";
            this.ButtonCalender.UseVisualStyleBackColor = false;
            // 
            // ArtemisMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.PanelSideMenu);
            this.Controls.Add(this.PanelKeyHook);
            this.Controls.Add(this.PanelArtemisVoice);
            this.Controls.Add(this.PanelAccountSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ArtemisMainPage";
            this.Text = "ArtemisMainPage";
            this.PanelArtemisVoice.ResumeLayout(false);
            this.PanelArtemisVoice.PerformLayout();
            this.PanelSideMenu.ResumeLayout(false);
            this.PanelKeyHook.ResumeLayout(false);
            this.PanelKeyHook.PerformLayout();
            this.PanelAccountSettings.ResumeLayout(false);
            this.PanelAccountSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ButtonLogOut;
        internal System.Windows.Forms.Panel PanelSideMenu;
        internal System.Windows.Forms.Button ButtonKeyHook;
        internal System.Windows.Forms.Button ButtonAccountSettings;
        internal System.Windows.Forms.Button ButtonArtemis;
        internal System.Windows.Forms.Button CloseSideMenu;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Panel PanelArtemisVoice;
        internal System.Windows.Forms.Panel PanelKeyHook;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelAccountSettings;
        private System.Windows.Forms.Button ButtonAccountShowMenu;
        private System.Windows.Forms.Label LabelAccountTitle;
        private System.Windows.Forms.Label LabelGreating;
        private System.Windows.Forms.Label SettingEmailLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label ConfirmPasswordLabel;
        private System.Windows.Forms.Label LabelNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonCalender;
    }
}