using System;

namespace ExercLacoRepeticao
{
    internal class Program
    {
        static void Main(string[] args)

        {
            // Exercicio59();
            //Exercicio60();
            //Exercicio61();
            //Exercicio62();
            //Exercicio63();
            //Exercicio64();
            //Exercicio65();
            //Exercicio68();
            //Exercicio69();
            //Exercicio71();
            Exercicio10();
            //Exercicio1();
            //Exercicio5();
            //Exercicio8();
            //Exercicio9();
            //Exercicio();
            //Exercicio2();
            //Exercicio5b();
            //Exercicio10b();
            //Exercicio16();
            //Desafio();


        }
        static void Exercicio59()
        {
            short negativos = 0;
            int numero;

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Insira o {0}º número:", i);
                numero = Convert.ToInt32(Console.ReadLine());
                if (numero < 0) negativos++;
            }
            
            Console.WriteLine($" Há {negativos} numero(s) negativo(s)");
        }
        static void Exercicio60()
        {
            decimal numero;
            int intervalo = 0;
            int quantidade = 10;

            for (int i = 1; i <= quantidade; i++)
            {
                Console.WriteLine("Insira o {0}º número:", i);
                numero = Convert.ToInt32(Console.ReadLine());
                if (numero >= 10 && numero <= 20) intervalo++;
            }

            Console.WriteLine($"Há {intervalo} números dentro do intervalo e {quantidade - intervalo} fora");
        }
        static void Exercicio61()
        {
            decimal valor = 0;
            short quantidade = 10;
            decimal media;

            Console.WriteLine("Insira 10 valores");

            for ( int i = 1; i <= quantidade; i++)
                valor = valor + Convert.ToDecimal(Console.ReadLine());
            
            media = valor / quantidade;
            Console.WriteLine($"a média é {media}");
        }
        static void Exercicio62()
        {
            short numeroAlunos;
            decimal nota;
            decimal soma = 0;

            Console.WriteLine("Insira a quantidade de alunos:");
            numeroAlunos = Convert.ToInt16(Console.ReadLine());

            for (int i = 1; i <= numeroAlunos; i++)
            {
                Console.WriteLine("Insira a nota do {0}º aluno:", i);
                nota = Convert.ToDecimal(Console.ReadLine());
                soma += nota;
            }

            Console.WriteLine($" {(soma / numeroAlunos):N1} é a média aritmética das notas");
        }
        static void Exercicio63()
        {
            decimal soma = 0;
            decimal numero;

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Insira o {0}º número:", i);
                numero = Convert.ToDecimal(Console.ReadLine());
                soma += numero;
            }
            Console.WriteLine("a soma total é {0}",soma);
        }
        static void Exercicio64()
        {
            decimal numero;
            decimal soma = 0;

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Insira o {0}º número", i);
                numero = Convert.ToDecimal(Console.ReadLine());
                soma += numero < 40 ? numero : 0;
            }

            Console.WriteLine("a soma total é {0}", soma);
        }
        static void Exercicio65()
        {
            decimal numero1;
            decimal numero2;
            decimal somador = 0;

            Console.WriteLine("Insira o primeiro número:");
            numero1 = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Insira o segundo número:");
            numero2 = Convert.ToDecimal(Console.ReadLine());
            for (decimal i = numero1; i <= numero2; i++)
            {
                somador += i;
            }

            Console.WriteLine(" o soma final é: {0}", somador);
        }
        static void Exercicio68()
        {
            int quantidadeMercadoria;
            decimal valorMarcadoria = 0;
            decimal soma = 0;
            decimal mediaValores;

            Console.WriteLine("Insira a quantidade total de mercadorias:");
            quantidadeMercadoria = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= quantidadeMercadoria; i++)
            {
                Console.WriteLine("Insira o valor do {0}º produto:", i);
                valorMarcadoria = Convert.ToDecimal(Console.ReadLine());
                soma += valorMarcadoria;
            }

            mediaValores = soma / quantidadeMercadoria;

            Console.WriteLine($" O valor total de estoque é de {soma:C2} e a média é de {mediaValores:C2}");
                        
        }
        static void Exercicio69()
        {
            decimal valorMercadoria;
            decimal soma = 0;
            decimal mediaValores;
            char continuar;
            int quantidadeMercadoria = 0;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Insira o valor da mercadoria:");
                valorMercadoria = Convert.ToDecimal(Console.ReadLine());
                soma += valorMercadoria;

                Console.WriteLine("MAIS MERCADORIAS? (S/N)");
                continuar = Console.ReadKey().KeyChar;
                quantidadeMercadoria++;
            }
            while (continuar == 'S');

            mediaValores = soma / quantidadeMercadoria;
            Console.WriteLine("");
            Console.WriteLine("O valor total de estoque é de {0:C2} e a média é de {1:C2}", soma, mediaValores);

        }
        static void Exercicio71()
        {
            int quantidade;
            decimal numero;
            decimal soma = 0;
            decimal maior = 0;
            decimal media;

            Console.WriteLine("Insira a quantidade:");
            quantidade = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= quantidade; i++)
            {
                Console.WriteLine($"Insira o {i}º numero:");
                numero = Convert.ToDecimal(Console.ReadLine());
                soma += numero;
                if (i == 1) maior = numero;
                else maior = numero > maior ? numero : maior;
            }
            media = soma / quantidade;

            Console.WriteLine($"O maior número é o {maior} e a média dos números é: {media:N2}");
        }
        static void Exercicio10()
        {        
            decimal numeroElementos;

            Console.WriteLine("Insira até qual elemento da sequência deseja ver:");
            numeroElementos = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine($"A sequência Fibonacci até o {numeroElementos}º elemento é:");


            decimal primeiroElemento = 1;
            decimal segundoElemento = 1;
            for (int i=1; i <= numeroElementos; i++)
                 Console.WriteLine (funcaoFibonacci(i));

            //for (int i = 1; i <= numeroElementos; i++)
            //{
            //    if (i >= 3)
            //    {
            //        decimal terceiroE = segundoElemento + primeiroElemento;
            //        primeiroElemento = segundoElemento;
            //        segundoElemento = terceiroE;
            //    }
                    
            //    Console.WriteLine(segundoElemento);

            //}
            
            //Console.WriteLine("Fim");
        }
        static decimal funcaoFibonacci (decimal n)
        {
            //decimal primeiroElemento = 1;
            //decimal segundoElemento = 1;
            if (n >= 3)
            {
                return funcaoFibonacci(n - 1) + funcaoFibonacci(n - 2);
                //n--;
                //decimal terceiroE = sE + funcaoFibonacci(n,pE,sE);
                //sE = terceiroE;
                //return terceiroE;
            }
            else
                return 1;
        }
        static void Exercicio1()
        {
            int primeiroFator;
            int produto;

            Console.WriteLine("Deseja ver a tabuada de qual número:");
            primeiroFator = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                produto = primeiroFator * i;
                Console.WriteLine("{0} x {1} = {2}", primeiroFator, i, produto);
            }
        }
        static void Exercicio5()
        {
            decimal elemento;
            decimal razao;
            decimal posicao;
            decimal resultado;

            Console.WriteLine("Insira o primeiro Elemento da PA:");
            elemento = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Insira a razão da PA:");
            razao = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Insira até qual posição deve ser mostrada a PA:");
            posicao = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine(" Aqui está a PA até a posição {0}", posicao);

            for (int i = 1; i <=posicao; i++)
            {
                Console.WriteLine(elemento);
                elemento += razao;
            }
        }
        static void Exercicio8()
        {
            decimal idade;
            decimal somaIdades = 0;
            decimal quantidade = 0;
            decimal media;

            Console.WriteLine("Insira as idades desejadas e digite ZERO para encerrar e receber os cáulculos:");

            for (int i = 1; true; i++)
            {
                idade = Convert.ToDecimal(Console.ReadLine());
                if (idade >= 18)
                {
                    somaIdades += idade;
                    quantidade++;
                }
                if (idade == 0) break;
            }
            media = somaIdades / quantidade;

            Console.WriteLine("A quantidade de pessoas maiores é {0} e a média de idade deles é {1}", quantidade, media);
        }
        static void Exercicio9()
        {
            decimal idade;
            decimal primeiraFaixa = 0;
            decimal segundaFaixa = 0;
            decimal terceiraFaxa = 0;
            decimal quartaFaixa = 0;
            decimal quintaFaixa = 0;
            decimal quantidade = 0;

            Console.WriteLine("Insira as idades desejadas e digite ZERO para encerrar e receber os cáulculos:"); //Insira as idades e escreva 'fim' quando desejar encerrar
            for (int i = 1; true; i++)
            {
                idade = Convert.ToDecimal(Console.ReadLine());

                primeiraFaixa += idade > 0 && idade <= 17 ? 1 : 0;
                segundaFaixa += idade >= 18 && idade <= 35 ? 1 : 0;
                terceiraFaxa += idade >= 36 && idade <= 50 ? 1 : 0;
                quartaFaixa += idade >= 51 && idade <= 65 ? 1 : 0;
                quintaFaixa += idade > 65 ? 1 : 0;
                
                if (idade == 0) break;

                quantidade++;
            }
            primeiraFaixa = primeiraFaixa / quantidade;
            segundaFaixa = segundaFaixa / quantidade;
            terceiraFaxa = terceiraFaxa / quantidade;
            quartaFaixa = quartaFaixa / quantidade;
            quintaFaixa = quintaFaixa / quantidade;

            Console.WriteLine("porcentual de pessoas por faixas de idade é:");
            Console.WriteLine(" De 0 a 17 anos: {0:P1}", primeiraFaixa);
            Console.WriteLine(" De 18 a 35 anos: {0:P1}", segundaFaixa);
            Console.WriteLine(" De 36 a 50 anos: {0:P1}", terceiraFaxa);
            Console.WriteLine(" De 51 a 65 anos: {0:P1}", quartaFaixa);
            Console.WriteLine(" Maiores de 65 anos: {0:P1}", quintaFaixa);
        }
        static void Exercicio()
        {
            for (int i = 101; i <= 200; i += 2) Console.WriteLine(i);
        }
        static void Exercicio2()
        {
            Console.WriteLine("Insira o número para calcular seu fatorial:");
            int fatorial = Convert.ToInt32(Console.ReadLine());
            int resultado = 1;
            for (; fatorial >= 1; fatorial--) resultado *= fatorial;

            Console.WriteLine(resultado);

            //Console.WriteLine("Insira o número para calcular seu fatorial:");
            //int fatorial = Convert.ToInt32(Console.ReadLine());
            //int resultado = 1;
            //while (fatorial >= 1)
            //{
            //    resultado = resultado * fatorial;
            //    fatorial--;
            //}
            //Console.WriteLine(" O Fatorial desse número é: {1:N0}", fatorial, resultado);
            //Console.WriteLine(resultado);

        }
        static void Exercicio5b()
        {
            int numero;
            decimal somaPares = 0;
            decimal somaImpares = 0;
            decimal mediaImpares;
            decimal quantidadeImpares = 0;

            Console.WriteLine("Insira 10 númeors inteiros:");

            for(int i = 1; i <= 10; i++)
            {
                numero = Convert.ToInt32(Console.ReadLine());

                if (numero % 2 != 0)
                {
                    somaImpares += numero;
                    quantidadeImpares++;
                }
                else somaPares += numero;
            }
            
            mediaImpares = somaImpares / quantidadeImpares;

            Console.WriteLine(" A soma dos númeoros pares é {0} e a média dos ímpares é {1}", somaPares, mediaImpares);
        }
        static void Exercicio10b()
        {
            decimal valorX;
            decimal termo = 1;
            decimal denominador = 1;
            decimal resultadoX = 1;

            Console.WriteLine("Insira o valor de x:");
            valorX = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine(resultadoX);
            for (int i = 2; i <= 19; i++)
            {
                denominador = valorX;
                for (int j = 1; j <= i; j++) denominador *= valorX;
                resultadoX = resultadoX + (1 / denominador);
                Console.WriteLine(resultadoX);
            }
        }
        static void Exercicio16()
        {
            decimal numero;
            decimal maior;

            Console.WriteLine("Insira os números:");
            numero = Convert.ToDecimal(Console.ReadLine());
            maior = numero;

            while (numero >= 0)
            {
                maior = numero > maior ? numero : maior;
                numero = Convert.ToDecimal(Console.ReadLine());
            }

            Console.WriteLine("o maior número digitado é {0}", maior);        
        }
        static void Desafio()
        {

            int dividendo = Convert.ToInt32(Console.ReadLine());
            int divisor = Convert.ToInt32(Console.ReadLine());
            int fator = 1;
            int contagem = 0;
            int resto = 0;

            if (dividendo > 0 && divisor < 0 || dividendo < 0 && divisor > 0) fator = -1;
            dividendo *= dividendo < 0 ? -1 : 1;
            divisor *= divisor < 0 ? -1 : 1;
            int aux = dividendo;

            if (divisor == 0) Console.WriteLine("Erro");
            else
            {
                while (aux >= divisor)
                {
                    aux -= divisor;
                    contagem++;
                }
                resto = dividendo - (contagem * divisor);
                Console.WriteLine($"O resultado é {contagem * fator} e o resto é {resto}");
            }
        }
            
    }
}
