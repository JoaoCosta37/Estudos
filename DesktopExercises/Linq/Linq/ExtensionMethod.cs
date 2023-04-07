using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq
{
    public class ExtensionMethod
    {
        public static async Task Play()
        {
            IList<Student> studentList = new List<Student>() {
    new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
    new Student() { StudentID = 5, StudentName = "Ron" , Age = 21, StandardID = 1 }
};


            studentList.Where(x => x.Age > 10);

            studentList.Where(delegate (Student s)
            {
                return s.Age > 10;
            });


            CustomLinq.Where(studentList, HasAgeGreatherThen10);

            PrintInGreen(() => Console.WriteLine("Isso é um teste"));

            //var tempo = ExecutarMedindoTempo(() =>
            // {
            //     int acum = 0;
            //     foreach (var n in Enumerable.Range(1, 1000000))
            //         acum += n;

            //     Thread.Sleep(2000);
            //     Console.WriteLine(acum);
            // });

            //  Console.WriteLine(tempo);

            HttpClient httpClient = new HttpClient();

            var tempo2 = await ExecutarMedindoTempo(async () =>
            {
                // clojure --- enclausurando --- encerrando

                var lat = "-23.5186701";
                var lng = "-46.7742587";

                string url = $"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lng}&appid=32778d2194488f1295d68287590fbc76&lang=pt_br&units=metric&exclude=minutely,daily,hourly";

                try
                {
                    var response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            });

            Console.WriteLine(tempo2);
            // Método de extensão ;;; extension method




        }

        public static async Task<TimeSpan> ExecutarMedindoTempo(Func<Task> action)
        {
            var begin = DateTime.Now;
            await action();

            var end = DateTime.Now;

            return end.Subtract(begin);
        }

        public static void PrintInGreen(Action printAction)
        {
            var prevColor = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.Green;
            printAction();
            Console.BackgroundColor = prevColor;
        }

        static bool HasAgeGreatherThen10(Student s)
        {
            return s.Age > 10;
        }
    }
}
