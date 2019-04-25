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
using System.Threading;
using System.Web.Script.Serialization;

namespace ArtemisDesktopClient
{
    /// <summary>
    /// This part of the class is the main page and the voice page for Artemis
    /// </summary>
    public partial class ArtemisMainPage : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        internal Dictionary<string, Panel> PanelControl;
        //this is a hack and i dont like it
        internal IEnumerable<string> _AuthToken;
        internal UserAccount _Account;
        internal static HttpClient _client;
        internal volatile bool Run = false;
        /// <summary>
        /// This is the constructor for the main page of the app
        /// fills the PanelControl
        /// </summary>
        public ArtemisMainPage(IEnumerable<string> Token, UserAccount account)
        {
            InitializeComponent();
            _client = new HttpClient();
            this.PanelControl = new Dictionary<string, Panel>();
            PanelControl["SideMenu"] = PanelSideMenu;
            PanelControl["Voice"] = PanelArtemisVoice;
            PanelControl["Settings"] = PanelAccountSettings;
            PanelControl["KeyHook"] = PanelKeyHook;
            PanelControl["Calender"] = PanelArtemisCalender;
            _AuthToken = Token;
            _Account = account;
            this.PanelAccountSettings.Hide();
            this.PanelArtemisCalender.Hide();
            this.PanelSideMenu.Hide();
            this.PanelKeyHook.Hide();
            this.PanelArtemisVoice.Show();
            Panelinit();
            startlistening();
        }

        //These are heads that are required to use
        partial void ButtonArtemisClick(object sender, EventArgs e);
        partial void ButtonCloseSideMenuClick(object sender, EventArgs e);
        partial void button3_Click(object sender, EventArgs e);
        partial void ButtonKeyHookClick(object sender, EventArgs e);
        partial void ButtonLogOutClick(object sender, EventArgs e);
        partial void ButtonAccountPanelSwitch(object sender, EventArgs e);
        partial void button4_Click(object sender, EventArgs e);
        partial void ButtonCalenderPanelSwitch(object sender, EventArgs e);

        /// <summary>
        /// When the mouse is pressed down, gets the last location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackGroundMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        /// <summary>
        /// When the mouse is moved and the MouseDown is true update the location of the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackGroundMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        /// <summary>
        /// When the mouse is released is stops the app from updating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackGroundMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /// <summary>
        /// Depending on the time of day, the label will give a different greating
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        public void Panelinit()
        {
            LabelGreating.Text = "";
            TimeSpan now = DateTime.Now.TimeOfDay;
            if(now < new TimeSpan(12, 0, 0))
            {
                LabelGreating.Text += "Good Morning ";
            }
            else if (now < new TimeSpan(18, 0, 0))
            {
                LabelGreating.Text += "Good Afternoon ";
            }
            else
            {
                LabelGreating.Text += "Good Evening ";
            }
            LabelGreating.Text += String.Format("{0} {1}", _Account.firstname, _Account.lastname);
        }

        /// <summary>
        /// When is this clicked it will bring up the SideMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void button1Click(object sender, EventArgs e)
        {
            PanelControl["SideMenu"].Show();
            PanelControl["SideMenu"].BringToFront();
        }

        /// <summary>
        /// This function will spin a new thread that will make GET requests every 1
        /// second to check to see if the server has an alarm for the user
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        private void startlistening()
        {
            Run = true;
            var thread = new Thread(async () => 
            {
                while (Run)
                {
                    HttpRequestMessage GetRequest = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("http://127.0.0.1:3000/User?id=" + _Account.id)
                    };
                    GetRequest.Headers.Add("Authorization", _AuthToken);
                    var response = await _client.SendAsync(GetRequest);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        CalenderEvent[] calenderEvents;
                        calenderEvents = new JavaScriptSerializer().Deserialize<CalenderEvent[]>(data);
                        foreach(var CalEvent in calenderEvents)
                        {
                            EventNotification calenderEvent = new EventNotification(_AuthToken, CalEvent);
                            calenderEvent.ShowDialog();
                        }
                        
                    }
                    Thread.Sleep(1000);
                }
            });
            thread.Start();
        }
    }
}
