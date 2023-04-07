using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public class StorageService : IStorageService
    {
        public async Task<string> SendFile(MemoryStream fileContent, string fileName)
        {
            var task = new FirebaseStorage(
                           "chatapp-321b5.appspot.com",

                            new FirebaseStorageOptions
                            {
                                ThrowOnCancel = true,
                            })
                           .Child("Chats")
                           .Child(fileName)
                           .PutAsync(fileContent);

            var downloadUrl = await task;
            return downloadUrl;
        }
    }
}
