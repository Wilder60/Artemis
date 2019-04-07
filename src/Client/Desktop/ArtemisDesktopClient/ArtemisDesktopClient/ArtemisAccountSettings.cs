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
using System.Text.RegularExpressions;

namespace ArtemisDesktopClient
{
    partial class ArtemisMainPage
    {
        private bool CanDelete = false;
        /// <summary>
        /// Will bring up the sidebar menu when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        partial void button4_Click(object sender, EventArgs e)
        {
            this.PanelControl["SideMenu"].Show();
            this.PanelControl["SideMenu"].BringToFront();
        }

        public void Settingsinit()
        {
            CanDelete = false;
            TextBoxEmail.Text = _Account.email;
            TextBoxFirstname.Text = _Account.firstname;
            TextBoxLastname.Text = _Account.lastname;

            switch (_Account.pageStyle)
            {
                case "Modern":
                    RadioButtonModern.Checked = true;
                    break;
                case "Functional":
                    RadioButtonFunctional.Checked = true;
                    break;
            }

        }

        private async void ButtonDeleteAccount_Click(object sender, EventArgs e)
        {
            if (!CanDelete)
            {
                CanDelete = true;
                LabelDeleteWarning.Text = "Warning: Once your account is deleted it can not be recovered\r\nClick Delete Account again to delete.";
                return;
            }
            try
            {
                var DeleteAccountJSON = new JavaScriptSerializer().Serialize(_Account);
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Content = new StringContent(DeleteAccountJSON, Encoding.UTF8, "application/json"),
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri("http://127.0.0.1:3000/Auth")
                };
                request.Headers.Add("Authorization", _AuthToken);
                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    this.Owner.Show();
                    this.Close();
                }
                else
                {
                    LabelDeleteWarning.Text = "Opps something when wrong";
                }
            }
            catch (Exception HTTPexcpt)
            {
                LabelDeleteWarning.Text = HTTPexcpt.Message;
            }

        }
    }
}
