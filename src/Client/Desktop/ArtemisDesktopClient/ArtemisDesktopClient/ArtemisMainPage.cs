using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtemisDesktopClient
{
    /// <summary>
    /// This part of the class is the main page and the voice page for Artemis
    /// </summary>
    public partial class ArtemisMainPage : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        internal Dictionary<string, Panel> PanelControl;
        /// <summary>
        /// This is the constructor for the main page of the app
        /// fills the PanelControl
        /// </summary>
        public ArtemisMainPage()
        {
            InitializeComponent();
            this.PanelControl = new Dictionary<string, Panel>();
            PanelControl["SideMenu"] = PanelSideMenu;
            PanelControl["Voice"] = PanelArtemisVoice;
            PanelControl["Settings"] = PanelAccountSettings;
            PanelControl["KeyHook"] = PanelKeyHook;

            this.PanelAccountSettings.Hide();
            this.PanelKeyHook.Hide();
            this.PanelSideMenu.Hide();
            this.PanelArtemisVoice.Show();
        }

        partial void ButtonArtemisClick(object sender, EventArgs e);
        partial void Button2Click(object sender, EventArgs e);
        partial void button3_Click(object sender, EventArgs e);
        partial void ButtonKeyHookClick(object sender, EventArgs e);
        partial void ButtonLogOutClick(object sender, EventArgs e);
        partial void ButtonAccountPanelSwitch(object sender, EventArgs e);
        partial void button4_Click(object sender, EventArgs e);

        /// <summary>
        /// When the mouse is pressed down, gets the last location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackGroundMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        /// <summary>
        /// When the mouse is moved and the MouseDown is true update the location of the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// When the mouse is released is stops the app from updating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackGroundMouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /// <summary>
        /// When is this clicked it will bring up the SideMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1Click(object sender, EventArgs e)
        {
            PanelControl["SideMenu"].Show();
            PanelControl["SideMenu"].BringToFront();
        }
    }
}
