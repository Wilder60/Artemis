using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtemisDesktopClient
{
    /// <summary>
    /// The partial class implentation of the SideMenu of the ArtemisMainPage
    /// </summary>
    public partial class ArtemisMainPage
    {
        /// <summary>
        /// The Click EventHandler for the ButtonHeyHook
        /// When clicked will bring up the KeyHook page
        /// </summary>
        /// <param name="sender">The button being clicked</param>
        /// <param name="e">The event args of the button click</param>
        /// <returns>
        /// void
        /// </returns>
        partial void ButtonKeyHookClick(object sender, EventArgs e)
        {
            PanelControl["KeyHook"].Show();
            PanelControl["KeyHook"].BringToFront();
            refreshKeyHookpage();
        }

        /// <summary>
        /// The Click EventHandler for the Button2
        /// When clicked will send the PanelSideMenu to the back of the form
        /// </summary>
        /// <param name="sender">The button that was being clicked</param>
        /// <param name="e">The EventArgs of the Button Click</param>
        /// <returns>
        /// void
        /// </returns>
        partial void Button2Click(object sender, EventArgs e)
        {
            this.PanelSideMenu.SendToBack();
        }

        /// <summary>
        /// The Click EventHandler for the SidePanelButton on the ArtemisMainPage
        /// This will show the sidepanel and move it the front of the panel
        /// </summary>
        /// <param name="sender">The button being clicked</param>
        /// <param name="e">The EventArgs of the Button that is Clicked</param>
        /// <returns>
        /// void
        /// </returns>
        partial void ButtonArtemisClick(object sender, EventArgs e)
        {
            this.PanelSideMenu.Hide();
            this.PanelArtemisVoice.Show();
            this.PanelArtemisVoice.BringToFront();
        }

        /// <summary>
        /// The Click EventHandler for the ButtonAccountPanel
        /// Will show the PanelAccountSettings and brint it to the front of the screen
        /// </summary>
        /// <param name="sender">The button being clicked</param>
        /// <param name="e">The EventArgs of the button click</param>
        /// <returns>
        /// void
        /// </returns>
        partial void ButtonAccountPanelSwitch(object sender, EventArgs e)
        {
            PanelControl["Settings"].Show();
            PanelControl["Settings"].BringToFront();
            Settingsinit();
        }

        /// <summary>
        /// The Click EventHandler for the ButtonLogOut
        /// Will stop the running thread and show the login panel
        /// </summary>
        /// <param name="sender">The Button being clicked</param>
        /// <param name="e">The EventArgs when the button is clicked</param>
        /// <returns>
        /// void
        /// </returns>
        partial void ButtonLogOutClick(object sender, EventArgs e)
        {
            Run = false;
            this.Owner.Show();
            this.Close();
        }
    }
}