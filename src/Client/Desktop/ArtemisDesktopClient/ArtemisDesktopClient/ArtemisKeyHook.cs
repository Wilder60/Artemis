using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Web.Script.Serialization;


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
            //LabelKeyHookDescription.Text = KeysDic.ToString();
        }

        private async Task<Dictionary<string, string>> GetKeys()
        {
            Dictionary<string, string> Requestinfo = new Dictionary<string, string>();
            Requestinfo["id"] = _Account.id;
            var GetData = new JavaScriptSerializer().Serialize(Requestinfo);
            try
            {
                HttpRequestMessage GetRequest = new HttpRequestMessage
                {
                    Content = new StringContent(GetData, Encoding.UTF8, "application/json"),
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://127.0.0.1:3000/KeyHook")
                };
                GetRequest.Headers.Add("Authorization", _AuthToken);
                var response = await _client.SendAsync(GetRequest);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                string keysAndpass = await response.Content.ReadAsStringAsync();
                LabelKeyHookDescription.Text = keysAndpass;
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
