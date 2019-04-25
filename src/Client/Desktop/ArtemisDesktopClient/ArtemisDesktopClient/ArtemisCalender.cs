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

        public async void RefreshCalenderPage()
        {
            List<CalenderEvent> events = await GetAllEvents();
            ClearPanel();
            BuildCalender(events);
        }

        public void BuildCalender(List<CalenderEvent> events)
        {
            int OffSet = 0;
            DateTime Today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            long TodayUnix = ((DateTimeOffset)Today).ToUnixTimeSeconds();

            for (int i = 0; i < 31; i++)
            {
                Label LabelDay = new Label();
                PanelDynamicCalender.Controls.Add(LabelDay);
                LabelDay.Text = Today.Date.ToLongDateString();
                LabelDay.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
                LabelDay.BackColor = Color.FromArgb(28, 28, 28);
                LabelDay.ForeColor = Color.White;
                LabelDay.Width = 775;
                LabelDay.Height = 35;
                LabelDay.Location = new Point(0, OffSet);
                LabelDay.TextAlign = ContentAlignment.TopCenter;

                foreach (CalenderEvent CalEv in events)
                {
                    if (CalEv.alarmtime >= TodayUnix && CalEv.alarmtime < TodayUnix + 86400)
                    {
                        OffSet += 35;
                        Label LabelEvent = new Label();
                        PanelDynamicCalender.Controls.Add(LabelEvent);
                        LabelEvent.Cursor = Cursors.Hand;
                        LabelEvent.Text = CalEv.name;
                        LabelEvent.Tag = CalEv.id;
                        LabelEvent.TextAlign = ContentAlignment.MiddleCenter;
                        LabelEvent.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        LabelEvent.Width = 675;
                        LabelEvent.Height = 30;
                        LabelEvent.BackColor = Color.FromArgb(68, 68, 68);
                        LabelEvent.ForeColor = Color.White;
                        LabelEvent.Tag = CalEv;
                        LabelEvent.Click += new EventHandler(this.EditButton);
                        LabelEvent.Location = new Point(75, OffSet);
                    }
                }
                    
                OffSet += 70;
                Today = Today.AddDays(1);
                TodayUnix += 86400;
            }
        }

        public async Task<List<CalenderEvent>> GetAllEvents()
        {

            HttpRequestMessage PutRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://127.0.0.1:3000/Calender?id=" + _Account.id)
            };
            PutRequest.Headers.Add("Authorization", _AuthToken);
            try
            {
                var response = await _client.SendAsync(PutRequest);
                if (!response.IsSuccessStatusCode)
                {
                    //Print out Error
                    return new List<CalenderEvent>();
                }

                string UpcomingEvents = await response.Content.ReadAsStringAsync();
                return new JavaScriptSerializer().Deserialize<List<CalenderEvent>>(UpcomingEvents);
            }
            catch
            {
                //Print out Error
                return new List<CalenderEvent>();
            }
        }

        /// <summary>
        /// Clears the PanelDynamicCalender of all Controls inside of it
        /// And forces a redraw on the panel
        /// </summary>
        /// <returns>
        /// void
        /// </returns>
        public void ClearPanel()
        {
            foreach (Control item in PanelDynamicCalender.Controls)
            {
                item.Dispose();
            }
            PanelDynamicCalender.Controls.Clear();
            PanelDynamicCalender.Refresh();
        }

        public void CalenderMenuClick(object sender, EventArgs e)
        {
            PanelControl["SideMenu"].Show();
            PanelControl["SideMenu"].BringToFront();
        }

        public void ButtonNewEventClick(object sender, EventArgs e)
        {
            CreateCalenderEvent calenderEvent = new CreateCalenderEvent(_Account, _AuthToken);
            var result = calenderEvent.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                RefreshCalenderPage();
            }
        }

        public void EditButton(object sender, EventArgs e)
        {
            CreateCalenderEvent calenderEvent = new CreateCalenderEvent(_Account, _AuthToken, (CalenderEvent)((Label)sender).Tag);
            var result = calenderEvent.ShowDialog();
            if(result != DialogResult.Cancel)
            {
                RefreshCalenderPage();
            }
        }
    }
}
