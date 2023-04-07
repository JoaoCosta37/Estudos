using System;
using System.Net;

namespace MyWebServer
{
    public interface IResponseFactory
    {
        ResponseHandler GetResponseHandler(String rootFolder, HttpListenerResponse resp, HttpListenerRequest req);
    }
}