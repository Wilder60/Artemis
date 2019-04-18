namespace ArtemisDesktopClient
{
    partial class CreateCalenderEvent
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
            this.TextBoxTitle = new System.Windows.Forms.TextBox();
            this.ButtonCancelCreate = new System.Windows.Forms.Button();
            this.ButtonCreateEvent = new System.Windows.Forms.Button();
            this.CheckBoxAllDay = new System.Windows.Forms.CheckBox();
            this.LabelStartTime = new System.Windows.Forms.Label();
            this.LabelEndTime = new System.Windows.Forms.Label();
            this.DateTimeStartDate = new System.Windows.Forms.DateTimePicker();
            this.DateTimeEndDate = new System.Windows.Forms.DateTimePicker();
            this.TextBoxOffset = new System.Windows.Forms.TextBox();
            this.ComboBoxOffset = new System.Windows.Forms.ComboBox();
            this.LabelNotifyTime = new System.Windows.Forms.Label();
            this.LabelBefore = new System.Windows.Forms.Label();
            this.TextBoxLocation = new System.Windows.Forms.TextBox();
            this.DateTimeStartTime = new System.Windows.Forms.DateTimePicker();
            this.DateTimeEndTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // TextBoxTitle
            // 
            this.TextBoxTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTitle.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxTitle.Location = new System.Drawing.Point(25, 50);
            this.TextBoxTitle.Name = "TextBoxTitle";
            this.TextBoxTitle.Size = new System.Drawing.Size(350, 31);
            this.TextBoxTitle.TabIndex = 0;
            this.TextBoxTitle.Text = "Title";
            this.TextBoxTitle.GotFocus += new System.EventHandler(this.TextBoxGainFocus);
            this.TextBoxTitle.LostFocus += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // ButtonCancelCreate
            // 
            this.ButtonCancelCreate.Location = new System.Drawing.Point(51, 476);
            this.ButtonCancelCreate.Name = "ButtonCancelCreate";
            this.ButtonCancelCreate.Size = new System.Drawing.Size(95, 40);
            this.ButtonCancelCreate.TabIndex = 2;
            this.ButtonCancelCreate.Text = "Cancel";
            this.ButtonCancelCreate.UseVisualStyleBackColor = true;
            this.ButtonCancelCreate.Click += new System.EventHandler(this.ButtonCancelCreate_Click);
            // 
            // ButtonCreateEvent
            // 
            this.ButtonCreateEvent.Location = new System.Drawing.Point(237, 476);
            this.ButtonCreateEvent.Name = "ButtonCreateEvent";
            this.ButtonCreateEvent.Size = new System.Drawing.Size(95, 40);
            this.ButtonCreateEvent.TabIndex = 3;
            this.ButtonCreateEvent.Text = "Create";
            this.ButtonCreateEvent.UseVisualStyleBackColor = true;
            // 
            // CheckBoxAllDay
            // 
            this.CheckBoxAllDay.AutoSize = true;
            this.CheckBoxAllDay.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxAllDay.ForeColor = System.Drawing.Color.White;
            this.CheckBoxAllDay.Location = new System.Drawing.Point(25, 130);
            this.CheckBoxAllDay.Name = "CheckBoxAllDay";
            this.CheckBoxAllDay.Size = new System.Drawing.Size(82, 27);
            this.CheckBoxAllDay.TabIndex = 4;
            this.CheckBoxAllDay.Text = "All Day";
            this.CheckBoxAllDay.UseVisualStyleBackColor = true;
            this.CheckBoxAllDay.CheckStateChanged += new System.EventHandler(this.DisableTimeSelectors);
            // 
            // LabelStartTime
            // 
            this.LabelStartTime.AutoSize = true;
            this.LabelStartTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.LabelStartTime.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStartTime.ForeColor = System.Drawing.Color.White;
            this.LabelStartTime.Location = new System.Drawing.Point(25, 165);
            this.LabelStartTime.Name = "LabelStartTime";
            this.LabelStartTime.Size = new System.Drawing.Size(52, 23);
            this.LabelStartTime.TabIndex = 6;
            this.LabelStartTime.Text = "Start:";
            // 
            // LabelEndTime
            // 
            this.LabelEndTime.AutoSize = true;
            this.LabelEndTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEndTime.ForeColor = System.Drawing.Color.White;
            this.LabelEndTime.Location = new System.Drawing.Point(25, 215);
            this.LabelEndTime.Name = "LabelEndTime";
            this.LabelEndTime.Size = new System.Drawing.Size(37, 19);
            this.LabelEndTime.TabIndex = 7;
            this.LabelEndTime.Text = "End:";
            // 
            // DateTimeStartDate
            // 
            this.DateTimeStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimeStartDate.Location = new System.Drawing.Point(85, 165);
            this.DateTimeStartDate.Name = "DateTimeStartDate";
            this.DateTimeStartDate.Size = new System.Drawing.Size(128, 26);
            this.DateTimeStartDate.TabIndex = 8;
            this.DateTimeStartDate.ValueChanged += new System.EventHandler(this.DateTimeStartValueChanged);
            // 
            // DateTimeEndDate
            // 
            this.DateTimeEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimeEndDate.Location = new System.Drawing.Point(85, 215);
            this.DateTimeEndDate.Name = "DateTimeEndDate";
            this.DateTimeEndDate.Size = new System.Drawing.Size(128, 26);
            this.DateTimeEndDate.TabIndex = 9;
            this.DateTimeEndDate.ValueChanged += new System.EventHandler(this.DateTimeEndValueChanged);
            // 
            // TextBoxOffset
            // 
            this.TextBoxOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxOffset.Location = new System.Drawing.Point(64, 370);
            this.TextBoxOffset.Name = "TextBoxOffset";
            this.TextBoxOffset.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TextBoxOffset.Size = new System.Drawing.Size(100, 26);
            this.TextBoxOffset.TabIndex = 14;
            this.TextBoxOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxOffsetTextChange);
            // 
            // ComboBoxOffset
            // 
            this.ComboBoxOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxOffset.FormattingEnabled = true;
            this.ComboBoxOffset.Items.AddRange(new object[] {
            "Minutes",
            "Hours",
            "Days",
            "Weeks"});
            this.ComboBoxOffset.Location = new System.Drawing.Point(183, 370);
            this.ComboBoxOffset.Name = "ComboBoxOffset";
            this.ComboBoxOffset.Size = new System.Drawing.Size(121, 28);
            this.ComboBoxOffset.TabIndex = 15;
            // 
            // LabelNotifyTime
            // 
            this.LabelNotifyTime.AutoSize = true;
            this.LabelNotifyTime.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNotifyTime.ForeColor = System.Drawing.Color.White;
            this.LabelNotifyTime.Location = new System.Drawing.Point(21, 336);
            this.LabelNotifyTime.Name = "LabelNotifyTime";
            this.LabelNotifyTime.Size = new System.Drawing.Size(87, 23);
            this.LabelNotifyTime.TabIndex = 16;
            this.LabelNotifyTime.Text = "Notify Me";
            // 
            // LabelBefore
            // 
            this.LabelBefore.AutoSize = true;
            this.LabelBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelBefore.ForeColor = System.Drawing.Color.White;
            this.LabelBefore.Location = new System.Drawing.Point(318, 378);
            this.LabelBefore.Name = "LabelBefore";
            this.LabelBefore.Size = new System.Drawing.Size(57, 20);
            this.LabelBefore.TabIndex = 17;
            this.LabelBefore.Text = "Before";
            // 
            // TextBoxLocation
            // 
            this.TextBoxLocation.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.TextBoxLocation.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxLocation.Location = new System.Drawing.Point(25, 270);
            this.TextBoxLocation.Name = "TextBoxLocation";
            this.TextBoxLocation.Size = new System.Drawing.Size(350, 31);
            this.TextBoxLocation.TabIndex = 18;
            this.TextBoxLocation.Text = "Location";
            this.TextBoxLocation.GotFocus += new System.EventHandler(this.TextBoxGainFocus);
            this.TextBoxLocation.LostFocus += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // DateTimeStartTime
            // 
            this.DateTimeStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DateTimeStartTime.Location = new System.Drawing.Point(219, 165);
            this.DateTimeStartTime.Name = "DateTimeStartTime";
            this.DateTimeStartTime.ShowUpDown = true;
            this.DateTimeStartTime.Size = new System.Drawing.Size(113, 26);
            this.DateTimeStartTime.TabIndex = 13;
            // 
            // DateTimeEndTime
            // 
            this.DateTimeEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DateTimeEndTime.Location = new System.Drawing.Point(219, 215);
            this.DateTimeEndTime.Name = "DateTimeEndTime";
            this.DateTimeEndTime.ShowUpDown = true;
            this.DateTimeEndTime.Size = new System.Drawing.Size(113, 26);
            this.DateTimeEndTime.TabIndex = 10;
            // 
            // CreateCalenderEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(400, 550);
            this.Controls.Add(this.TextBoxLocation);
            this.Controls.Add(this.LabelBefore);
            this.Controls.Add(this.LabelNotifyTime);
            this.Controls.Add(this.ComboBoxOffset);
            this.Controls.Add(this.TextBoxOffset);
            this.Controls.Add(this.DateTimeStartTime);
            this.Controls.Add(this.DateTimeEndTime);
            this.Controls.Add(this.DateTimeEndDate);
            this.Controls.Add(this.DateTimeStartDate);
            this.Controls.Add(this.LabelEndTime);
            this.Controls.Add(this.LabelStartTime);
            this.Controls.Add(this.CheckBoxAllDay);
            this.Controls.Add(this.ButtonCreateEvent);
            this.Controls.Add(this.ButtonCancelCreate);
            this.Controls.Add(this.TextBoxTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateCalenderEvent";
            this.Text = "CreateCalenderEvent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxTitle;
        private System.Windows.Forms.Button ButtonCancelCreate;
        private System.Windows.Forms.Button ButtonCreateEvent;
        private System.Windows.Forms.CheckBox CheckBoxAllDay;
        private System.Windows.Forms.Label LabelStartTime;
        private System.Windows.Forms.Label LabelEndTime;
        private System.Windows.Forms.DateTimePicker DateTimeStartDate;
        private System.Windows.Forms.DateTimePicker DateTimeEndDate;
        private System.Windows.Forms.TextBox TextBoxOffset;
        private System.Windows.Forms.ComboBox ComboBoxOffset;
        private System.Windows.Forms.Label LabelNotifyTime;
        private System.Windows.Forms.Label LabelBefore;
        private System.Windows.Forms.TextBox TextBoxLocation;
        private System.Windows.Forms.DateTimePicker DateTimeStartTime;
        private System.Windows.Forms.DateTimePicker DateTimeEndTime;
    }
}