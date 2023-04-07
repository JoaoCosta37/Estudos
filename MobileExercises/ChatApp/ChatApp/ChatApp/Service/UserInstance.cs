using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Service
{
    public class UserInstance
    {
        private static IUserProvider instance;
        public static User GetUser()
        {
          return instance.GetUser();
        }
        public static void SetUser(IUserProvider userProvider)
        {
            if(instance == null)
            {
                instance = userProvider;
            }
        }
    }
}
