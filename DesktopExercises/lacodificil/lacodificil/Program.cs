using System;

namespace lacodificil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exercicio5();
            //Exercicio2();
            ExercicioArranjo();
            //ExercicioCombinacao();

        }
        static void Exercicio5()
        {
            
            Console.WriteLine("Insira 'n'");
            decimal n = Convert.ToInt32(Console.ReadLine());
            
            for (decimal i = 1; n >= i; i++)
            {
                decimal divisores = i;
                decimal soma = 0;
                while (divisores != 0)          
                {
                    soma += i%divisores == 0 ? divisores : 0;
                    divisores--;
                }
                if (soma / 2 == i) Console.WriteLine(i);
            }

        }
        static void Exercicio2()
        {
            Console.WriteLine("Insira n");
            decimal n = Convert.ToDecimal(Console.ReadLine());
            decimal soma = 0;
            for(int i = 1; n >= i; i++)
            {
                soma += i * i;
            }
            Console.WriteLine(soma);
        }
        static void ExercicioArranjo()
        {
            Console.WriteLine("Insira n");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insira p");
            int p = Convert.ToInt32(Console.ReadLine());
            int calc = n - p;
            //if (n == 0) n = 1;
            //if (p == 0) p = 1;
            //if (calc == 0) calc = 1;

            int fatorialn = fatorial(n);
            int fatorialcalc = fatorial(n - p);

            Console.WriteLine($"O resultado do arranjo (n,p) é: {fatorialn / fatorialcalc}");
        }
        static int fatorial(int numero)
        {
            if (numero == 1 || numero == 0)
                return 1;
            else
                return numero * fatorial(numero - 1);
        }
        static void ExercicioCombinacao()
        {
            Console.WriteLine("Insira n");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insira p");
            int p = Convert.ToInt32(Console.ReadLine());
            int calc = n - p;

            int fatorialn = fatorial(n);
            int fatorialp = fatorial(p);
            int fatorialcalc = fatorial(calc);
            int combinacao = fatorialn / (fatorialp * fatorialcalc);

            Console.WriteLine($"O resultado da combinação (n,p) é: {combinacao}");
        }
    }
}
