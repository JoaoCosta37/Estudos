using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeRecorderApp.Infrastructure
{
    public interface IFirebaseClientFactory
    {
        FirebaseClient CreateClient();
    }
}
