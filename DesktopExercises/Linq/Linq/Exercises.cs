using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Exercises
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

        public Exercises()
        {

        }

        public void Exercise1(IList<Student> studentList)
        {
            var resultQuery = (from student in studentList
                              where student.StandardID == 2
                              select student);

            var resultMethod = studentList.Where(s => s.StandardID == 2);

        }
        public void Exercise2(IList<Student> studentList)
        {
            var resultQuery = from student in studentList
                              where student.StudentName.ToUpper().First() == 'R'
                              select student;

            var resultMethod = studentList.Where(s => s.StudentName.ToUpper().First() == 'R');


        }
        public void Exercise3(IList<Student> studentList)
        {
            // 3 Agrupar todos os estudantes por StandardId e exibir o StandardId e em seguida os estudantes daquele grupo

            var resultQuery = from student in studentList
                              group student by student.StandardID;

            foreach (var result in resultQuery)
            {
                Console.WriteLine(result.Key);
                foreach (var r in result)
                {
                    Console.WriteLine(r.StudentName);
                }
            }

            var resultMethod = studentList.GroupBy(s => s.StandardID);


            foreach (var result in resultMethod)
            {
                Console.WriteLine(result.Key);
                foreach (var r in result)
                {
                    Console.WriteLine(r.StudentName);
                }
            }

        }

        public void Exercise4(IList<Student> studentList)
        {
            // 4 Selecionar o nome e o StudentId de todos os estudantes cuja idade seja maior ou igual a 20

            var resultQuery = from student in studentList
                              where student.Age >= 20
                              select new { Name = student.StudentName, Id = student.StudentID };

            var resultMethod = studentList.Where(s => s.Age >= 20).Select(s => new { Name = s.StudentName, Id = s.StudentID });

        }

        public void Exercise5(IList<Student> studentList)
        {
            // 5 Agrupar todos os estudantes por Age e StandardId e exibir o nome, age e StandardId de todos os estudantes daquele grupo

            var resultQuery = from student in studentList
                              let condition = new { Age = student.Age, StandardId = student.StandardID }
                              group student by condition;
            //select new {Name = student.StudentName, Age = student.Age, StandardID = student.StandardID};

            foreach (var group in resultQuery)
            {
                Console.WriteLine($"{group.Key.Age} - {group.Key.StandardId}");
                foreach (var student in group)
                {
                    Console.WriteLine($"{student.StudentName} - {student.Age} - {student.StandardID}");
                }
            }
            var resultMethod = studentList.GroupBy(s => new { Age = s.Age, StandardId = s.StandardID });
            foreach (var group in resultMethod)
            {
                Console.WriteLine($"{group.Key.Age} - {group.Key.StandardId}");
                foreach (var student in group)
                {
                    Console.WriteLine($"{student.StudentName} - {student.Age} - {student.StandardID}");
                }
            }

        }
        public void Exercise6(IList<Student> studentList)
        {
            // 6 Selecionar o primeiro estudande com idade menor que 20 anos;

            var resultMethod = studentList.First(s => s.Age < 20);

            Console.WriteLine(resultMethod.StudentName);

        }
        public void Exercise7(IList<Student> studentList)
        {
            // 7 Selecionar o nome e o StudentID do último estudante com idade maior que 20 anos;
            var resultMethod = studentList.Where(x => x.Age > 20).Select(s => new { Name = s.StudentName, StudentId = s.StudentID }).Last();

            
            Console.WriteLine(resultMethod);

        }
        public void Exercise8(IList<Student> studentList)
        {
            // 8 Selecionar o StandardId do estudante na posição 3;
            var resultMethod = studentList.ElementAt(3).StudentName;


            Console.WriteLine(resultMethod);

        }
        public void Exercise9(IList<Student> studentList)
        {
            // 9 Descartar os 2 primeiros estudantes e selecionar o nome e a idade dos próximos estudantes.
            var resultMethod = studentList.Skip(2).Select(s => new { Name = s.StudentName, Age = s.Age });

            foreach (var student in resultMethod)
            {
                Console.WriteLine($"Nome: {student.Name}\nIdade: {student.Age}\n ");
            }

        }
        public void Exercise10()
        {
            // 10 Selecionar de uma string qualquer apenas os caracterres que são números.
            //Ps: Toda string pode sert convertida num array de char.
            //ps: Pesquisar o método da classe Char que verifica se um caracter é número.

            string exercise = "Um4 str1ng qu4lquer";

            var numbersInString = exercise.Where(x => char.IsDigit(x));

            foreach (var caracters in numbersInString)
            {
                Console.WriteLine(caracters);
            }

        }
        public void Exercise11()
        {
            // 11 Selecionar de uma string Qualquer apenas os caracteres que não são especiais.

            string exercise = "Um4 &tr1ng qu4lquer";

            //var stringWithoutSpecial = charArray.Where(x => char.IsSymbol(x) == false);

            //foreach (var caracters in stringWithoutSpecial)
            //{
            //    Console.WriteLine(caracters);
            //}

            var result = exercise.Where(x => char.IsLetterOrDigit(x) || char.IsWhiteSpace(x));

            //StringBuilder stringWithoutSpecial = new StringBuilder();

            //for (int i = 0; i < exercise.Length; i++)
            //{
            //    if (char.IsLetterOrDigit(exercise[i]) || char.IsWhiteSpace(exercise[i]))
            //    {
            //        stringWithoutSpecial.Append(exercise[i]);
            //    }
            //}

            Console.WriteLine(new String(result.ToArray()));
            //Console.WriteLine(stringWithoutSpecial);
        }
    }
}
