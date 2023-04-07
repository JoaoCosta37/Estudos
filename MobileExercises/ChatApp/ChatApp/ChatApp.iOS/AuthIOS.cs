using ChatApp.Service;
using Firebase.Auth;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace ChatApp.iOS
{
    public class AuthIOS : IAuth
    {
        public string AuthUser => throw new NotImplementedException();

        public bool IsSignIn()
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return "";
            }

        }

        public bool SignOut()
        {
            throw new NotImplementedException();
        }

        public Task<string> SingUpWithEmailAndPasswordAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}