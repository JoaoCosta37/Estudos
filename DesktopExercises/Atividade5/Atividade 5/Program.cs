using System;

namespace Atividade5
{
    internal class Program
    {
        static void Main(string[] args)
        {

;           int num1;
            int fator;

            Console.WriteLine("Digite o número desejado");
            num1 = Convert.ToInt32(Console.ReadLine());

            fator = num1 - 1;

            Console.WriteLine("o antecessor de " + num1.ToString() + " é:" + fator.ToString());


        }
    }
}
