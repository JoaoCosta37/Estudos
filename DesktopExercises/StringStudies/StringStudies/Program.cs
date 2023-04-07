using StringStudies.Converters;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace StringStudies
{
    internal class Program
    {
        private static void Main(string[] args)

        {
            //Console.WriteLine("Insira um texto");
            //string text = Console.ReadLine().Trim();

            string str1 = "Isso é um teste, portanto, teste";
            string str2 = "Esse é outro teste, portanto, ignore";

            //Console.WriteLine("Before");
            //Console.WriteLine();
            //Console.WriteLine(str1);
            //Console.WriteLine(str2);
            //Console.WriteLine();
            //var result = str1.Inverter(str2);
            //str1 = result[0];
            //str2 = result[1];
            //Console.WriteLine("After");
            //Console.WriteLine();
            //Console.WriteLine(str1);
            //Console.WriteLine(str2);

            IColor colorR = new Red();
            IColor colorY = new Yellow();

           Console.WriteLine($"{(colorR.GetType() == colorY.GetType())}");   




            //ITextConverter converter = new Captalize();
            //var result = converter.ConvertText(str1);
            //Console.WriteLine(result.Trim());


        }

    }
    public interface IColor 
    {
        string GetName();
    }
    public class Red : IColor
    {
        public string GetName()
        {
            return "RED";
        }
    }
    public class Yellow : IColor
    {
        public string GetName()
        {
            return "Yellow";
        }
    }

}
