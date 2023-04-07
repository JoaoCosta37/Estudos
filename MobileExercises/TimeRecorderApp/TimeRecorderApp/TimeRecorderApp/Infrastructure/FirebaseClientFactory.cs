using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeRecorderApp.Infrastructure
{
    public class FirebaseClientFactory : IFirebaseClientFactory
    {
        public FirebaseClient CreateClient()
        {
            var firebase = new FirebaseClient("https://timerecorder-f750c-default-rtdb.firebaseio.com/");
            return firebase;
        }
    }
}
