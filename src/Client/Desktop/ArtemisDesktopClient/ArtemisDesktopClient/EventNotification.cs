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
    public partial class EventNotification : Form
    {
        private IEnumerable<string> AuthToken;
        private string EventID;
        private HttpClient client;

        public EventNotification(IEnumerable<string> Token, CalenderEvent calender)
        {
            InitializeComponent();
            EventID = calender.eventID;
            LabelEventTitle.Text += "\t" + calender.eventName;
            LabeLLocation.Text += "\t" + calender.eventlocation;
            LabelTimeFrame.Text += "\t" + calender.EventLength;
            AuthToken = Token;
            client = new HttpClient();
        }

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
