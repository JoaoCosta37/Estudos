using MyWebServer.DateTimeProviders;
using MyWebServer.Config;
using MyWebServer.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Configs.SetConfig(new GetConfig());
            CurrentTime.SetProvider(new SystemCurrentTimeProvider());
            
            IResponseFactory responseFactory = new ResponseFactory();
            ILoggerFactory loggerFactory = new LoggerFactory();


            HttpServer server = new HttpServer(responseFactory,loggerFactory);
            server.StartListener();


            //Usando o StreamReader

            //String line;
            //try
            //{
            //    //Pass the file path and file name to the StreamReader constructor
            //    StreamReader sr = new StreamReader("C:\\Users\\Joaoc\\Documents\\GitHub\\DesktopExercises\\MyWebServer\\config.txt");
            //    //Read the first line of text
            //    line = sr.ReadLine();
            //    //Continue to read until you reach end of file
            //    while (line != null)
            //    {
            //        //write the line to console window
            //        Console.WriteLine(line);
            //        //Read the next line
            //        line = sr.ReadLine();
            //    }
            //    //close the file
            //    sr.Close();
            //    Console.ReadLine();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception: " + e.Message);
            //    Console.ReadLine();
            //}
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}

            //Usabdo o StreamWrite

            //try
            //{
            //    //Pass the filepath and filename to the StreamWriter Constructor
            //    StreamWriter sw = new StreamWriter("C:\\Users\\Joaoc\\Documents\\GitHub\\DesktopExercises\\MyWebServer\\log.txt");
            //    //Write a line of text
            //    sw.WriteLine("Hello World!!");
            //    //Write a second line of text
            //    //sw.WriteLine("From the StreamWriter class");
            //    //Close the file
            //    sw.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception: " + e.Message);
            //    Console.ReadLine();
            //}
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}

            //Int64 x;
            //try
            //{
            //    //Open the File
            //    StreamWriter sw = new StreamWriter("C:\\Users\\Joaoc\\Documents\\GitHub\\DesktopExercises\\MyWebServer\\log.txt", true, Encoding.UTF8);

            //    //Write out the numbers 1 to 10 on the same line.
            //    for (x = 0; x < 10; x++)
            //    {
            //        sw.Write(x);
            //    }

            //    //close the file
            //    sw.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception: " + e.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}

        }

    }
}
