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
    public partial class AddKeyHookPage : Form
    {
        private string website { get; set; }
        private string id { get; set; }
        private IEnumerable<string> AuthToken { get; set; }
        private HttpClient client;

        public AddKeyHookPage(string AccountID, IEnumerable<string> Token)
        {
            InitializeComponent();
            id = AccountID;
            AuthToken = Token;
            client = new HttpClient();
        }

        private async void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (!IsValidWebsite())
            {
                return;
            }
            Dictionary<string, string> Requestinfo = new Dictionary<string, string>();
            Requestinfo["id"] = id;
            Requestinfo["website"] = website;
            var PutData = new JavaScriptSerializer().Serialize(Requestinfo);
            try
            {
                HttpRequestMessage PutRequest = new HttpRequestMessage
                {
                    Content = new StringContent(PutData, Encoding.UTF8, "application/json"),
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://127.0.0.1:3000/KeyHook")
                };
                PutRequest.Headers.Add("Authorization", AuthToken);
                var response = await client.SendAsync(PutRequest);

                if (response.IsSuccessStatusCode)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    string ErrorMessage = await response.Content.ReadAsStringAsync();
                    LabelError.Text = ErrorMessage;
                }
            }
            catch(Exception HTTPexception)
            {
                LabelError.Text = HTTPexception.Message;
            }

        }

        private bool IsValidWebsite()
        {
            website = TextBoxWebsite.Text;
            if (website == "")
            {
                LabelError.Text = "Must enter Website name";
                return false;
            }
            website.Trim();
            if (website == "")
            {
                LabelError.Text = "Website name cannot be whitespaces";
                return false;
            }
            return true;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
