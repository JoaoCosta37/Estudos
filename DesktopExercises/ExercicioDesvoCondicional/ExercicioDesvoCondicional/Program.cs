using System;

namespace ExercicioDesvoCondicional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Testes();
            //Exercicio14();
            //Exercicio15();
            //Exercicio16();
            //Exercicio19();
            //Exercicio20();
            //Exercicio21();
            //Enunciado();
            //Exercicio27();
            //Exercicio28();
            //Exercicio29();
            //Exercicio30();
            //Exercicio31();
            //Exercicio32();
            //Exercicio36();
            //Exercicio42();

        }
        static void Testes()
        {
            decimal nota1;
            decimal nota2;
            decimal media;

            nota1 = Convert.ToDecimal(Console.ReadLine());
            nota2 = Convert.ToDecimal(Console.ReadLine());

            media = (nota1 + nota2) / 2;

            Console.WriteLine(media);

            // OPERADORES RELACIONAIS maior > maior >=  menor < menor igual <= igual == diferente != 

            // OPERADORES LÓGICOS and && or ||  not !

            // true && true = true
            // true && false = false
            // false && false = false

            // true || true = true
            // true || false = true
            // false || false = false


            if (media < 7 && media >= 6)
            {
                Console.WriteLine("Exame");
            }
            else if (media < 6)
            {
                Console.WriteLine("Reprovado");
            }
            else
            {
                Console.WriteLine("Aprovado");
            }

        }
        static void Exercicio14()
        {
            decimal valor;

            Console.WriteLine("Insira o valor:");
            valor = Convert.ToDecimal(Console.ReadLine());


            if (valor > 10)
            {
                Console.WriteLine("É MAIOR QUE 10!");

            }
            else
            {
                Console.WriteLine("NÃO É MAIOR QUE 10!");
            }



        }
        static void Exercicio15()
        {
            decimal valor;

            valor = Convert.ToDecimal(Console.ReadLine());

            if (valor >= 0)
            {
                Console.WriteLine("Positivo");
            }
            else
            {
                Console.WriteLine("Negativo");
            }
        }
        static void Exercicio16()
        {
            decimal valorDaMaca = 1.30M;
            int quantidade;
            decimal custoDaCompra;

            Console.WriteLine("Quantidade de maças:");
            quantidade = Convert.ToInt32(Console.ReadLine());


            if (quantidade >= 12)
            {
                valorDaMaca = 1.00M;
            }

            custoDaCompra = valorDaMaca * quantidade;

            Console.WriteLine("Custo total da compra é de: {0:C2}", custoDaCompra);


        }
        static void Exercicio19()
        {
            decimal primeiroValor;
            decimal segundoValor;

            Console.WriteLine("Insira o primeiro número:");
            primeiroValor = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Insira o primeiro número:");
            segundoValor = Convert.ToDecimal(Console.ReadLine());


            // ? : operador ternário
          
            Console.WriteLine(" {0} é o número maior", primeiroValor > segundoValor ? primeiroValor : segundoValor);
            
        }
        static void Exercicio20()

        {
            decimal primeiroValor;
            decimal segundoValor;

            Console.WriteLine("Insira o primeiro número:");
            primeiroValor = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Insira o primeiro número:");
            segundoValor = Convert.ToDecimal(Console.ReadLine());

            if (primeiroValor > segundoValor)
            {

                Console.WriteLine(segundoValor);
                Console.WriteLine(primeiroValor);
            }
            else
            {
                Console.WriteLine(primeiroValor);
                Console.WriteLine(segundoValor);
            }

        }
        static void Exercicio21()
        {
            int horaDeInicio;
            int horaDeFim;
            int tempoTotal = 24;

            Console.WriteLine("Horário de Início do jogo:");
            horaDeInicio = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Horário de Término do jogo:");
            horaDeFim = Convert.ToInt32(Console.ReadLine());

            if (horaDeFim > horaDeInicio)
            {
                tempoTotal = horaDeFim - horaDeInicio;

                Console.WriteLine("O jogo durou {0} horas", tempoTotal);
            }
            else if (horaDeFim < horaDeInicio)
            {
                tempoTotal = (24 - horaDeInicio) + horaDeFim;

                Console.WriteLine("O jogo durou {0} horas", tempoTotal);
            }
            else
            {
                Console.WriteLine("O jogo durou {0} horas", tempoTotal);
            }

        }
        static void Enunciado()
        {
            string nome;
            char sexo;
            decimal altura;
            decimal pesoIdeal;


            Console.WriteLine("Nome:");
            nome = Console.ReadLine();
            Console.WriteLine("Sexo (M ou F):");
            sexo = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Altura:");
            altura = Convert.ToDecimal(Console.ReadLine());

            if (sexo == 'M')
            {
                pesoIdeal = (72.7M * altura) - 58;
                Console.WriteLine("Seu peso é de {0} gramas", pesoIdeal);
            }
            else if (sexo == 'F')
            {
                pesoIdeal = (62.1M * altura) - 44.7M;
                Console.WriteLine("Seu peso é de {0} gramas", pesoIdeal);
            }
            else
            {
                Console.WriteLine("ERRO: insira apenas 'M' ou 'F' para indicar o sexo");
            }
        }
        static void Exercicio27()
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
        }
        static void Exercicio28()
        {
            decimal primeiroValor;
            decimal segundoValor;
            decimal terceiroValor;

            Console.WriteLine("Primeiro Número:");
            primeiroValor = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Segundo Número:");
            segundoValor = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Terceiro Número:");
            terceiroValor = Convert.ToDecimal(Console.ReadLine());
            if (primeiroValor > segundoValor && primeiroValor > terceiroValor)
            {
                Console.WriteLine(primeiroValor);
            }
            else if (segundoValor > primeiroValor && segundoValor > terceiroValor)
            {
                Console.WriteLine(segundoValor);
            }
            else
            {
                Console.WriteLine(terceiroValor);
            }

        }
        static void Exercicio29()
        {
            decimal primeiroValor;
            decimal segundoValor;
            decimal terceiroValor;
            decimal soma;

            Console.WriteLine("Primeiro Número:");
            primeiroValor = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Segundo Número:");
            segundoValor = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Terceiro Número:");
            terceiroValor = Convert.ToDecimal(Console.ReadLine());

            if (primeiroValor < segundoValor && primeiroValor < terceiroValor)
            {
                soma = segundoValor + terceiroValor;
                
            }
            else if (segundoValor < primeiroValor && segundoValor < terceiroValor)
            {
                soma = primeiroValor + terceiroValor;
                
            }
            else
            {
                soma = primeiroValor + segundoValor;
                
            }
            Console.WriteLine(soma);


        }
        static void Exercicio30()
        {
            decimal primeiroValor;
            decimal segundoValor;
            decimal terceiroValor;


            Console.WriteLine("Primeiro Número:");
            primeiroValor = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Segundo Número:");
            segundoValor = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Terceiro Número:");
            terceiroValor = Convert.ToDecimal(Console.ReadLine());

            if (primeiroValor < segundoValor && primeiroValor < terceiroValor && segundoValor < terceiroValor)
            {
                Console.WriteLine("A sequência é: {0} , {1} , {2}", primeiroValor, segundoValor, terceiroValor);
            }
            else if (primeiroValor < segundoValor && primeiroValor < terceiroValor && terceiroValor < segundoValor)
            {
                Console.WriteLine("A sequência é: {0} , {1} , {2}", primeiroValor, terceiroValor, segundoValor);
            }
            else if (segundoValor < primeiroValor && segundoValor < terceiroValor && primeiroValor < terceiroValor)
            {
                Console.WriteLine("A sequência é: {0} , {1} , {2}", segundoValor, primeiroValor, terceiroValor);
            }
            else if (segundoValor < primeiroValor && segundoValor < terceiroValor && terceiroValor < primeiroValor)
            {
                Console.WriteLine("A sequência é: {0} , {1} , {2}", segundoValor, terceiroValor, primeiroValor);
            }
            else if (terceiroValor < segundoValor && terceiroValor < primeiroValor && segundoValor < primeiroValor)
            {
                Console.WriteLine("A sequência é: {0} , {1} , {2}", terceiroValor, segundoValor, primeiroValor);
            }
            else
            {
                Console.WriteLine("A sequência é: {0} , {1} , {2}", terceiroValor, primeiroValor, segundoValor);

                //Console.WriteLine(terceiroValor);
                //Console.WriteLine(primeiroValor);
                //Console.WriteLine(segundoValor);
            }
        }
        static void Exercicio31()
        {
            decimal ladoA;
            decimal ladoB;
            decimal ladoC;

            Console.WriteLine("medida do lado A");
            ladoA = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("medida do lado B");
            ladoB = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("medida do lado C");
            ladoC = Convert.ToDecimal(Console.ReadLine());

            if (ladoA < (ladoB + ladoC) && ladoB < (ladoA + ladoC) && ladoC < (ladoA + ladoB))
            {
                Console.WriteLine("FORMA UM TRINÂNGULO");
            }
            else
            {
                Console.WriteLine("NÃO FORMA UM TRINÂNGULO");
            }
        }
        static void Exercicio32()
        {
            string time1;
            string time2;
            int gols1;
            int gols2;

            Console.WriteLine("Nome do primeiro Time:");
            time1 = Console.ReadLine();
            Console.WriteLine("Quantidade de gols:");
            gols1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nome do segundo Time:");
            time2 = Console.ReadLine();
            Console.WriteLine("Quantidade de gols:");
            gols2 = Convert.ToInt32(Console.ReadLine());

            if (gols1 > gols2)
            {
                Console.WriteLine(" O {0} é o vencedor", time1);
            }
            else if (gols1 < gols2)
            {
                Console.WriteLine(" O {0} é o vencedor", time2);
            }
            else
            {
                Console.WriteLine("EMPATE");
            }
        }
        static void Exercicio36()
        {
            int primeiroHomem;
            int segundoHomem;
            int primeiraMulher;
            int segundaMulher;
            int soma;
            int produto;
            int homemV;
            int homemN;
            int mulherV;
            int mulherN;

            Console.WriteLine("Idade do primeiro Homem:");
            primeiroHomem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Idade do segundo Homem:");
            segundoHomem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Idade da primeira Mulher:");
            primeiraMulher = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Idade da segunda Mulher:");
            segundaMulher = Convert.ToInt32(Console.ReadLine());

            homemV = primeiroHomem > segundoHomem ? primeiroHomem : segundoHomem;
            homemN = primeiroHomem > segundoHomem ? segundoHomem : primeiroHomem;
            mulherV = primeiraMulher > segundaMulher ? primeiraMulher : segundaMulher;
            mulherN = primeiraMulher > segundaMulher ? segundaMulher : primeiraMulher;
            
            soma = homemV + mulherN;
            produto = homemN * mulherV;

            Console.WriteLine("Soma: " + soma);
            Console.WriteLine("Produto: " + produto);
                        
        }
        static void Exercicio42()
        {
            decimal codigoEmpregado;
            short anoNascimento;
            int anoIngresso;
            int idade;
            int tempoDeTrabalho;

            //short - Int16
            // int - Int32
            // long - Int64

            Console.WriteLine("Código do empregado:");
            codigoEmpregado = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Ano de nascimento do empregado:");
            anoNascimento = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Ano de ingresso na empresa:");
            anoIngresso = Convert.ToInt16(Console.ReadLine());

            int anoAtual = DateTime.Now.Year;

            idade = anoAtual - anoNascimento; //poderia ter não ter criado essa variável, o que parece melhor, mas não o fiz por conta do ano
            tempoDeTrabalho = anoAtual - anoIngresso;

            // > 64 ou >= 65 (considerar que idade é uma vaíável apenas de números inteiros)

            if (idade >= 65 || tempoDeTrabalho >= 30 || (idade >= 60 && tempoDeTrabalho >= 25))
            {
                Console.WriteLine("Requer aposentadoria");
            }
            else
            {
                Console.WriteLine("Não requer");
            }
        }

    }
}
