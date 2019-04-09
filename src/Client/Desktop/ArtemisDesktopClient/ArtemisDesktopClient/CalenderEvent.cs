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
        public string eventID { get; set; }
        public string eventOwner { get; set; }
        public string eventName { get; set; }
        public string eventlocation { get; set; }
        public string EventLength { get; set; }
        public int AlarmTime { get; set; } 
	    public int AlarmOffset { get; set; }
	    public int NotifyTime { get; set; }
	    public bool WentOff { get; set; }
    }
}
