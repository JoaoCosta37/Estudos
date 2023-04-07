using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        bool SignOut();
        bool IsSignIn();
        Task<string> SingUpWithEmailAndPasswordAsync(string email, string password);
        string AuthUser { get; }
    }
}
