using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtemisDesktopClient
{
    public partial class CreateCalenderEvent : Form
    {

        public CreateCalenderEvent()
        {
            InitializeComponent();
            ComboBoxOffset.SelectedItem = "Minutes";
        }

        private void ButtonCancelCreate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void DisableTimeSelectors(object sender, EventArgs e)
        {
            if( ((CheckBox)sender).Checked )
            {
                DateTimeStartTime.Enabled = false;
                DateTimeEndTime.Enabled = false;
                return;
            }
            DateTimeStartTime.Enabled = true;
            DateTimeEndTime.Enabled = true;
            return;
        }

        private void DateTimeStartValueChanged(object sender, EventArgs e)
        {
            if (CheckBoxAllDay.Checked && DateTimeEndDate.Value != DateTimeStartDate.Value)
            {
                 DateTimeEndDate.Value = DateTimeStartDate.Value;
            }
        }

        private void DateTimeEndValueChanged(object sender, EventArgs e)
        {
            if(CheckBoxAllDay.Checked && DateTimeEndDate.Value != DateTimeStartDate.Value)
            {
                DateTimeStartDate.Value = DateTimeEndDate.Value;
            }
        }

        private void TextBoxOffsetTextChange(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TextBoxGainFocus(object sender, EventArgs e)
        {
            TextBox focusedBox = (TextBox)sender;
            string name = focusedBox.Name;
            focusedBox.ForeColor = Color.Black;
            switch (name)
            {
                case "TextBoxTitle":
                    if (focusedBox.Text == "Title")
                    {
                        focusedBox.Text = "";
                    }
                    break;
                case "TextBoxLocation":
                    if (focusedBox.Text == "Location")
                    {
                        focusedBox.Text = "";
                    }
                    break;
            }
        }
        
        private void TextBoxLostFocus(object sender, EventArgs e)
        {
            TextBox lostfocusBox = (TextBox)sender;
            if (lostfocusBox.Text != "")
            {
                return;
            }
            string name = lostfocusBox.Name;
            lostfocusBox.ForeColor = Color.Gray;
            switch (name)
            {
                case "TextBoxTitle":
                    lostfocusBox.Text = "Title";
                    break;
                case "TextBoxLocation":
                    lostfocusBox.Text = "Location";
                    break;
            }
        }
    }
}
