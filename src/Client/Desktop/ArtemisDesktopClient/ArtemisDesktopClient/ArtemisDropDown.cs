using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtemisDesktopClient
{
    public partial class ArtemisMainPage
    {
        partial void ButtonKeyHookClick(object sender, EventArgs e)
        {
            PanelControl["KeyHook"].Show();
            PanelControl["KeyHook"].BringToFront();
            refreshKeyHookpage();
        }

        partial void Button2Click(object sender, EventArgs e)
        {
            this.PanelSideMenu.SendToBack();
        }

        partial void ButtonArtemisClick(object sender, EventArgs e)
        {
            this.PanelSideMenu.Hide();
            this.PanelArtemisVoice.Show();
            this.PanelArtemisVoice.BringToFront();
        }

        partial void ButtonAccountPanelSwitch(object sender, EventArgs e)
        {
            PanelControl["Settings"].Show();
            PanelControl["Settings"].BringToFront();
            Settingsinit();
        }

        partial void ButtonLogOutClick(object sender, EventArgs e)
        {
            Run = false;
            this.Owner.Show();
            this.Close();
        }
    }
}