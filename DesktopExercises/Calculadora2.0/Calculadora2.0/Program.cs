using System;
using System.Collections.Generic;

namespace Calculadora2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculadora2();
        }
        static void Calculadora2()
        {
            string[] opcoes = new string[] { "Soma", "Subtração", "Multiplicação", "Divisão", "Conversor de Decimal para Binário", "Sair" };
            Func<Object>[] funcoes = new Func<Object>[] { Soma, Subtracao, Multiplicacao, Divisao, ConverterDecimalParaBinario };
           //Func<Object,string>
            //Action<string> 

            sbyte contador = 1;

            while (true)
            {
                Console.WriteLine("Calculadora");
                Console.WriteLine();

                for (int i = 0; i < opcoes.Length; i++)
                {
                    if (i + 1 == contador)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine(opcoes[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                        Console.WriteLine(opcoes[i]);
                }
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        contador -= 1;
                        if (contador < 1)
                            contador = 6;
                        break;
                    case ConsoleKey.DownArrow:
                        contador += 1;
                        if (contador > 6)
                            contador = 1;
                        break;
                    case ConsoleKey.Enter:
                        if (contador == 6)
                            contador = -1;
                        else
                            funcoes[contador - 1]();
                        break;
                }

                if (contador == -1)
                    break;

                Console.Clear();

            }


        }
        //static void Calculadora2()
        //{
        //    Console.WriteLine(ConverterDecimalParaBinario());
        //}
        static object Soma()
        {
            Cabecalho("Soma");
            decimal parcela1 = Convert.ToDecimal(Console.ReadLine());
            decimal parcela2 = Convert.ToDecimal(Console.ReadLine());
            decimal soma = parcela1 + parcela2;
            Cabecalho("Resultado");
            EscrevaColorido(ConsoleColor.White, ConsoleColor.Black, $"{soma}");

            Console.WriteLine();
            Console.WriteLine("Deseja realizar outra Soma? S/N");
            char continuar = Console.ReadKey().KeyChar;
            if (continuar == 'S')
                return Soma();
            else
                return 1;
        }
        static object Subtracao()
        {
            Cabecalho("Subtração");
            decimal minuendo = Convert.ToDecimal(Console.ReadLine());
            decimal subtraendo = Convert.ToDecimal(Console.ReadLine());
            decimal subtracao = minuendo - subtraendo;
            Cabecalho("Resultado");
            EscrevaColorido(ConsoleColor.White, ConsoleColor.Black, $"{subtracao}");
            Console.WriteLine();
            Console.WriteLine("Deseja realizar outra Soma? S/N");
            char continuar = Console.ReadKey().KeyChar;
            if (continuar == 'S')
                return Subtracao();
            else
                return 1;
        }
        static object Multiplicacao()
        {
            Cabecalho("Multiplicação");
            decimal fator1 = Convert.ToDecimal(Console.ReadLine());
            decimal fator2 = Convert.ToDecimal(Console.ReadLine());
            decimal produto = fator1 * fator2;
            Cabecalho("Resultado");
            EscrevaColorido(ConsoleColor.White, ConsoleColor.Black, $"{produto}");
            Console.WriteLine();
            Console.WriteLine("Deseja realizar outra Soma? S/N");
            char continuar = Console.ReadKey().KeyChar;
            if (continuar == 'S')
                return Multiplicacao();
            else
                return 1;
        }
        static object Divisao()
        {
            Cabecalho("Divisão");
            decimal dividendo = Convert.ToDecimal(Console.ReadLine());
            decimal divisor = Convert.ToDecimal(Console.ReadLine());
            if (divisor == 0)
            {
                Cabecalho("Resultado");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("NÃO É POSSÍVEL DIVIDIR POR ZERO");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            else
            {
                decimal quociente = dividendo / divisor;
                Cabecalho("Resultado");
                EscrevaColorido(ConsoleColor.White, ConsoleColor.Black, $"{quociente}");
            }

            Console.WriteLine();
            Console.WriteLine("Deseja realizar outra Soma? S/N");
            char continuar = Console.ReadKey().KeyChar;
            if (continuar == 'S')
                return Divisao();
            else
                return 1;
        }
        static void Cabecalho(string operacao)
        {
            Console.Clear();
            Console.WriteLine("Calculadora");
            Console.WriteLine();
            Console.WriteLine(operacao);
            Console.WriteLine();
        }
        static void EscrevaColorido(ConsoleColor background, ConsoleColor foreground, string texto)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.WriteLine(texto);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void TesteLista()
        {
            List<int> TesteLista = new List<int>();
            int variavel = 0;
            for(int i = 15; i> variavel; i--)
            {
                TesteLista.Add(i);
            }
            Console.WriteLine(TesteLista.Count);
            TesteLista.Clear();
            Console.WriteLine(TesteLista.Count);

        }

        static string ConverterDecimalParaBinario()
        {
            Cabecalho("Conversor de Decimal para Binário");
            string resultado = "";
            decimal valorDecimal = Convert.ToDecimal(Console.ReadLine());
            decimal valorBase = 1;
            uint contador = 1;

            for(uint i = 1; valorBase < valorDecimal; i++)
            {
                contador++;
                valorBase *= 2;
            }

            for (uint i = 1; i <= contador; i++)
            {
                if (valorBase > valorDecimal && i != 1)
                    resultado += "0";
                else if (valorDecimal == 0)
                    resultado += "0";
                else if (valorBase <= valorDecimal)
                {
                    valorDecimal -= valorBase;
                    resultado += "1";
                }
                valorBase /= 2;
            }

            Cabecalho("Resultado");
            EscrevaColorido(ConsoleColor.White, ConsoleColor.Black, $"{resultado}");
            Console.WriteLine();
            Console.WriteLine("Deseja realizar outra Conversão? S/N");
            char continuar = Console.ReadKey().KeyChar;
            if (continuar == 'S')
                return ConverterDecimalParaBinario();
            else
                return "";

        }
    }
}
