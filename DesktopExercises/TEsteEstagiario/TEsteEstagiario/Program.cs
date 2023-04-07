using System;
using System.Collections.Generic;

namespace TesteEstagiario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FizzBozz();
            // Multiplo();
            AtividadeEscola();
            //ArrayVsList();
        }
        static void FizzBozz()
        {
            int numero = 1000;
            string resultado = "";
            Console.WriteLine("0");

            for(int i = 1; i < numero; i++)
            {
                resultado = i.ToString();
                if (i % 3 == 0)
                    resultado = "Fizz ";
                if (i % 5 == 0)
                    resultado += "Bozz";

                Console.WriteLine(resultado);
            }

                Console.WriteLine(resultado);

                //if (i%3 == 0 & i%5 == 0)
                //    Console.WriteLine("Fizz Buzz");
                //else if(i%3 == 0)
                //    Console.WriteLine("Fizz");
                //else if (i % 5 == 0)
                //    Console.WriteLine("Buzz");
                //else Console.WriteLine(i);
            //}

        }
        static void Multiplo()
        {
            decimal primeiroNumero = Convert.ToDecimal(Console.ReadLine());
            decimal segundoNumero = Convert.ToDecimal(Console.ReadLine());

            //primeiroNumero = primeiroNumero < 0 ? primeiroNumero - primeiroNumero - primeiroNumero : primeiroNumero;
            //segundoNumero = segundoNumero < 0 ? segundoNumero - segundoNumero - segundoNumero : segundoNumero;

                bool teste = TesteMultiplo(primeiroNumero, segundoNumero);

            if (teste==true)
                Console.WriteLine($"O número {primeiroNumero} é múltiplo do {segundoNumero} ");
            else
                Console.WriteLine($"O número {primeiroNumero} NÃO é múltiplo do {segundoNumero} ");

        }
        static bool TesteMultiplo(decimal p, decimal s)
        {
            if (p > s)
                return false;
            p = p < 0 ? p - p - p : p;
            s = s < 0 ? s - s - s : s;
            if (p == s)
                return true;
            else if (s == 0)
                return false;
            else if (p == 0)
                return true;
            else
                return TesteMultiplo(p, s - p);
        }
        static void AtividadeEscola()
        {
            int instancia = 1;

            while (true)
            {
                Console.Clear();

                sbyte contador = 1;

                int quantidadeAlunos;
                sbyte menorQuantidade = 10;
                string dadosAluno;
                int infelizReprovadoNumber = 9;
                string infelizReprovadoName = null;
                quantidadeAlunos = Convert.ToInt32(Console.ReadLine());
                List<Aluno> alunos = new List<Aluno>();

                if (quantidadeAlunos == 0)
                {
                    Console.WriteLine("ERRO");
                    Console.WriteLine("A QUANTIDADE MÍNIMA DE ALUNO PARA ESSE DESAFIO É 1");
                }

                else
                {
                    for (int i = 0; i < quantidadeAlunos; i++)
                    {
                        dadosAluno = Console.ReadLine();
                        Aluno aluno = new Aluno(dadosAluno);
                        

                        if (aluno.quantidadeProbelmasResolvidos < menorQuantidade)
                        {
                            menorQuantidade = aluno.quantidadeProbelmasResolvidos;
                            infelizReprovadoNumber = i;
                        }

                        else if (aluno.quantidadeProbelmasResolvidos == menorQuantidade)
                        {
                            if (infelizReprovadoName == null)
                                infelizReprovadoName = aluno.nome;

                            var result = string.Compare(aluno.nome, infelizReprovadoName);

                            if (result > 0)
                            {
                                infelizReprovadoName = aluno.nome;
                                infelizReprovadoNumber = i;
                            }
                        }
                        alunos.Add(aluno);
                    }
                    Console.Clear();

                    textoFormatado(contador, instancia, alunos, infelizReprovadoNumber);

                    instancia++;

                    while (contador > 0 )
                    {
                        var key = Console.ReadKey();

                        Console.Clear();

                        switch (key.Key)
                        {
                            case ConsoleKey.UpArrow:
                                contador = 1;
                                textoFormatado(contador, instancia, alunos, infelizReprovadoNumber);
                                break;

                            case ConsoleKey.DownArrow:
                                contador = 2;
                                textoFormatado(contador, instancia, alunos, infelizReprovadoNumber);
                                break;

                            case ConsoleKey.Enter:
                                if (contador == 1)
                                    contador = 0;
                                else
                                    contador = -1;
                                break;

                        }

                    }
                }
                if (contador == -1)
                    break;
            }
        }
        static void textoFormatado(sbyte contador, int instancia, List<Aluno> alunos, int infelizReprovadoNumber)
        {
            if(contador == 1)
            {
                Console.WriteLine();
                Console.WriteLine($"Instância {instancia}");
                Console.WriteLine(alunos[infelizReprovadoNumber].nome);
                Console.WriteLine();
                Console.WriteLine("Deseja fazer novamente?");
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("SIM");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("NÃO");
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine($"Instância {instancia}");
                Console.WriteLine(alunos[infelizReprovadoNumber].nome);
                Console.WriteLine();
                Console.WriteLine("Deseja fazer novamente?");
                Console.WriteLine();
                Console.WriteLine("SIM");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("NÃO");
                Console.BackgroundColor = ConsoleColor.Black;
            }  
            
        }
        static void ArrayVsList()
        {
            // string[] vetor = new string[10];
            List<String> lista = new List<string>(10);

            for (int i = 0; i <= 10; i++)
                lista.Add("a");

           // lista.
        }
    }
}
