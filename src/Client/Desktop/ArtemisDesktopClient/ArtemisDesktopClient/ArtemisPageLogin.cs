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
    /// <summary>
    /// The Functionallity for the Login Page.
    /// Allows the user to create a new account or login to an existing one.
    /// </summary>
    public partial class ArtemisPageLogin : Form
    {
        /// <value>HttpClient for connection to the server.</value>
        private static HttpClient client;
        /// <value>To determine if the mouse left click is down.</value>
        private bool mouseDown;
        /// <value>The last location of the mouse.</value>
        private Point lastLocation;

        public ArtemisPageLogin()
        {
            InitializeComponent();
            PanelLogin.Visible = true;
            PanelCreateAccount.Visible = false;
        }

        /// <summary>
        /// OnLoad function for this form.
        /// </summary>
        /// <remarks>
        /// This initiazes the HttpClient object and Adds the two panels into a dictionary.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void ArtemisDesktop_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
        }

        /// <summary>
        /// OnClick listener for the LoginButton.
        /// Makes a call the backend. Will open the mainpage form if login was successful.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
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
                    LabelLoginError.Text = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    IEnumerable<string> Token;
                    response.Headers.TryGetValues("MasterToken", out Token);
                    string name = await response.Content.ReadAsStringAsync();
                    UserAccount account = new JavaScriptSerializer().Deserialize<UserAccount>(name);
                    ArtemisMainPage MainPage = new ArtemisMainPage(Token, account);
                    this.Hide();
                    MainPage.Show(this);
                    resetLogin();
                }
            }
            catch (Exception HTTPexcpt)
            {
                LabelLoginError.Text = HTTPexcpt.Message;
            }

        }

        /// <summary>
        /// Resets the TextBoxLoginEmail and
        /// TextBoxLoginPassword fields into there default values
        /// </summary>
        private void resetLogin()
        {
            TextBoxLoginEmail.Text = "Email (email@example.com)";
            TextBoxLoginEmail.ForeColor = Color.Gray;
            TextBoxLoginPassword.Text = "Password";
            TextBoxLoginPassword.PasswordChar = '\0';
            TextBoxLoginPassword.ForeColor = Color.Gray;
        }

        /// <summary>
        /// OnClick Listener for the CreateAccountButton
        /// Makes a PUT request to the server with the information
        /// entered into the TextBoxes
        /// </summary>
        /// <remarks>
        /// I NEED TO ADD MORE ERROR CHECKING INTO THIS
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
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

                if (response.IsSuccessStatusCode)
                {
                    PanelLogin.BringToFront();
                }
                else
                {
                    TextBoxNewEmail.Text = "Opps something when wrong";
                }
                
            }
            catch(Exception HTTPexcpt)
            {
                LabelLoginError.Text = HTTPexcpt.Message;
            }
        }
        
        /// <summary>
        /// Will change the panel on the front on the screen
        /// to PanelCreateAccount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void CreatePanelSwitchButton_Click(object sender, EventArgs e)
        {
            PanelLogin.Visible = false;
            PanelCreateAccount.Visible = true;
        }

        /// <summary>
        /// Will change the panel on the front on the screen
        /// to PanelLogin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void SwitchToLoginPanel_Click(object sender, EventArgs e)
        {
            PanelLogin.Visible = true;
            PanelCreateAccount.Visible = false;
        }

        /// <summary>
        /// OnClick Listener for mousedown
        /// Is used with BackGroundMouseMove and BackGroundMouseUp to move the screen around
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void BackGroundMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        /// <summary>
        /// OnClick Listener for MouseMove
        /// this will redraw the form when the mouse is moved to a new location
        /// if mouseDown is set to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void BackGroundMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        /// <summary>
        /// OnClick Listener for MouseUp
        /// Is used with BackGroundMouseMove and BackGroundMouseDown to move the screen around
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void BackGroundMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /// <summary>
        /// This will clear the textbox of any default text and
        /// change the font color to black
        /// </summary>
        /// <param name="sender">The textBox that the user click on</param>
        /// <param name="e"></param>
        /// <returns>
        /// </returns>
        private void TextBoxClick(object sender, EventArgs e)
        {
            if (((TextBox)sender).ForeColor != Color.Gray)
            {
                return;
            }

            switch (((TextBox)sender).Name)
            {
                case "TextBoxLoginPassword":
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
        
        /// <summary>
        /// LostFocus EventHandler.
        /// If the textBox is empty when it loses focus it will restore it to default text.
        /// </summary>
        /// <param name="sender">The textBox that loses focus</param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
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
                case "TextBoxLoginEmail":
                    TextBoxLoginEmail.Text = "Email (email@example.com)";
                    break;
                case "TextBoxLoginPassword":
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

        /// <summary>
        /// DownClick Eventhandler for all buttons.
        /// When a button is clicked it will show an alternate version.
        /// </summary>
        /// <param name="sender">The Button that is being Clicked</param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
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

        /// <summary>
        /// ClickRelease Eventhandler for all imagebuttons.
        /// When the button is release the original image will be restored.
        /// </summary>
        /// <param name="sender">button being released</param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
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

        /// <summary>
        /// TextChanged Eventhandler for the TextBoxCreatePassword and TextBoxConfirmPassword
        /// if TextBoxCreatePassword will check if the password is valid
        /// if TextBoxConfirmPassword will check if the two password boxes are the same
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>
        /// void
        /// </returns>
        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            string TextBoxName = ((TextBox)sender).Name;

            switch (TextBoxName) {
                case "TextBoxCreatePassword":
                    //this is ugly
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