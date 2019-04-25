using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtemisDesktopClient
{
    public class CalenderEvent
    {
        public CalenderEvent()
        {

        }
        public string id { get; set; }
        public string owner { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string length { get; set; }
        public string startdate { get; set; }
        public string starttime { get; set; }
        public string enddate { get; set; }
        public string endtime { get; set; }
        public string alarmbase { get; set; }
        public string alarmiter { get; set; }
        public long alarmtime { get; set; } 
	    public int alarmoffset { get; set; }
	    public int notifytime { get; set; }
	    public bool wentoff { get; set; }
    }
}
