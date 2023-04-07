using ChatApp.Features;
using ChatApp.Infrastructure;
using Firebase.Database.Query;
using ChatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Utils;
using Firebase.Database;
using System.Linq;

namespace ChatApp.Service
{
    public class UserService : IUserService
    {
        private string fireBaseName = "Users";
        private readonly IFirebaseClientFactory firebaseClientFactory;

        public UserService(IFirebaseClientFactory firebaseClientFactory)
        {
            this.firebaseClientFactory = firebaseClientFactory;
        }
        public async Task CreateUserAsync(User newUser)
        {
            var userId = Hash.HashString(newUser.Id);
            try
            {
             var firebase = firebaseClientFactory.CreateClient();
             await firebase.Child(fireBaseName).Child(userId).PutAsync<User>(newUser);

            }
            catch(Exception e)
            {
                e.ToString();
            }
        }

        public User GetUser(string userId)
        {
            var firebase = firebaseClientFactory.CreateClient();
            var userIdHash = Hash.HashString(userId);
            try
            {
              var user = firebase.Child(fireBaseName).Child(userIdHash).OnceSingleAsync<User>().Result;
                return user ;
            }
            catch(Exception e)
            {
                e.ToString();
                throw;
            }
        }
    }
}
