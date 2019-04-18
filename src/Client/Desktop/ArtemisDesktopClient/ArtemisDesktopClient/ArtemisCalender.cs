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
    public partial class ArtemisMainPage
    {
        public void RestartPanel()
        {
            //make a get request to the server the return the list
        }



        public void CalenderMenuClick(object sender, EventArgs e)
        {
            PanelControl["SideMenu"].Show();
            PanelControl["SideMenu"].BringToFront();
        }

        public void ButtonNewEventClick(object sender, EventArgs e)
        {
            CreateCalenderEvent calenderEvent = new CreateCalenderEvent();
            calenderEvent.ShowDialog();
        }

    }
}
