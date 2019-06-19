using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenAuthentication.Models
{
    public class UserMasterRepository
    {
        //public void Dispose()
        //{

        //}

        // SECURITY_DBEntities it is your context class


        //This method is used to check and validate the user credentials
        public UserMaster ValidateUser(string username, string password)
        {
            // do validation here
            UserMaster user = new UserMaster();
            user.UserID = 1;
            user.UserName = "Gurgen";
            user.UserPassword = "test";
            user.UserRoles = new List<string>();
            user.UserRoles.Add("Admin");
            user.UserEmail = "test@gmail.com";
            return user;
        }


    }
}