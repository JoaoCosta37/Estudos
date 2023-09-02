using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ListStudies
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            testEnum();
            void ediçãoLista()
            {
                var list = new List<int> { 10, 20, 30, 40, 50, 60 };
                for (var i = 0; i < list.Count(); i++)
                {
                    Console.WriteLine(list[i]);
                }

                Console.WriteLine("______________________________");


                var test = list;

                test[0] = 20;

                for (var i = 0; i < list.Count(); i++)
                {
                    Console.WriteLine(list[i]);
                }

                Console.WriteLine("______________________________");


                //var item = list[5];
                //list.Remove(list[5]);
                //list.Insert(0, item);
                //printNewList(list);
                //void printNewList(List<int> newlist)
                //{
                //    newlist[2] = 55;
                //    Console.WriteLine(newlist[2]);
                //}

                Console.WriteLine("______________________________");

                //for (var i = 0; i < list.Count(); i++)
                //{
                //    Console.WriteLine(list[i]);
                //}

                for (var i = 0; i < test.Count(); i++)
                {
                    Console.WriteLine(test[i]);
                }
            }
            void testEnum()
            {
                int geladeira =  Moveis.Geladeira.GetRa;
                Console.WriteLine(geladeira);   
            }
        }
        public enum Moveis
        {
            Geladeira,
            Armario,
            Tv,
            Comoda
        }
    }
}
