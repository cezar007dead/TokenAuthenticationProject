using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenAuthentication.Models
{
    public class UserMaster
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }
        public List<string> UserRoles { get; set; }

        public string UserEmail { get; set; }
    }
}