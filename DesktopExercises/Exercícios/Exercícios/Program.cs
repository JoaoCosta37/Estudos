using System;

namespace Exercícios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercicio5();
            //Exerciciosoma();
            //Exercicio6();
            //Exercicio7();
            //Exercicio8();
            //Exercicio9();
            //Exercicio10();
            //Exercicio11();
            //DesafioFinal();
        }
        static void Exercicio5()
        { //Exercício5
            int num1;
            int fator;

            Console.WriteLine("Digite o número desejado");
            num1 = Convert.ToInt32(Console.ReadLine());

            fator = num1 - 1;

            Console.WriteLine("o antecessor de " + num1 + " é: " + fator);
        }
        static void Exerciciosoma()
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
        }
        static void Exercicio6()
        {
            int baser;
            int altr;
            int calculo;

            Console.WriteLine("Calcular área do retângulo");
            Console.WriteLine("Vamos lá");
            Console.WriteLine("Primeiro insira o valor da base");
            baser = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Agora o valor da altura");
            altr = Convert.ToInt32(Console.ReadLine());
            calculo = baser * altr;
            Console.WriteLine("A área do Retângulo é de: " + calculo.ToString());

        }
        static void Exercicio7()
        {
            Console.WriteLine("Sabe a sua idade em dias?");
            Console.WriteLine("Para calcular, insira sua idade exata em anos, meses e dia(s)");

            //valores necessários:

            int anop; //ano da pessoa
            int mesp; //mes da pessoa
            int dias; //dias da pessoa
            int cdaidade; //soma dos dias

            Console.WriteLine("Primeiro os anos:");
            anop = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Agora os mêses");
            mesp = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Por fim os dias");
            dias = Convert.ToInt16(Console.ReadLine());

            cdaidade = dias + (anop * 365) + (mesp * 12) ;

            Console.WriteLine("Sua idade em dias é: " + cdaidade); 
            
        }
        static void Exercicio8()
        {
            //testa não usar uma entrada para o cálculo, mas fazer direto na String;

            Console.WriteLine("Cálculo dos votos");

            int eleitores; // numero de eleitores
            int brancos; // votos brancos
            int nulos; // votos nulos
            int validos; // votos válidos
            int porcentualBrancos;
            int porcentualNulos;
            int porcentualValidos;

            Console.WriteLine("Número de Eleitores:");
            eleitores = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Votos Brancos");
            brancos = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Votos Nulos");
            nulos = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Votos Válidos");
            validos = Convert.ToInt32(Console.ReadLine());

            porcentualBrancos = (brancos * 100) / eleitores;
            porcentualNulos = (nulos * 100) / eleitores;
            porcentualValidos = (validos * 100) / eleitores;

            Console.WriteLine("Os Votos Brancos representam {0}% dos Eleitores {1}", porcentualBrancos,2020);
            Console.WriteLine("Os Votos Nulos representam {0}% dos Eleitores {1}", porcentualNulos, 2020);
            Console.WriteLine("Os Votos Válidos representam {0}% dos Eleitores {1}", porcentualValidos, 2020);
        }
            
            static void Exercicio9()
           {
            Decimal salat; // salário atual
            Decimal reaju; // reajuste
            Decimal sf; // salário Final
            String salarioFormatado;

            Console.WriteLine("Indique o Salário atual:");
            salat = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Indique o Reajuste em porcentual:");
            reaju = Convert.ToDecimal(Console.ReadLine());
            sf = salat * (1 + reaju / 100);
            salarioFormatado = String.Format("{0:C2}",sf);
            Console.WriteLine("Salátio Final será de " + salarioFormatado);

            }
        static void Exercicio10()
        {
            Decimal Pdcalculado;
            Decimal Impcalculado;
            Decimal Cc;
            Decimal Cf;

            Console.WriteLine("Indique o custo de fábrica do veículo:");
            Cf = Convert.ToInt32(Console.ReadLine());
            Pdcalculado = (Cf * 28 /100);
            Impcalculado = (Cf * 45 / 100);
            Cc = Cf + Pdcalculado + Impcalculado;
            Console.WriteLine("O Custo final do veículo ao consumidor é de: " + Cc);
            
        }
        static void Exercicio11()
        {
            Decimal SFixo; //Salário Fixo
            Decimal Num; //Número de carros vendidos
            Decimal CFixa; //Comisssão Fixa
            Decimal SFinal; //Salário FInal
            Decimal SVendas; //Valor de Soma de todas as vendas

            Console.WriteLine("Salário Fixo:");
            SFixo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Número de carros vendidos:");
            Num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Comissão fixa por venda de veículo:");
            CFixa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Valor total de vendas:");
            SVendas = Convert.ToInt32(Console.ReadLine());

            SFinal = (SFixo + (Num * CFixa) + (SVendas * 5 / 100));

            Console.WriteLine("O Saláario Final é de: " + SFinal);
        }
        static void DesafioFinal()
        {
            sbyte variavelA = 10;
            sbyte variavelB = 20;
            sbyte variavelC;

            variavelC = variavelB;
            variavelB = variavelA;
            variavelA = variavelC;

            Console.WriteLine("Variável A é {0}",variavelA);
            Console.WriteLine("Variável B é {0}",variavelB);


        }
    }
}
