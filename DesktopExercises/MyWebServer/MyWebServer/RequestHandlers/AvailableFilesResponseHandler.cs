using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class AvailableFilesResponseHandler : ResponseHandler
    {

        private readonly string availableFilePath = @"DefaultPages\available-files.html";
        private readonly string rootFolder;

        public AvailableFilesResponseHandler(HttpListenerResponse resp, string requestedResource, string rootFolder) : base(resp, requestedResource)
        {
            this.rootFolder = rootFolder;
        }

        public override void SendResponse()
        {
            var availableFileContent = UpdateAvailableFile();
            MemoryStream ms = new MemoryStream();
            ms.Write(UTF8Encoding.UTF8.GetBytes(availableFileContent), 0, availableFileContent.Length);
            ms.Position = 0;

            using (BinaryReader br = new BinaryReader(ms))
            {
                writeResponse(br);
            }

        }

        public string UpdateAvailableFile()
        {
            var files = from file in Directory.EnumerateFiles(rootFolder)
                        where file.EndsWith(".html")
                        select $"</br><a href='{Path.GetFileName(file)}'> {Path.GetFileNameWithoutExtension(file)} </a>";

            var strFiles = String.Join("", files);
            var availableFileContent = File.ReadAllText(availableFilePath);
            availableFileContent = availableFileContent.Replace("#FILE_LIST#", strFiles);

            return availableFileContent;
        }
    }
}
