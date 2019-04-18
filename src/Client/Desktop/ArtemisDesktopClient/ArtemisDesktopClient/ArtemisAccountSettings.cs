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
        private List<TextBox> UpdatedTextBoxes = new List<TextBox>();
        /// <summary>
        /// Will bring up the sidebar menu when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        partial void button4_Click(object sender, EventArgs e)
        {
            this.PanelControl["SideMenu"].Show();
            this.PanelControl["SideMenu"].BringToFront();
        }

        /// <summary>
        /// This will run whenever whenever the panel is brought to the front
        /// or if the account details are saved
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
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

            UpdatedTextBoxes.Add(TextBoxEmail);
            UpdatedTextBoxes.Add(TextBoxOldPassword);
            UpdatedTextBoxes.Add(TextBoxNewPassword);
            UpdatedTextBoxes.Add(TextBoxFirstname);
            UpdatedTextBoxes.Add(TextBoxLastname);

        }

        private async void ButtonUpdateProfileClick(object sender, EventArgs e)
        {
            if (!IsValidNewPass())
            {
                return;
            }
            UserAccount UpdateAccount = GetUpdatedAccount();

            var PatchAccountJSON = new JavaScriptSerializer().Serialize(UpdateAccount);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(PatchAccountJSON, Encoding.UTF8, "application/json"),
                Method = new HttpMethod("PATCH"),
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

        private bool IsValidNewPass()
        {
            if(TextBoxNewPassword.Text != TextBoxNewPasswordConfirm.Text)
            {
                //error password boxes must match
                return false;
            }

            if (!Regex.IsMatch(TextBoxNewPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$"))
            {
                //error password does not meet requirements
                return false;
            }
            return true;
        }

        private UserAccount GetUpdatedAccount()
        {
            UserAccount temp = new UserAccount(_Account);

            foreach(TextBox box in UpdatedTextBoxes)
            {
                if(box.Text == "")
                {
                    continue;
                }
                switch (box.Name)
                {
                    case "TextBoxEmail":
                        temp.email = box.Text;
                        break;
                    case "TextBoxFirstname":
                        temp.firstname = box.Text;
                        break;
                    case "TextBoxLastname":
                        temp.lastname = box.Text;
                        break;
                    case "TextBoxOldPassword":
                        temp.password = box.Text;
                        break;
                    case "TextBoxNewPassword":
                        temp.updatepassword = box.Text;
                        break;
                }
            }
            if (RadioButtonModern.Checked)
            {
                temp.pageStyle = RadioButtonModern.Text;
            }
            else
            {
                temp.pageStyle = RadioButtonFunctional.Text;
            }
            return temp;
        }

        /// <summary>
        /// Click EventHandler for the ButtonDeleteAccount Button
        /// Will make a DELETE request to the server with the user Account id
        /// and close the ArtemisMainPage form
        /// </summary>
        /// <param name="sender">The button being clicked</param>
        /// <param name="e">The EventArguments</param>
        /// <returns>
        /// void
        /// </returns>
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
