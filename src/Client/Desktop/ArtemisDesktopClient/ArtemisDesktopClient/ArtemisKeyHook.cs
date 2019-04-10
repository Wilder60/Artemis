using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Drawing;


namespace ArtemisDesktopClient
{
    /// <summary>
    /// The partial part of the ArtemisMainPage that deals with the functionallity
    /// of the KeyHook panel
    /// </summary>
    public partial class ArtemisMainPage
    {
        /// <value>The dictionary that is deserialized from the get request</value>
        private Dictionary<string, string> KeysDic;
        /// <summary>
        /// This button brings up the side menu that will let the user switch between panels
        /// </summary>
        /// <param name="sender">The object that was clicked</param>
        /// <param name="e">Any Event Arguments</param>
        /// <returns>
        /// void
        /// </returns>
        partial void button3_Click(object sender, EventArgs e)
        {
            PanelControl["SideMenu"].Show();
            PanelControl["SideMenu"].BringToFront();
        }

        /// <summary>
        /// Clears the keyhook panel of all Contents, querries the database
        /// and rebuilds the information on the page
        /// </summary>
        /// <remarks>
        /// This is all messed up right now, I know I can do this better
        /// </remarks>
        /// <returns>
        /// void
        /// </returns>
        private async void refreshKeyHookpage()
        {
            RemoveElements();
            KeysDic = await GetKeys();
            if (KeysDic == null)
            {
                return;
            }

            int i = 0;
            foreach (KeyValuePair<string, string> entry in KeysDic)
            {
                string WebsiteName = "";
                if(entry.Key.Length > 30)
                {
                    WebsiteName = entry.Key.Substring(0, 27);
                    WebsiteName += "...";
                }
                else
                {
                    WebsiteName = entry.Key;
                }

                Label PasswordLabel = new Label();
                PasswordLabel.Text = WebsiteName;
                PasswordLabel.Name = "PasswordLabel";
                PasswordLabel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                PasswordLabel.ForeColor = Color.White;
                PasswordLabel.BackColor = Color.FromArgb(48, 48, 48);
                PasswordLabel.Location = new Point(0, 100 + (i * 35) );
                PasswordLabel.Size = new Size(new Point(250, 19));
                PasswordLabel.Click += new EventHandler(this.SelectLabel);
                PasswordLabel.Tag = entry.Key;

                Label ValueLabel = new Label();
                ValueLabel.Text = entry.Value;
                ValueLabel.Name = "Label" + entry.Key;
                ValueLabel.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                ValueLabel.ForeColor = Color.White;
                ValueLabel.Location = new Point(330, 100 + (i * 35));
                ValueLabel.Size = new Size(new Point(300, 19));
                ValueLabel.Visible = false;

                Button button = new Button();
                button.Size = new Size(new Point(50, 19));
                button.Location = new Point(280, 100 + (i * 35));
                button.BackColor = Color.White;
                button.Text = "Show";
                button.Click += delegate (object sender, EventArgs e) { ShowPassword(sender, e, ValueLabel); };

                PanelDynamicKeyHook.Controls.Add(PasswordLabel);
                PanelDynamicKeyHook.Controls.Add(button);
                PanelDynamicKeyHook.Controls.Add(ValueLabel);
                i++;
            }

        }

        /// <summary>
        /// Will querry the database for all the keys and passwords for the user
        /// </summary>
        /// <remarks>
        /// I think I can refactor this into something that looks nicer
        /// </remarks>
        /// <returns>
        /// Dictionary containing all the keys and there passwords
        /// </returns>
        private async Task<Dictionary<string, string>> GetKeys()
        {
            try
            {
                HttpRequestMessage PutRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://127.0.0.1:3000/KeyHook?id=" + _Account.id)
                };
                PutRequest.Headers.Add("Authorization", _AuthToken);
                var response = await _client.SendAsync(PutRequest);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                string keysAndpass = await response.Content.ReadAsStringAsync();
                return new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(keysAndpass);
            }
            catch (Exception HTTPexception)
            {
                LabelKeyHookDescription.Text = HTTPexception.Message;
                return null;
            }
        }

        /// <summary>
        /// This button will create a new AddKeyHookPage form an wait for the result of the form
        /// </summary>
        /// <param name="sender">The object that was clicked</param>
        /// <param name="e">Any Event Arguments</param>
        /// <returns>
        /// void
        /// </returns>
        private void ButtonCreateNewPassword_Click(object sender, EventArgs e)
        {
            AddKeyHookPage WebsiteInput = new AddKeyHookPage(_Account.id, _AuthToken);
            DialogResult result = WebsiteInput.ShowDialog();
            refreshKeyHookpage();
        }

        /// <summary>
        /// This will select all the highlighted labels and
        /// will serial them and make a DELETE request to the KeyHook routes
        /// </summary>
        /// <param name="sender">The object that was clicked</param>
        /// <param name="e">Any Event Arguments</param>
        /// <returns>
        /// void
        /// </returns>
        private async void DeleteKeys(object sender, EventArgs e)
        {
            List<string> KeysToRemove = new List<string>();
            var keys = PanelDynamicKeyHook.Controls.Find("PasswordLabel", true);
            foreach(Control key in keys)
            {
                if( key.BackColor == Color.DimGray)
                {
                    KeysToRemove.Add((string)key.Tag);
                }
            }

            if (KeysToRemove.Count == 0)
            {
                return;
            }

            Dictionary<string, dynamic> DeleteBody = new Dictionary<string, dynamic>();
            DeleteBody["id"] = _Account.id;
            DeleteBody["websiteArray"] = KeysToRemove;

            var KeysToRemoveJSON = new JavaScriptSerializer().Serialize(DeleteBody);
            HttpRequestMessage DeleteRequest = new HttpRequestMessage
            {
                Content = new StringContent(KeysToRemoveJSON, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://127.0.0.1:3000/KeyHook")
            };

            DeleteRequest.Headers.Add("Authorization", _AuthToken);
            var response = await _client.SendAsync(DeleteRequest);
            if (response.IsSuccessStatusCode)
            {
                refreshKeyHookpage();
            }
        }

        /// <summary>
        /// Will select all the Control objects and remove them
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        private void RemoveElements()
        {
            foreach (Control item in PanelDynamicKeyHook.Controls)
            {
                PanelDynamicKeyHook.Controls.Remove(item);
                item.Dispose();
            }
        }

        /// <summary>
        /// When a label is click, it will either highlight or dehighlight the label
        /// </summary>
        /// <param name="sender">The object that was clicked</param>
        /// <param name="e">Any Event Arguments</param>
        /// <returns>
        /// void
        /// </returns>
        private void SelectLabel(object sender, EventArgs e)
        {
            Label temp = (Label)sender;
            if (temp.BackColor == Color.FromArgb(48, 48, 48))
            {
                ((Label)sender).BackColor = Color.DimGray;
            }
            else
            {
                ((Label)sender).BackColor = Color.FromArgb(48, 48, 48);
            }
        }

        /// <summary>
        /// When a button is clicked the Label containing the password will have its visible 
        /// setting set to true of false
        /// </summary>
        /// <param name="sender">The object that sends this request</param>
        /// <param name="e">The arguments</param>
        /// <param name="ValueLabel">The label that button acts on</param>
        /// <returns>
        /// void
        /// </returns>
        private void ShowPassword(object sender, EventArgs e, Label ValueLabel)
        {
            if (ValueLabel.Visible == true)
            {
                ValueLabel.Visible = false;
            }
            else
            {
                ValueLabel.Visible = true;
            }
        }

    }
}
