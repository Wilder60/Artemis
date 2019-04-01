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
    public partial class ArtemisPageLogin : Form
    {
        private static HttpClient client;
        private bool mouseDown;
        private Point lastLocation;

        public ArtemisPageLogin()
        {
            InitializeComponent();
            PanelLogin.Visible = true;
            PanelCreateAccount.Visible = false;
        }
        
        /*OnLoad page function*/
        private void ArtemisDesktop_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
        }

        /* Buttons that communicate with the server*/
        /* This should return from the server the token which will be sent over
         * Plus the persons JSON without there hashpass so the client can be more
         * personized
         */
        private async void LoginButton_Click(object sender, EventArgs e)
        {
            UserAccount LoginInfo = new UserAccount();
            LoginInfo.email = TextBoxLoginEmail.Text;
            LoginInfo.password = TextBoxLoginPassword.Text;

            var json = new JavaScriptSerializer().Serialize(LoginInfo);
            try
            {
                var response = await client.PostAsync("http://localhost:3000/Auth",
                    new StringContent(json, Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    LabelLoginError.Text = response.ReasonPhrase;
                }
                else
                {
                    IEnumerable<string> Token;
                    response.Headers.TryGetValues("MasterToken", out Token);
                    ArtemisMainPage MainPage = new ArtemisMainPage();
                    this.Hide();
                    MainPage.Show(this);
                }
            }
            catch (Exception HTTPexcpt)
            {
                LabelLoginError.Text = HTTPexcpt.Message;
            }

        }

        /* This will return the same as the Post call and redirect to the new form*/
        private async void CreateAccountButton_Click(object sender, EventArgs e)
        {
            UserAccount CreateInfo = new UserAccount();
            CreateInfo.email = TextBoxNewEmail.Text;
            CreateInfo.password = TextBoxCreatePassword.Text;
            CreateInfo.firstname = TextBoxFirstName.Text;
            CreateInfo.lastname = TextBoxLastName.Text;
            try
            {
                var NewAccountJSON = new JavaScriptSerializer().Serialize(CreateInfo);
                var response = await client.PutAsync("http://localhost:3000/Auth",
                    new StringContent(NewAccountJSON, Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    TextBoxNewEmail.Text = "Opps something when wrong";
                }
            }
            catch(Exception HTTPexcpt)
            {
                LabelLoginError.Text = HTTPexcpt.Message;
            }
        }
        
        /*Buttons that dont Communicate with the server*/
        private void CreatePanelSwitchButton_Click(object sender, EventArgs e)
        {
            PanelLogin.Visible = false;
            PanelCreateAccount.Visible = true;
        }

        private void SwitchToLoginPanel_Click(object sender, EventArgs e)
        {
            PanelLogin.Visible = true;
            PanelCreateAccount.Visible = false;
        }

        //For moving the background by touching it
        private void BackGroundMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void BackGroundMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void BackGroundMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /*Putting in default values into textboxes that empty and refill as nesscarry*/
        private void TextBoxClick(object sender, EventArgs e)
        {
            if (((TextBox)sender).ForeColor != Color.Gray)
            {
                return;
            }

            switch (((TextBox)sender).Name)
            {
                case "TextBoxPassword":
                    ((TextBox)sender).PasswordChar = '*';
                    break;
                case "TextBoxCreatePassword":
                    TextBoxCreatePassword.PasswordChar = '*';
                    break;
                case "TextBoxConfirmPassword":
                    TextBoxConfirmPassword.PasswordChar = '*';
                    break;

            }
            ((TextBox)sender).Clear();
            ((TextBox)sender).ForeColor = Color.Black;
            return;
        }
        
        private void ResetTextBox(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != String.Empty)
            {
                return;
            }
            string TextBoxName = ((TextBox)sender).Name;
            ((TextBox)sender).ForeColor = Color.Gray;
            switch(TextBoxName)
            {
                case "TextBoxUsername":
                    TextBoxLoginEmail.Text = "Email (email@example.com)";
                    break;
                case "TextBoxPassword":
                    TextBoxLoginPassword.Text = "Password";
                    TextBoxLoginPassword.PasswordChar = '\0';
                    break;
                case "TextBoxFirstName":
                    TextBoxFirstName.Text = "First Name";
                    break;
                case "TextBoxLastName":
                    TextBoxLastName.Text = "Last Name";
                    break;
                case "TextBoxNewEmail":
                    TextBoxNewEmail.Text = "Email (email@example.com)";
                    break;
                case "TextBoxCreatePassword":
                    TextBoxCreatePassword.Text = "Password";
                    TextBoxCreatePassword.PasswordChar = '\0';
                    TextBoxCreatePassword.BackColor = Color.FromArgb(227, 227, 227);
                    break;
                case "TextBoxConfirmPassword":
                    TextBoxConfirmPassword.Text = "Re-enter Password";
                    TextBoxConfirmPassword.PasswordChar = '\0';
                    TextBoxConfirmPassword.BackColor = Color.FromArgb(227, 227, 227);
                    break;
                default:
                    break;
            }
        }

        private void ButtonDownClick(object sender, EventArgs e)
        {
            string ButtonName = ((Button)sender).Name;
            switch (ButtonName)
            {
                case "ButtonLogin":
                    ButtonLogin.Image = Properties.Resources.LogInButtonClicked;
                    break;
                case "ButtonSwitchToCreatePanel":
                    ButtonSwitchToCreatePanel.Image = Properties.Resources.SwitchToCreatePanelButtonClicked;
                    break;
            }

        }
        private void ButtonRelease(object sender, EventArgs e)
        {
            string ButtonName = ((Button)sender).Name;
            switch (ButtonName)
            {
                case "ButtonLogin":
                    ButtonLogin.Image = Properties.Resources.LogInButton;
                    LoginButton_Click(sender, e);
                    break;
                case "ButtonSwitchToCreatePanel":
                    ButtonSwitchToCreatePanel.Image = Properties.Resources.SwitchToCreatePanelButton;
                    CreatePanelSwitchButton_Click(sender, e);
                    break;
                case "PanelSwitchToLogin":
                    SwitchToLoginPanel_Click(sender, e);
                    break;
            }
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            string TextBoxName = ((TextBox)sender).Name;

            switch (TextBoxName) {
                case "TextBoxCreatePassword":
                    if (!Regex.IsMatch(TextBoxCreatePassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$"))
                    {
                        TextBoxCreatePassword.BackColor = Color.FromArgb(255, 128, 128);
                        return;
                    }
                    TextBoxCreatePassword.BackColor = Color.FromArgb(128, 255, 128);
                    break;
                case "TextBoxConfirmPassword":
                    if(!(TextBoxCreatePassword.Text == TextBoxConfirmPassword.Text))
                    {
                        TextBoxConfirmPassword.BackColor = Color.FromArgb(255, 128, 128);
                        return;
                    }
                    TextBoxConfirmPassword.BackColor = Color.FromArgb(128, 225, 128);
                    break;
            }
        }
    }
}