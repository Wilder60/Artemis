using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtemisDesktopClient
{
    public class UserAccount
    {
        public string id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string pageStyle { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string updatepassword { get; set; }

        /// <summary>
        /// Default Constructor for the UserAccount
        /// This is needed for deserialization
        /// </summary>
        public UserAccount()
        {

        }

        /// <summary>
        /// Overloaded constructor for created a updated account
        /// </summary>
        /// <param name="account">The account to copy</param>
        public UserAccount(UserAccount account)
        {
            id = account.id;
            email = account.email;
            password = account.password;
            pageStyle = account.pageStyle;
            firstname = account.firstname;
            lastname = account.lastname;
            updatepassword = null;
        }

    }
}
