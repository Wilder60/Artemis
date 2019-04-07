using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtemisDesktopClient
{
    partial class ArtemisMainPage
    {
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

    }
}
