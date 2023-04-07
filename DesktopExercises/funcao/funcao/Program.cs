using System;
using System.Numerics;

namespace funcao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exercicio1();
            //KExercicio2();
            Exercicio3();
            //Exercicio4();
            //Exercicio5();
            //Exercicio6();
            //Exercicio7();
        }
        static void Exercicio1()
        {
             Console.WriteLine("Primeiro número:");
             int num1 = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Primeiro número:");
             int num2 = Convert.ToInt32(Console.ReadLine());
             int numM = calculoMaior(num1, num2);
             Console.WriteLine($"O número maior é o : {numM}.");
        }
        static int calculoMaior(int n1, int n2)
        {
                if (n1 > n2) return n1;
                return n2;

          //  return n1 > n2 ? n1 : n2;
        }
        static void Exercicio2()
        {
                Console.WriteLine("Insira o raio:");
                double raio = Convert.ToDouble(Console.ReadLine());
                double volume = calculoVolume(raio);
                Console.WriteLine($"O volume do círculo é {volume:N1}cm³");
        }
        static double calculoVolume(double raio)
        {
                double calcVolume = 4.1888 * Math.Pow(raio,3);
                return calcVolume;
        }
        static void Exercicio3()
        {
            Console.WriteLine("Insira sua idade (Anos, meses, dias)");
            decimal anos = Convert.ToDecimal(Console.ReadLine());
            decimal meses = Convert.ToDecimal(Console.ReadLine());
            decimal dias = Convert.ToDecimal(Console.ReadLine());
            decimal idade = calcIdade(anos, meses, dias);
            Console.WriteLine($"A sua idade em dias é: {idade}");
        }
        static decimal calcIdade(decimal anos, decimal meses, decimal dias)
        {
            //  DateTime.

            //DateTime.IsLeapYear(2020);

           // DateTime.DaysInMonth(2020, 2);

            anos *= 365;
            meses *= 30;
            return anos + meses + dias;
        }
        static void Exercicio4()
        {
            Console.WriteLine("Insira base e potência");
            int baseP = Convert.ToInt32(Console.ReadLine());
            int expoente = Convert.ToInt32(Console.ReadLine());
            int calculoP = potencia(baseP, expoente);
            Console.WriteLine(calculoP);
        }
        static int potencia (int b, int e)
        {
            //return Convert.ToInt32( Math.Pow(b, e));
            int contador = e;
            if (contador == 0)
                return 1;
            else
                return b * potencia(b,e-1);
        }
        static void Exercicio5()
        {
            //10: 10, 05, 02, 01 (4)
            Console.WriteLine("Insira um valor:");
            int valor = Convert.ToInt32(Console.ReadLine());
            int quantidade = divisores(valor);
            Console.WriteLine(quantidade);
        }
        static int divisores(int valor)
        {
            int calculo = 0;
            for (int i = 1; valor >= i; i++) calculo += (valor % i) == 0 ? 1 : 0;
            return calculo;
        }
        static void Exercicio6()
        {
            Console.WriteLine("Insira a nota do aluno:");
            decimal nota = Convert.ToDecimal(Console.ReadLine());
            char conceito = funcaoNotas(nota);
            Console.WriteLine(conceito);
        }
        static char funcaoNotas(decimal notas)
        {
            if (notas >= 9 && notas <= 10) return 'A';
            else if (notas >= 7 && notas < 9) return 'B';
            else if (notas >= 5 && notas < 7) return 'C';
            else return 'D';
        }
        static void Exercicio7()
        {
            Console.WriteLine("Insira o valor de n:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insira o valor de k:");
            int k = Convert.ToInt32(Console.ReadLine());
            int kesimo = k_esimoRecursivo(n, k);
            Console.WriteLine(kesimo);
        }
        //static int kesimoDigito(int n, int k)
        //{
        //    double contador = 1;
        //    int casaDecimal = 10;
        //    int zero = k;
        //    double valorK = Convert.ToDouble(k);
        //    for (int i = 1; zero != 0; i++)
        //    {
        //        zero--;
        //        if (i == casaDecimal)
        //        {
        //            contador++;
        //            casaDecimal *= 10;
        //        }
        //    }
        //    while  (contador != n)
        //    {
        //        valorK -= Math.Pow(10, contador - 1);
        //        if (valorK < Math.Pow(10, contador - 1)) contador--;
        //    }
        //    if(valorK > 10 && valorK != 0)
        //    {
        //        valorK /= Math.Pow(10,contador - 1);
        //    }
        //    // k = Convert.ToInt32(valorK);

        //    k = Convert.ToInt32(Math.Floor(valorK));
        //    return k;
        //}

        //static int k_esimodigito(int n, int k)
        //{
        //    int divisor = Convert.ToInt32(Math.Pow(10, k - 1));

        //    int divisao = n / divisor;

        //    return divisao % 10;
        //}

        static int k_esimoRecursivo(int n, int k)
        {
            if (k == 1)
                return n % 10;
            else
                return k_esimoRecursivo(n / 10, k - 1);
        }

    }
}
