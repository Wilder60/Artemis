using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace ArtemisDesktopClient
{
    public partial class CreateCalenderEvent : Form
    {
        private HttpClient httpClient;
        private Dictionary<string, int> TimeConv = new Dictionary<string, int>()
        {
            ["Minutes"] = 60,
            ["Hours"] = 3600,
            ["Days"] = 86400,
            ["Weeks"] = 604800
        };

        private CalenderEvent calenderEvent;
        private UserAccount _account;
        private IEnumerable<string> _Token;
        
        /// <summary>
        /// First Constructor for the CreateCalenderEvent
        /// This will be called when the user wants to create a new Event
        /// </summary>
        /// <param name="account">The Users Account</param>
        /// <param name="Token">The Users AuthToken</param>
        /// <returns>
        /// void
        /// </returns>
        public CreateCalenderEvent(UserAccount account, IEnumerable<string> Token)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            ComboBoxOffset.SelectedItem = "Minutes";
            _account = account;
            _Token = Token;
            ButtonDelete.Enabled = false;
            ButtonDelete.Visible = false;
            ButtonCreateEvent.Click += new EventHandler(this.CreateEvent);
        }

        /// <summary>
        /// Second Constructor for the CreateCalenderEvent Form
        /// This will be called when the user wants to edit an Event
        /// </summary>
        /// <param name="account">The User Account</param>
        /// <param name="Token">The User's Token</param>
        /// <param name="Event">The Event that the user wants to edit</param>
        /// <returns>
        /// void
        /// </returns>
        public CreateCalenderEvent(UserAccount account, IEnumerable<string> Token, CalenderEvent Event)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            _account = account;
            _Token = Token;
            ComboBoxOffset.SelectedItem = "Minutes";
            calenderEvent = Event;
            LoadFields(); 
            LabelNewEvent.Text = "Edit Event";
            ButtonCreateEvent.Text = "Update";
            ButtonCreateEvent.Click += new EventHandler(this.UpdateEvent);
        }

        /// <summary>
        /// The EventHandler for The ButtonCreateEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void CreateEvent(object sender, EventArgs e)
        {
            CalenderEvent calenderEvent = FormEvent();
            var UpdateObj = new JavaScriptSerializer().Serialize(calenderEvent);
            SendRequest(UpdateObj, HttpMethod.Post);
        }

        /// <summary>
        /// The Click EventHandler for the UpdateEvent Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void UpdateEvent(object sender, EventArgs e)
        {
            CalenderEvent calenderEvent = FormEvent();
            var UpdateObj = new JavaScriptSerializer().Serialize(calenderEvent);
            SendRequest(UpdateObj, HttpMethod.Put);
        }

        /// <summary>
        /// The Click EventHandler for the DeleteEvent Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void DeleteEvent(object sender, EventArgs e)
        {
            CalenderEvent calenderEvent = FormEvent();
            var UpdateObj = new JavaScriptSerializer().Serialize(calenderEvent);
            SendRequest(UpdateObj, HttpMethod.Delete);
        }


        /// <summary>
        /// Will send a request to the server with the approiate Method and JSON object
        /// </summary>
        /// <remarks>
        /// This makes requests to the server at the Calender Route
        /// </remarks>
        /// <param name="JSON">The serialized CalenderEvent object</param>
        /// <param name="_Method">The message to send</param>
        /// <returns>
        /// void
        /// </returns>
        private async void SendRequest(string JSON, HttpMethod _Method)
        {
            try
            {
                HttpRequestMessage Request = new HttpRequestMessage
                {
                    Content = new StringContent(JSON, Encoding.UTF8, "application/json"),
                    Method = _Method,
                    RequestUri = new Uri("http://127.0.0.1:3000/Calender")
                };
                Request.Headers.Add("Authorization", _Token);
                var response = await httpClient.SendAsync(Request);
                if (!response.IsSuccessStatusCode)
                {
                    LabelError.Text = await response.Content.ReadAsStringAsync();
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            catch( Exception e)
            {
                LabelError.Text = e.Message;
                return;
            }

        }

        /// <summary>
        /// Loads the Fields of a CalenderEvent Class to edit them
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        private void LoadFields()
        {
            TextBoxNewTitle.Text = calenderEvent.name;
            if(calenderEvent.length == "All Day")
            {
                CheckBoxAllDay.Checked = true;
                DateTimeStartTime.Enabled = false;
                DateTimeEndTime.Enabled = false;
            }
            DateTimeStartDate.Value = DateTime.Parse(calenderEvent.startdate);
            DateTimeStartTime.Value = DateTime.Parse(calenderEvent.startdate);
            DateTimeEndDate.Value = DateTime.Parse(calenderEvent.startdate);
            DateTimeEndTime.Value = DateTime.Parse(calenderEvent.startdate);
            TextBoxLocation.Text = calenderEvent.location;
            TextBoxOffset.Text = calenderEvent.alarmbase;
            ComboBoxOffset.SelectedText = calenderEvent.alarmiter;
        } 

        /// <summary>
        /// Will form a Valid CalenderEvent from the Data currently entered in the form
        /// </summary>
        /// <returns>
        /// A CalenderEvent Object containing all the fields of the Form
        /// </returns>
        private CalenderEvent FormEvent()
        {
            CalenderEvent NewEvent = new CalenderEvent();

            NewEvent.owner = _account.id;
            NewEvent.name = TextBoxNewTitle.Text;
            NewEvent.location = TextBoxLocation.Text;
            if (CheckBoxAllDay.Checked)
            {
                NewEvent.length = "All Day";
            }
            else
            {
                NewEvent.length = DateTimeStartTime.Value.TimeOfDay.ToString() + " - " + DateTimeEndTime.Value.TimeOfDay.ToString();
            }

            NewEvent.startdate = DateTimeStartDate.Value.Date.ToLongDateString();
            NewEvent.starttime = DateTimeStartTime.Value.TimeOfDay.ToString();
            NewEvent.enddate = DateTimeEndDate.Value.Date.ToLongDateString();
            NewEvent.endtime = DateTimeEndTime.Value.TimeOfDay.ToString();
            NewEvent.alarmbase = TextBoxOffset.Text;
            NewEvent.alarmiter = ComboBoxOffset.SelectedText;

            DateTime date = DateTimeStartDate.Value.Date + DateTimeStartTime.Value.TimeOfDay;
            DateTimeOffset timeOffset = new DateTimeOffset(date);

            NewEvent.alarmtime = timeOffset.ToUnixTimeSeconds();
            //int.Prase can throw an exception if the string is invalid, but only valid inputs can be
            //entered so no try catch is needed
            NewEvent.alarmoffset = (int.Parse(TextBoxOffset.Text) * TimeConv[ComboBoxOffset.SelectedText]);

            return NewEvent;
        }

        /// <summary>
        /// When clicking the Cancel button it will close the form
        /// and send a DialogResult.Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void ButtonCancelCreate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// When CheckBoxAllDay is checked it will disable the time sectors
        /// else it will reenable it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
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

        /// <summary>
        /// When the CheckBoxAllDay is checked an one of the dateboxes is changed
        /// it will make the other match
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void DateTimeValueChanged(object sender, EventArgs e)
        {
            if (!CheckBoxAllDay.Checked)
            {
                return;
            }
            string name = ((DateTimePicker)sender).Name;
            if(name == "DateTimeEndDate" && DateTimeEndDate.Value != DateTimeStartDate.Value)
            {
                DateTimeStartDate.Value = DateTimeEndDate.Value;
            }
            else if(name == "DateTimeStartDate" && DateTimeEndDate.Value != DateTimeStartDate.Value)
            {
                DateTimeEndDate.Value = DateTimeStartDate.Value;
            }
        }

        /// <summary>
        /// This will stop all key press that are not numerical characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void TextBoxOffsetTextChange(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// When the any TextBox gains focus and has a defualt value
        /// it will clear it and change the color to black
        /// </summary>
        /// <param name="sender">TextBoxes in the form</param>
        /// <param name="e">The commandline arguments</param>
        /// <returns>
        /// void
        /// </returns>
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
        
        /// <summary>
        /// When any textbox looses focus and is empty it loads the default value and color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
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
