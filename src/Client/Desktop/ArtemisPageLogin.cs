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
    //TODO: need to add that passwords are valid
    /*
     * They are atleast 8 characters long
     * use regex for that
     * They contain one number and on uppercase and one lowercase
     * Shrink the icon a little bit
     */
    public partial class ArtemisPageLogin : Form
    {
        public ArtemisPageLogin()
        {
            InitializeComponent();
            LogInPanel.Visible = true;
            CreateAccountPanel.Visible = false;
        }

        private static HttpClient client;
        private bool mouseDown;
        private Point lastLocation;
        
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

            Dictionary<string, string> Login = new Dictionary<string, string>();
            Login.Add("EMAIL", UsernameTextbox.Text);
            Login.Add("PASSWORD", PasswordTextBox.Text);

            var json = new JavaScriptSerializer().Serialize(Login);

            /*var response = await client.PostAsync("http://localhost:3000/Auth",
                new StringContent(json, Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
            {
                UsernameTextbox.Text = response.ReasonPhrase;
            }
            else
            {
                IEnumerable<string> Token;
                response.Headers.TryGetValues("Token", out Token);
                UsernameTextbox.Text = string.Join("", Token);
            }*/
            Login.Clear();
        }

        /* This will return the same as the Post call and redirect to the new form*/
        private async void CreateAccountButton_Click(object sender, EventArgs e)
        {
            var values = new Dictionary<string, string>();
            values["EMAIL"] = CEmailTextBox.Text;
            values["PASSWORD"] = CPasswordTextBox.Text;
            values["FIRSTNAME"] = FirstNameTextBox.Text;
            values["LASTNAME"] = LastNameTextBox.Text;

            var json = new JavaScriptSerializer().Serialize(values);

            var response = await client.PutAsync("http://localhost:3000/Auth",
                new StringContent(json, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                CEmailTextBox.Text = "Opps something when wrong";
            }
            values.Clear();
        }
        
        /*Buttons that dont Communicate with the server*/
        private void CreatePanelSwitchButton_Click(object sender, EventArgs e)
        {
            LogInPanel.Visible = false;
            CreateAccountPanel.Visible = true;
        }

        private void SwitchToLoginPanel_Click(object sender, EventArgs e)
        {
            LogInPanel.Visible = true;
            CreateAccountPanel.Visible = false;
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
            if (((TextBox)sender).Name == "PasswordTextBox")
            {
                ((TextBox)sender).PasswordChar = '*';
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
                case "UsernameTextbox":
                    UsernameTextbox.Text = "Email (email@example.com)";
                    break;
                case "PasswordTextBox":
                    PasswordTextBox.Text = "Password";
                    PasswordTextBox.PasswordChar = '\0';
                    break;
                case "FirstNameTextBox":
                    FirstNameTextBox.Text = "First Name";
                    break;
                case "LastNameTextBox":
                    LastNameTextBox.Text = "Last Name";
                    break;
                case "CEmailTextBox":
                    CEmailTextBox.Text = "Email (email@example.com)";
                    break;
                case "CPasswordTextBox":
                    CPasswordTextBox.Text = "Password";
                    break;
                case "ConfirmPasswordTextBox":
                    ConfirmPasswordTextBox.Text = "Re-enter Password";
                    break;
                default:
                    break;
            }
                
        }
    }
}

