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
        public void RefreshCalenderPage()
        {
            BuildCalender();
        }

        public void BuildCalender()
        {
            DateTime now = DateTime.Now;
            for(int i = 0; i < 31; i++)
            {
                Label Day = new Label();
                PanelDynamicCalender.Controls.Add(Day);
                Day.Text = now.Date.ToLongDateString();
                Day.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
                Day.BackColor = Color.FromArgb(28, 28, 28);
                Day.ForeColor = Color.White;
                Day.Width = 775;
                Day.Height = 35;
                Day.Location = new Point(0, 0 + (i * 100));
                Day.TextAlign = ContentAlignment.TopCenter;
                now = now.AddDays(1);
            }
        }

        public void ClearPanel()
        {
            foreach (Control item in PanelDynamicCalender.Controls)
            {
                item.Dispose();
            }
            PanelDynamicCalender.Controls.Clear();
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
