using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtemisDesktopClient
{
    public class UserAccount
    {
        public UserAccount()
        {
        }
        
        public string id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string pageStyle { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
