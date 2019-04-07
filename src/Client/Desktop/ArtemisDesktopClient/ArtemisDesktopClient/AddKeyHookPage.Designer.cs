namespace ArtemisDesktopClient
{
    partial class AddKeyHookPage
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
            this.LabelEnterNewPassword = new System.Windows.Forms.Label();
            this.TextBoxWebsite = new System.Windows.Forms.TextBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.LabelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelEnterNewPassword
            // 
            this.LabelEnterNewPassword.AutoSize = true;
            this.LabelEnterNewPassword.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEnterNewPassword.ForeColor = System.Drawing.Color.White;
            this.LabelEnterNewPassword.Location = new System.Drawing.Point(13, 13);
            this.LabelEnterNewPassword.Name = "LabelEnterNewPassword";
            this.LabelEnterNewPassword.Size = new System.Drawing.Size(258, 36);
            this.LabelEnterNewPassword.TabIndex = 0;
            this.LabelEnterNewPassword.Text = "Enter Website Name";
            // 
            // TextBoxWebsite
            // 
            this.TextBoxWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxWebsite.Location = new System.Drawing.Point(20, 50);
            this.TextBoxWebsite.Name = "TextBoxWebsite";
            this.TextBoxWebsite.Size = new System.Drawing.Size(456, 26);
            this.TextBoxWebsite.TabIndex = 1;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(20, 170);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(200, 50);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.Location = new System.Drawing.Point(275, 170);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(200, 50);
            this.ButtonAccept.TabIndex = 3;
            this.ButtonAccept.Text = "Create";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            this.ButtonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // LabelError
            // 
            this.LabelError.AutoSize = true;
            this.LabelError.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LabelError.Location = new System.Drawing.Point(20, 101);
            this.LabelError.Name = "LabelError";
            this.LabelError.Size = new System.Drawing.Size(0, 33);
            this.LabelError.TabIndex = 4;
            // 
            // AddKeyHookPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(494, 236);
            this.Controls.Add(this.LabelError);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.TextBoxWebsite);
            this.Controls.Add(this.LabelEnterNewPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddKeyHookPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddKeyHookPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelEnterNewPassword;
        private System.Windows.Forms.TextBox TextBoxWebsite;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonAccept;
        private System.Windows.Forms.Label LabelError;
    }
}