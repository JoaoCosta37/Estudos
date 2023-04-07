using System;

namespace ExercicioLacoRepeticao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  contagemRegressivaDoWhile();
            //Exercicio27();

            //ExercicioFatorail();
             
            Console.WriteLine(fatRecursivo(3));
            Console.WriteLine(fatRecursivo(5));

        }

        static void exemploWhile()
        {
            int contador = 1; //inicialização

            while (contador <= 10) // expressão de teste
            { // corpo da repetição
                Console.WriteLine(contador);
                contador++; //incremento do contador = contador = contador + 1;
            }

            Console.WriteLine(contador);
        }

        static void exemploFor()
        {
            for (int contador = 1 /*incicialização*/ ; contador <= 10 /*expressão de teste*/; contador++ /*incremento do contador*/)
            {
                Console.WriteLine(contador);
            }

            //Console.WriteLine(contador);
        }

        static void contagemRegressiva()
        {
            int contador = -1;

            while (contador >= 0)
            {
                Console.WriteLine(contador);
                contador--;
            }

            Console.WriteLine("ACABOU!");
        }

        static void contagemRegressivaDoWhile()
        {
            int contador = 10;

            do
            {
                Console.WriteLine(contador);
                contador--;
            } 
            while (contador >= 0);

            Console.WriteLine("ACABOU!");
        }
        static void Exercicio27()
        {
            char continuar;


            do
            {
                decimal valor;

                Console.WriteLine("Insira o número:");
                valor = Convert.ToDecimal(Console.ReadLine());

                if (valor > 0)
                {
                    Console.WriteLine("POSITIVO");
                }
                else if (valor < 0)
                {
                    Console.WriteLine("NEGATIVO");
                }
                else
                    Console.WriteLine("ZERO");

                Console.WriteLine("Deseja continuar? S/N");
                continuar = Console.ReadKey().KeyChar;

            } 
            while (continuar == 'S');


            
        }

        static void ExercicioFatorail() 
        { 
            int n;
            int p; 
            int resultado;

            n = Convert.ToInt32(Console.ReadLine());
            p = Convert.ToInt32(Console.ReadLine());

            int nfatorial = fatorial(n);
            int pfatorial = fatorial(p);

            resultado = nfatorial / pfatorial;

            // 6 ^ 5  

          ///  Math.Pow(6, 5);

          // resultado = fatorial(n) / fatorial(n-p);

            Console.WriteLine(resultado);
        }

        static int fatorial(int numero)
        {
            int resultado = 1;

            while (numero >= 1)
            {
                resultado *= numero;
                numero--;
            }

            return resultado;

        }

        static int fatorial(int numero, int j)
        {
            int resultado = 1;

            while(numero >= 1)
            {
                resultado = resultado * numero;
                numero--;
            }

            return resultado;
            
        }

        static int fatRecursivo(int n)
        {
            if (n == 1)
                return 1;
            else
                return n * fatRecursivo(n - 1);
        }
    }
}
