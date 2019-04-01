using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtemisDesktopClient
{
    public partial class ArtemisMainPage
    {

        partial void button3_Click(object sender, EventArgs e)
        {
            this.PanelSideMenu.Show();
            this.PanelSideMenu.BringToFront();
        }

    }
}
