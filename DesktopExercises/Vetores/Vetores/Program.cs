using System;

namespace Vetores
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //const int TAMANHO_VETOR = 5;

            //int[] n = new int[TAMANHO_VETOR];

            //for(int i = 0; i < TAMANHO_VETOR; i++)
            //{
            //    Console.WriteLine($"Digite o {i+1} numero");
            //    n[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //for (int i = 0; i < TAMANHO_VETOR; i++)
            //{
            //    Console.WriteLine($"O {i+1} número é: {n[i]}");
            //}


            //Exercicio1a();
            //Exercicio1b();
            //Exercicio2a();
            //Exercicio2b();
            //Exercicio2c();
            //Exercicio3();
            Exercicio4();
        }
        static void Exercicio1a()
        {
            const int tamanhoVetor = 8;
            int[] n = new int [tamanhoVetor];

           
            for(int i = 0; i < n.Length; i++ )
            {
                Console.WriteLine($"Insira o {i+1}º número");
                n[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Insira o número X");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insira o número Y");
            int y = Convert.ToInt32(Console.ReadLine());
            int soma = somaVetor(n, x, y);
;            Console.WriteLine(soma);
        }

        static int somaVetor(int[] n, int x, int y)
        {
           // n[0] = 0;
            return n[x] + n[y];
        }

        static void Exercicio1b()
        {
            const int tamanhoVetor = 10;
            int[] n = new int[tamanhoVetor];
            int quantidadePares = 0;
            for (int i = 0; i < tamanhoVetor; i++)
            {
                Console.WriteLine($"Insira o {i + 1}º número");
                n[i] = Convert.ToInt32(Console.ReadLine());
                quantidadePares += n[i] % 2 == 0 ? 1 : 0;
            }
            Console.WriteLine($"Há {quantidadePares} número(s) par(es)");
        }
        static void Exercicio2a()
        {
            const int tamanhoVetor = 10;
            int[] n = new int[tamanhoVetor];
            int maiorN = 0;
            int menorN = 0;
            for (int i = 0; i < tamanhoVetor; i++)
            {
                Console.WriteLine($"Insira o {i + 1}º número");
                n[i] = Convert.ToInt32(Console.ReadLine());
                maiorN = n[i] > maiorN ? n[i] : maiorN;
                menorN = n[i] < menorN ? n[i] : menorN;
            }
            Console.WriteLine($"O maior número é {maiorN} e o menor é {menorN}");
        }
        static void Exercicio2b()
        {
            const int tamanhoVetor = 10;
            int[] n = new int[tamanhoVetor];
            int maiorN = 0;
            int posição = 0;
            for(int i = 0; i < tamanhoVetor; i++)
            {
                Console.WriteLine($"Insira o {i + 1}º número:");
                n[i] = Convert.ToInt32(Console.ReadLine());
                if ( n[i] > maiorN)
                {
                    maiorN = n[i];
                    posição = i;
                }
            }
            // for (int i = 0; i < tamanhoVetor; i++) 

            int j = 0;
            foreach(int elemento in n)
            {
                Console.WriteLine($"O {j + 1}º número é: {n[j]}");
                j++;
            }

            Console.WriteLine($"O maior número é: {maiorN} e está na posição {posição}."); //coloquei a posição e não a sequência de primeiro, segundo...etc


        }
        static void Exercicio2c()
        {
            const int tamanhoVetor = 6;

            int[] n = new int[tamanhoVetor];

            for (int i = 0; i < tamanhoVetor; i++)
            {
                Console.WriteLine($"Digite o {i + 1}º numero");
                n[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = tamanhoVetor; i != 0; i--)
            {
                Console.WriteLine($"O {i} número é: {n[i-1]}");
            }
        }
        static void Exercicio3()
        {
            const int tamanhoVetor = 10;

            int[] n = new int[tamanhoVetor];

            for (int i = 0; i < tamanhoVetor; i++)
            {
                Console.WriteLine($"Digite o {i + 1}º numero");
                n[i] = Convert.ToInt32(Console.ReadLine());
                
            }
            for (int i = 0; i < tamanhoVetor; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (n[j] == n[i]) Console.WriteLine($"O {j+1}º e {i+1}º números sãao iguais ({n[j]} {n[i]})"); //a posição aqui é a do que foi escrito na tela
                }
            }
        }
        static void Exercicio4()
        {
            const int tamanhoVetor = 10;
            int[] n = new int[tamanhoVetor];
            for (int i = 0; i < tamanhoVetor; i++)
            {
                Console.WriteLine($"Insira o {i + 1}º número");
                n[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < tamanhoVetor; i++)
            {
                if(n[i] % 2 != 0) Console.WriteLine($"Na Posição: {i} há o número {n[i]}"); //posição no vetor
            }
                
        }
    }
}
