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
    /// The class for the AddKeyHookPage form
    /// </summary>
    /// <remarks>
    /// The form is displayed whenever the user wants to add a new key
    /// </remarks>
    public partial class AddKeyHookPage : Form
    {
        private string website { get; set; }
        private string id { get; set; }
        private IEnumerable<string> AuthToken { get; set; }
        private HttpClient client;

        /// <summary>
        /// The Constructor for the form
        /// </summary>
        /// <param name="AccountID">The ID of the user who opened the form</param>
        /// <param name="Token">The users Auth Token</param>
        public AddKeyHookPage(string AccountID, IEnumerable<string> Token)
        {
            InitializeComponent();
            id = AccountID;
            AuthToken = Token;
            client = new HttpClient();
        }

        /// <summary>
        /// Click Eventhandler for the ButtonAccept Button
        /// Makes a POST request to the server
        /// </summary>
        /// <param name="sender">the button that is being clicked</param>
        /// <param name="e">The event args</param>
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

        /// <summary>
        /// Checks to see if the website name being passed in is valid or not
        /// </summary>
        /// <returns>
        /// true if the name is valid
        /// false if the Text is empty or all spaces
        /// </returns>
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

        /// <summary>
        /// The Click EventHandler for the ButtonCancel Button
        /// This will close the form without sending a request to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
