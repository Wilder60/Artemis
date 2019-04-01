using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtemisDesktopClient
{
    class UserAccount
    {
        public UserAccount()
        {
            mastertoken = null;
            refreshtoken = null;
            email = null;
            password = null;
            firstname = null;
            lastname = null;
        }

        public IEnumerable<string> mastertoken { get; set; }
        public IEnumerable<string> refreshtoken { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
