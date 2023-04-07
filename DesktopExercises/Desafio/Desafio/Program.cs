using System;
using System.Collections.Generic;

namespace Desafio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Datas();
            //FuncionariosPOO();
            // OrientacaoObjetos();
            //Desafio1();
            //  Desafio2();

            //Bubble();


            //// Console.ReadLine();

            ////// "Rafael + enter";
            //// Console.WriteLine("Hello world");
            //// /// fflush(std.in)
            //// Console.ReadKey();
        }

        static void FuncionariosPOO()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            //Funcionario[] funcionario = new Funcionario[100];


         //   List<Funcionari> palavras = new List<string>();

            string opcao = "S";

            int quantidadeFuncionarios = 1;

            while(opcao == "S")
            {
                
                Funcionario funcionario = new Funcionario();

                Console.WriteLine($"Insira a Idade do funcionário 00{quantidadeFuncionarios}");
                funcionario.idade = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Insira o Sexo ('M' para MASCULINO e 'F' para FEMININO) do funcionário 00{quantidadeFuncionarios}");
                funcionario.sexo = Convert.ToChar(Console.ReadLine());
                Console.WriteLine($"Insira O Salário do funcionário 00{quantidadeFuncionarios}");
                funcionario.salario = Convert.ToDecimal(Console.ReadLine());

                funcionarios.Add(funcionario);

                Console.WriteLine($"Deseja continuar S/N?");

                opcao = Console.ReadLine();
            }
            Console.WriteLine(mediaS(funcionarios));
            Console.WriteLine(quantidadeM(funcionarios));
            Console.WriteLine(quantidadeH(funcionarios));
        }

        static void Datas()
        {
            Data d = new Data(25, 1, 2022);
            


            Console.WriteLine(d.FormatoDDMMAAAA());
            Funcionario funcionario = new Funcionario();

            funcionario.dataAdmissao = new Data(25, 1, 2022);
            //Console.WriteLine(funcionario.FormatoDDMMAAAA);
            

            //funcionario.salario = 1000;
            //funcionario.aumentaSalario(Convert.ToInt32(Console.ReadLine()));
            //Console.WriteLine(funcionario.salario);

        }

        static void OrientacaoObjetos()
        {

            //const int tamanhoVetor = 10;
            //int[] idade = new int[tamanhoVetor];
            //int[] sexo = new int[tamanhoVetor];
            //decimal[] salario = new decimal[tamanhoVetor];
//            int quantidadeFuncionarios = 0;

            //funcionario.idade = 28;
            //funcionario.sexo = 'M';
            //funcionario.salario = 5000;

            //funcionario.aumentaSalario(500);
            //Funcionario funcionarios = new Funcionario;

            //for (int i = 0; true; i++)
            //{
            //    char continuar;
            //    Funcionario[] f = new Funcionario[i];
            //    Console.WriteLine($"Insira a Idade do funcionário 00{i + 1}");
            //    funcionarios[i].idade = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine($"Insira o Sexo ('M' para MASCULINO e 'F' para FEMININO) do funcionário 00{i + 1}");
            //    funcionarios[i].sexo = Convert.ToChar(Console.ReadLine());
            //    Console.WriteLine($"Insira O Salário do funcionário 00{i + 1}");
            //    funcionarios[i].salario = Convert.ToDecimal(Console.ReadLine());

            //    Console.WriteLine("Deseja cadastrar mais funcionários?");
            //    continuar = Convert.ToChar(Console.ReadLine());
            //    if (continuar == 'N') break;
            //}

            //Funcionario[] funcionarios = new Funcionario[tamanhoVetor];

            //funcionarios[0] = new Funcionario();
            //funcionarios[0].idade = 10;

            //for (int i = 0; i < tamanhoVetor; i++)
            //{
            //    funcionarios[i] = new Funcionario();
            //    Console.WriteLine($"Insira a Idade do funcionário 00{i + 1}");
            //    idade[i] = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine($"Insira o Sexo ('0' para MASCULINO e '1' para FEMININO) do funcionário 00{i + 1}");
            //    sexo[i] = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine($"Insira O Salário do funcionário 00{i + 1}");
            //    salario[i] = Convert.ToDecimal(Console.ReadLine());
            //}
            //decimal mediaSalarios = mediaS(salario);
            //int maiorIdade = 0;
            //int menorIdade = idade[0];
            //for (int i = 0; i < idade.Length; i++)
            //{
            //    maiorIdade = idade[i] > maiorIdade ? idade[i] : maiorIdade;
            //    menorIdade = idade[i] < menorIdade ? idade[i] : menorIdade;
            //}
            //int quantidadeMS100 = quantidadeM(salario, sexo);
            //int quantidadeHomens = quantidadeH(sexo);
            //Console.WriteLine($"A média do salário do grupo é {mediaSalarios}");
            //Console.WriteLine($"A maior idade do grupo é {maiorIdade} e a menor é {menorIdade}");
            //Console.WriteLine($"A quantidade de mulheres com salário até R$ 100,00 é {quantidadeMS100}");
            //Console.WriteLine($"A quantidade de homens é {quantidadeHomens}");
        }
        static decimal mediaS(List<Funcionario> funcionarios)
        {
            decimal somaSalario = 0;
            for (int i = 0; i < funcionarios.Count; i++)
            {
                somaSalario += funcionarios[i].salario;
            }
            return somaSalario / funcionarios.Count;
        }
        static int quantidadeM(List<Funcionario>funcionarios)
        {
            int contador = 0;
            for (int i = 0; i < funcionarios.Count; i++) contador += funcionarios[i].salario <= 100 && funcionarios[i].sexo == 'F' ? 1 : 0;
            return contador;
        }
        static int quantidadeH(List<Funcionario> funcionarios)
        {
            int contador = 0;
           // for (int i = 0; i < s.Length; i++) contador += s[i] == 0 ? 1 : 0;

            //para cada funcionarios em funcionarios
            foreach(Funcionario funcionario in funcionarios)
            {
                contador += funcionario.sexo == 'M' ? 1 : 0; 
            }

            return contador;
        }
        static void Desafio2()
        {
            const int tamanhoVetor = 10;
            int[] n = new int[tamanhoVetor];
            int menor = 0;

            for (int i = 0; i < tamanhoVetor; i++)
            {
                Console.WriteLine($"Insira o {i + 1}º número");
                n[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < tamanhoVetor; i++)
            {
                int localizador = 0;
                for (int j = i; j < tamanhoVetor; j++)
                {
                    if (j == i) 
                        menor = n[j];
                    if (n[j] < menor)
                    {
                        menor = n[j];
                        localizador = j;
                    }
                }
                n[localizador] = n[i];
                n[i] = menor;
               // Console.WriteLine($"O {i + 1}º número é {n[i]}.");
            }

            for (int i = 0; i < tamanhoVetor; i++)
            {
                Console.WriteLine(n[i]);
               // n[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void Bubble()
        {
            int[] n =new int[] { 10,9,8,7,6,9,1};

            Ordena(n);

            for (int i = 0; i < n.Length; i++)
            {
                Console.WriteLine(n[i]);
                // n[i] = Convert.ToInt32(Console.ReadLine());
            }
           

        }
        static void Ordena(int[] n)
        {
            int aux = 0;

            for(int i = 0; i < n.Length; i++)
            {
                for(int j =0; j < n.Length; j++)
                {
                    Console.WriteLine($"Comparando a posição {i} - Valor de i {n[i]} com a posição {j} - Valor de j {n[j]}" );
                    if(n[i] > n[j])
                    {
                        aux = n[i];
                        n[i] = n[j];
                        n[j] = aux;
                    }
                }
            }

            //Análise de algortimo
            // n ^ 2

            // lgn(n)  Quicksort

        }

    }
}
