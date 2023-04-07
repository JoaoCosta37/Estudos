using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1; 
            int num2;
            int soma;

            //ENTRADA
            Console.WriteLine("Digite o primeiro número:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o segundo número:");
            num2 = Convert.ToInt32(Console.ReadLine());

            //PROCESSAMENTO
            soma = num1 + num2;

            //SAIDA
            Console.WriteLine("A soma é:" + soma.ToString());

            int number1;
            int number2;
            int asd;

            Console.WriteLine("Digite o primeiro número");
            number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o segundo número");
            number2 = Convert.ToInt32(Console.ReadLine());

            asd = number1 + number2;

            Console.WriteLine("O resultado da soma é:)" + asd.ToString());

        }
      
    }
}
