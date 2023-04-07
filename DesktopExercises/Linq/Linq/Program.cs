using Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Linq
{
    //Consultas usando as duas sintaxes

    // 1 Filtrar todos os estudantes que tem StandardId 2
    // 2 Filtrar todos os estudantes que começam com a letra R
    // 3 Agrupar todos os estudantes por StandardId e exibir o StandardId e em seguida os estudantes daquele grupo
    // 4 Selecionar o nome e o StudentId de todos os estudantes cuja idade seja maior ou igual a 20
    // 5 Agrupar todos os estudantes por Age e StandardId e exibir o nome, age e StandardId de todos os estudantes daquele grupo

    //Consulta apenas utilizando Method Syntax

    // 6 Selecionar o primeiro estudande com idade menor que 20 anos;
    // 7 Selecionar o nome e o StudentID do ´pultimo estudante com idade maior que 20 anos;
    // 8 Selecionar o StandardId do estudante na posição 3;
    // 9 Descartar os 2 primeiros estudantes e selecionar o nome e a idade dos próximos estudantes.
    // 10 Selecionar de uma string qualquer apenas os caracterres qye são números.
    //Ps: Toda string pode sert convertida num array de char.
    //ps: Pesquisar o método da classe Char que verifica se um caracter é número.
    // 11 Selecionar de uma string Qualquer apenas os caracteres que não são especiais.

    public class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int Age { get; set; }

        public int StandardID { get; set; }
    }

    public class People
    {
        public String Name { get; set; }
    }

    public class StudentViewModel
    {
        private readonly Student student;

        public StudentViewModel(Student student)
        {
            this.student = student;
        }
        public int StudentID
        {
            get
            {
                return student.StudentID;
            }

            set
            {
                student.StudentID = value;
            }
        }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {
    new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
    new Student() { StudentID = 5, StudentName = "Ron" , Age = 21, StandardID = 1 }
};


            //var prop = typeof(Student).GetProperty("StudentName", BindingFlags.Instance | BindingFlags.Public);

            //Console.WriteLine(prop.GetValue(studentList[1]));


            //Exercises exercises = new Exercises();
            //exercises.Exercise3(studentList);
            //exercises.Exercise11();

            string str = "Uma String Qualquer";
            //var result = str.Right(2);
            //var result2 = str.DeleteLast(3);
            //var result3 = str.Reverter();

            Helper.Get("http://localhost:8000/index.html", (data) =>
            {
                Console.WriteLine(data);
            });


            Console.ReadLine();


           //Task t =  ExtensionMethod.Play();
            //t.Wait();

            var result5 = Last.LastItem(str,x => char.IsUpper(x));

            //Console.WriteLine(result5);

            IList<Standard> standardList = new List<Standard>() {
    new Standard(){ StandardID = 1, StandardName="Standard 1"},
    new Standard(){ StandardID = 2, StandardName="Standard 2"},
    new Standard(){ StandardID = 3, StandardName="Standard 3"} };
            // WhereSample(studentList);

            // OrderBySample(studentList);
            // SelectSample(studentList);
            // print(new { Nome = "João" });

            // GroupSample(studentList);

            //MiscMethodsSample(studentList);
            //LetSample(studentList);

        }

        private static void LetSample(IList<Student> studentList)
        {
            var lowercaseStudentNames = from s in studentList
                                        where s.StudentName.ToLower().EndsWith("r")
                                        select s.StudentName.ToLower();


            var lowercaseStudentNames2 = from s in studentList
                                         let lowercaseStudentName = s.StudentName.ToLower()
                                         where lowercaseStudentName.StartsWith("r")
                                         select lowercaseStudentName;
        }

        private static void MiscMethodsSample(IList<Student> studentList)
        {
            var student = studentList.First(x => x.Age > 20);

            //            var studentInexistent = studentList.First(x => x.Age > 50); var dar erro

            studentList.FirstOrDefault(x => x.Age > 50); // vai retornar null

            // vai pegar os n  primeiro elementos
            studentList.Take(3);


            //vai pular os n primeiros elementos e retornar o resto
            studentList.Skip(3);


            // pega da pagina 2
            studentList.Skip(2).Take(2);
        }

        private static void GroupSample(IList<Student> studentList)
        {
            var groups = from s in studentList
                         group s by s.Age;

            foreach (var ageGroup in groups.Where(x => x.Count() > 1))
            {
                Console.WriteLine("Age Group: {0}", ageGroup.Key); //Each group has a key 

                foreach (Student s in ageGroup) // Each group has inner collection
                    Console.WriteLine("Student Name: {0}", s.StudentName);
            }
        }

        private static void SelectSample(IList<Student> studentList)
        {
            var selectResult = from s in studentList
                               select s.StudentName;

            foreach (var name in selectResult)
            {
                Console.WriteLine(name.ToUpper());
            }

            // Tipo anonimo - unspeakable name 
            var selectNameAgeResult = from s in studentList
                                      select new { Name = s.StudentName, Age = s.Age };

            foreach (var s in selectNameAgeResult)
            {
                Console.WriteLine(s.Name + " - " + s.Age.ToString());
            }


            studentList.Select(s => new { Name = s.StudentName, Age = s.Age });

            var studentViewModel = studentList.Select(x => new StudentViewModel(x));

            var peopleList = studentList.Select(x => new People() { Name = x.StudentName });

            List<People> people = new List<People>();
            foreach (var s in studentList)
            {
                people.Add(new People() { Name = s.StudentName });
            }

            var wrongPeopleList = studentList.Select(x => new People());




        }


        private static void print(object o)
        {

        }

        private static void OrderBySample(IList<Student> studentList)
        {
            var orderByResult = from s in studentList
                                orderby s.StudentName
                                select s;

            foreach (var s in orderByResult)
            {
                Console.WriteLine(s.StudentName);
            }


            var orderByDescendingResult = from s in studentList
                                          orderby s.StudentName descending
                                          select s;

            var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName);


            foreach (var s in studentsInDescOrder)
            {
                Console.WriteLine(s.StudentName);
            }

            //var orderByResult = studentList.OrderBy(x => x.StudentName);
        }

        private static void WhereSample(IList<Student> studentList)
        {
            ///WHERE

            var teenAgerStudent = from s in studentList
                                  where s.Age > 12 && s.Age < 20
                                  select s;


            //var teenAgerStudent = studentList.Where(s => s.Age > 12 && s.Age < 20);


            //var teenAgerStudent = studentList.Where(s => s.Age > 12).Where(s => s.Age < 20);


            //List<Student> teenAgerStudent = new List<Student>();
            //foreach (var s in studentList)
            //{
            //    if (s.Age > 12 && s.Age < 20)
            //    {
            //        teenAgerStudent.Add(s);
            //    }
            //}


            foreach (var s in teenAgerStudent)
            {
                Console.WriteLine(s.StudentName);
            }
        }



    }
}
