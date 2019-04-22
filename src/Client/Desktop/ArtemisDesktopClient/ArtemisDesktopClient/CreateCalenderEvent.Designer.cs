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
            this.TextBoxNewTitle = new System.Windows.Forms.TextBox();
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
            this.LabelNewEvent = new System.Windows.Forms.Label();
            this.PanelNewEvent = new System.Windows.Forms.Panel();
            this.PanelNewEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxNewTitle
            // 
            this.TextBoxNewTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNewTitle.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxNewTitle.Location = new System.Drawing.Point(25, 70);
            this.TextBoxNewTitle.Name = "TextBoxNewTitle";
            this.TextBoxNewTitle.Size = new System.Drawing.Size(350, 31);
            this.TextBoxNewTitle.TabIndex = 0;
            this.TextBoxNewTitle.Text = "Title";
            this.TextBoxNewTitle.GotFocus += new System.EventHandler(this.TextBoxGainFocus);
            this.TextBoxNewTitle.LostFocus += new System.EventHandler(this.TextBoxLostFocus);
            // 
            // ButtonCancelCreate
            // 
            this.ButtonCancelCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancelCreate.Location = new System.Drawing.Point(363, 12);
            this.ButtonCancelCreate.Name = "ButtonCancelCreate";
            this.ButtonCancelCreate.Size = new System.Drawing.Size(25, 25);
            this.ButtonCancelCreate.TabIndex = 2;
            this.ButtonCancelCreate.Text = "X";
            this.ButtonCancelCreate.UseVisualStyleBackColor = true;
            this.ButtonCancelCreate.Click += new System.EventHandler(this.ButtonCancelCreate_Click);
            // 
            // ButtonCreateEvent
            // 
            this.ButtonCreateEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCreateEvent.Location = new System.Drawing.Point(152, 475);
            this.ButtonCreateEvent.Name = "ButtonCreateEvent";
            this.ButtonCreateEvent.Size = new System.Drawing.Size(96, 40);
            this.ButtonCreateEvent.TabIndex = 3;
            this.ButtonCreateEvent.Text = "Create";
            this.ButtonCreateEvent.UseVisualStyleBackColor = true;
            // 
            // CheckBoxAllDay
            // 
            this.CheckBoxAllDay.AutoSize = true;
            this.CheckBoxAllDay.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxAllDay.ForeColor = System.Drawing.Color.White;
            this.CheckBoxAllDay.Location = new System.Drawing.Point(25, 141);
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
            this.LabelStartTime.Location = new System.Drawing.Point(25, 176);
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
            this.LabelEndTime.Location = new System.Drawing.Point(25, 226);
            this.LabelEndTime.Name = "LabelEndTime";
            this.LabelEndTime.Size = new System.Drawing.Size(37, 19);
            this.LabelEndTime.TabIndex = 7;
            this.LabelEndTime.Text = "End:";
            // 
            // DateTimeStartDate
            // 
            this.DateTimeStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimeStartDate.Location = new System.Drawing.Point(85, 176);
            this.DateTimeStartDate.Name = "DateTimeStartDate";
            this.DateTimeStartDate.Size = new System.Drawing.Size(128, 26);
            this.DateTimeStartDate.TabIndex = 8;
            this.DateTimeStartDate.ValueChanged += new System.EventHandler(this.DateTimeStartValueChanged);
            // 
            // DateTimeEndDate
            // 
            this.DateTimeEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimeEndDate.Location = new System.Drawing.Point(85, 226);
            this.DateTimeEndDate.Name = "DateTimeEndDate";
            this.DateTimeEndDate.Size = new System.Drawing.Size(128, 26);
            this.DateTimeEndDate.TabIndex = 9;
            this.DateTimeEndDate.ValueChanged += new System.EventHandler(this.DateTimeEndValueChanged);
            // 
            // TextBoxOffset
            // 
            this.TextBoxOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxOffset.Location = new System.Drawing.Point(64, 381);
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
            this.ComboBoxOffset.Location = new System.Drawing.Point(183, 381);
            this.ComboBoxOffset.Name = "ComboBoxOffset";
            this.ComboBoxOffset.Size = new System.Drawing.Size(121, 28);
            this.ComboBoxOffset.TabIndex = 15;
            // 
            // LabelNotifyTime
            // 
            this.LabelNotifyTime.AutoSize = true;
            this.LabelNotifyTime.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNotifyTime.ForeColor = System.Drawing.Color.White;
            this.LabelNotifyTime.Location = new System.Drawing.Point(21, 347);
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
            this.LabelBefore.Location = new System.Drawing.Point(318, 389);
            this.LabelBefore.Name = "LabelBefore";
            this.LabelBefore.Size = new System.Drawing.Size(57, 20);
            this.LabelBefore.TabIndex = 17;
            this.LabelBefore.Text = "Before";
            // 
            // TextBoxLocation
            // 
            this.TextBoxLocation.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.TextBoxLocation.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxLocation.Location = new System.Drawing.Point(25, 281);
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
            this.DateTimeStartTime.Location = new System.Drawing.Point(219, 176);
            this.DateTimeStartTime.Name = "DateTimeStartTime";
            this.DateTimeStartTime.ShowUpDown = true;
            this.DateTimeStartTime.Size = new System.Drawing.Size(113, 26);
            this.DateTimeStartTime.TabIndex = 13;
            // 
            // DateTimeEndTime
            // 
            this.DateTimeEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DateTimeEndTime.Location = new System.Drawing.Point(219, 226);
            this.DateTimeEndTime.Name = "DateTimeEndTime";
            this.DateTimeEndTime.ShowUpDown = true;
            this.DateTimeEndTime.Size = new System.Drawing.Size(113, 26);
            this.DateTimeEndTime.TabIndex = 10;
            // 
            // LabelNewEvent
            // 
            this.LabelNewEvent.AutoSize = true;
            this.LabelNewEvent.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNewEvent.ForeColor = System.Drawing.Color.White;
            this.LabelNewEvent.Location = new System.Drawing.Point(25, 15);
            this.LabelNewEvent.Name = "LabelNewEvent";
            this.LabelNewEvent.Size = new System.Drawing.Size(157, 39);
            this.LabelNewEvent.TabIndex = 19;
            this.LabelNewEvent.Text = "New Event";
            // 
            // PanelNewEvent
            // 
            this.PanelNewEvent.Controls.Add(this.LabelNewEvent);
            this.PanelNewEvent.Controls.Add(this.TextBoxLocation);
            this.PanelNewEvent.Controls.Add(this.LabelBefore);
            this.PanelNewEvent.Controls.Add(this.LabelNotifyTime);
            this.PanelNewEvent.Controls.Add(this.ComboBoxOffset);
            this.PanelNewEvent.Controls.Add(this.TextBoxOffset);
            this.PanelNewEvent.Controls.Add(this.DateTimeStartTime);
            this.PanelNewEvent.Controls.Add(this.DateTimeEndTime);
            this.PanelNewEvent.Controls.Add(this.DateTimeEndDate);
            this.PanelNewEvent.Controls.Add(this.DateTimeStartDate);
            this.PanelNewEvent.Controls.Add(this.LabelEndTime);
            this.PanelNewEvent.Controls.Add(this.LabelStartTime);
            this.PanelNewEvent.Controls.Add(this.CheckBoxAllDay);
            this.PanelNewEvent.Controls.Add(this.ButtonCreateEvent);
            this.PanelNewEvent.Controls.Add(this.ButtonCancelCreate);
            this.PanelNewEvent.Controls.Add(this.TextBoxNewTitle);
            this.PanelNewEvent.Location = new System.Drawing.Point(0, 0);
            this.PanelNewEvent.Name = "PanelNewEvent";
            this.PanelNewEvent.Size = new System.Drawing.Size(400, 550);
            this.PanelNewEvent.TabIndex = 20;
            // 
            // CreateCalenderEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(400, 550);
            this.Controls.Add(this.PanelNewEvent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateCalenderEvent";
            this.Text = "CreateCalenderEvent";
            this.PanelNewEvent.ResumeLayout(false);
            this.PanelNewEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxNewTitle;
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
        private System.Windows.Forms.Label LabelNewEvent;
        private System.Windows.Forms.Panel PanelNewEvent;
    }
}