using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public interface IStorageService
    {
        Task<string> SendFile(MemoryStream fileContent, string fileName);
    }
}
