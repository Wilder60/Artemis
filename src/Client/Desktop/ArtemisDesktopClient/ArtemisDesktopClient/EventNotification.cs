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
    /// <summary>
    /// Class for the EventNotification Form
    /// This will appear everytime any data it received from the server
    /// </summary>
    public partial class EventNotification : Form
    {
        private IEnumerable<string> AuthToken;
        private string EventID;
        private HttpClient client;

        /// <summary>
        /// The constructor for the EventNotification class
        /// Load the values from the CalenderEvent object
        /// </summary>
        /// <param name="Token">The Users AuthToken</param>
        /// <param name="calender">The CalenderEvent to Show</param>
        public EventNotification(IEnumerable<string> Token, CalenderEvent calender)
        {
            InitializeComponent();
            EventID = calender.id;
            LabelEventTitle.Text += "\t" + calender.name;
            LabeLLocation.Text += "\t" + calender.location;
            LabelTimeFrame.Text += "\t" + calender.length;
            AuthToken = Token;
            client = new HttpClient();
        }

        /// <summary>
        /// When the Okay button is clicked, it will make a delete request to the server
        /// </summary>
        /// <param name="sender">The button being clicked</param>
        /// <param name="e">The EventArgs e</param>
        private async void ButtonOkClick(object sender, EventArgs e)
        {
            List<string> ListToDelete = new List<string>();
            ListToDelete.Add(EventID);
            var deletejson = new JavaScriptSerializer().Serialize(ListToDelete);
            HttpRequestMessage deleteRequest = new HttpRequestMessage
            {
                Content = new StringContent(deletejson, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://127.0.0.1:3000/User")
            };
            deleteRequest.Headers.Add("Authorization", AuthToken);
            await client.SendAsync(deleteRequest);
            this.DialogResult = DialogResult.OK;
        } 
    }
}
