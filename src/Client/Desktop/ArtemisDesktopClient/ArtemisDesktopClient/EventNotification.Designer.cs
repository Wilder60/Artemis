namespace ArtemisDesktopClient
{
    partial class EventNotification
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
            this.LabelAlert = new System.Windows.Forms.Label();
            this.LabelEventTitle = new System.Windows.Forms.Label();
            this.LabeLLocation = new System.Windows.Forms.Label();
            this.LabelTimeFrame = new System.Windows.Forms.Label();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelAlert
            // 
            this.LabelAlert.AutoSize = true;
            this.LabelAlert.Font = new System.Drawing.Font("Calibri", 24F);
            this.LabelAlert.ForeColor = System.Drawing.Color.White;
            this.LabelAlert.Location = new System.Drawing.Point(246, 15);
            this.LabelAlert.Name = "LabelAlert";
            this.LabelAlert.Size = new System.Drawing.Size(158, 39);
            this.LabelAlert.TabIndex = 0;
            this.LabelAlert.Text = "New Alert!";
            // 
            // LabelEventTitle
            // 
            this.LabelEventTitle.AutoSize = true;
            this.LabelEventTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEventTitle.ForeColor = System.Drawing.Color.White;
            this.LabelEventTitle.Location = new System.Drawing.Point(50, 75);
            this.LabelEventTitle.Name = "LabelEventTitle";
            this.LabelEventTitle.Size = new System.Drawing.Size(69, 33);
            this.LabelEventTitle.TabIndex = 1;
            this.LabelEventTitle.Text = "Title:";
            // 
            // LabeLLocation
            // 
            this.LabeLLocation.AutoSize = true;
            this.LabeLLocation.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabeLLocation.ForeColor = System.Drawing.Color.White;
            this.LabeLLocation.Location = new System.Drawing.Point(50, 150);
            this.LabeLLocation.Name = "LabeLLocation";
            this.LabeLLocation.Size = new System.Drawing.Size(114, 33);
            this.LabeLLocation.TabIndex = 2;
            this.LabeLLocation.Text = "Location:";
            // 
            // LabelTimeFrame
            // 
            this.LabelTimeFrame.AutoSize = true;
            this.LabelTimeFrame.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTimeFrame.ForeColor = System.Drawing.Color.White;
            this.LabelTimeFrame.Location = new System.Drawing.Point(50, 225);
            this.LabelTimeFrame.Name = "LabelTimeFrame";
            this.LabelTimeFrame.Size = new System.Drawing.Size(76, 33);
            this.LabelTimeFrame.TabIndex = 3;
            this.LabelTimeFrame.Text = "Time:";
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.Location = new System.Drawing.Point(250, 300);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(150, 50);
            this.ButtonAccept.TabIndex = 4;
            this.ButtonAccept.Text = "Ok";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            this.ButtonAccept.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // EventNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.LabelTimeFrame);
            this.Controls.Add(this.LabeLLocation);
            this.Controls.Add(this.LabelEventTitle);
            this.Controls.Add(this.LabelAlert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EventNotification";
            this.Text = "EventNotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelAlert;
        private System.Windows.Forms.Label LabelEventTitle;
        private System.Windows.Forms.Label LabeLLocation;
        private System.Windows.Forms.Label LabelTimeFrame;
        private System.Windows.Forms.Button ButtonAccept;
    }
}