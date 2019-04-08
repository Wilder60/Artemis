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
    public partial class ArtemisMainPage
    {

        private Dictionary<string, string> KeysDic;
        partial void button3_Click(object sender, EventArgs e)
        {
            this.PanelSideMenu.Show();
            this.PanelSideMenu.BringToFront();
        }

        private async void refreshKeyHookpage()
        {
            KeysDic = await GetKeys();
            if (KeysDic == null)
            {
                return;
            }

            int i = 0;
            foreach (KeyValuePair<string, string> entry in KeysDic)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = entry.Key;
                checkBox.Name = "Label" + entry.Key;
                checkBox.ForeColor = Color.White;
                checkBox.Location = new Point(0, 0);
                checkBox.Left = 100;
                checkBox.Height = 100 + (50 * i);

                Size size = TextRenderer.MeasureText(entry.Key, checkBox.Font);
                Label ValueLabel = new Label();
                ValueLabel.Text = entry.Value;
                ValueLabel.Name = "Label" + entry.Key;
                checkBox.ForeColor = Color.White;
                ValueLabel.Location = new Point(0, 0);
                ValueLabel.Left = size.Width + 50;
                ValueLabel.Height = 100 + (50 * i);

                PanelDynamicKeyHook.Controls.Add(checkBox);
                PanelDynamicKeyHook.Controls.Add(ValueLabel);
                i++;
            }

        }

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

        private void ButtonCreateNewPassword_Click(object sender, EventArgs e)
        {
            AddKeyHookPage WebsiteInput = new AddKeyHookPage(_Account.id, _AuthToken);
            DialogResult result = WebsiteInput.ShowDialog();
        }

    }
}
