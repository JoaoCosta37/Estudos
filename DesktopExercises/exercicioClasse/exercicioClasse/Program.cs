using exercicioClasse.FormasGeometricas;
using exercicioClasse.Supermercado;
using System;
using exercicioClasse.InstituicaoEnsino;
using System.Xml.Serialization;
using System.IO;

namespace exercicioClasse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExercicioQuadrado();
            //ExercicioTriangulo();
            //ExercicioSupermercado();
            //ExercicioInstituicao();
            //CalculoSalario();
            ExercicioContaBancaria();
        }
        static void CalculoSalario()
        {
            decimal salarioFinal = 0;
            decimal salarioInicial = 0.01m;

            for (decimal i = 1; i <= 30; i++)
            {
                for(int j = 1; j <= i; j++)
                {

                }
            }
            Console.WriteLine(salarioFinal);
        }
        static void ExercicioQuadrado()
        {
            Console.WriteLine("Insira o valor do lado do quadrado");
            int ladoQuadrado = Convert.ToInt32(Console.ReadLine());
            Quadrado quadrado = new Quadrado(ladoQuadrado);
            Console.WriteLine($" área do quadrado é: {quadrado.calculoArea()} e o perímetro é: {quadrado.calculoPerimetro()}");
        
        }
        static void ExercicioTriangulo()
        {
            Console.WriteLine("Insira o 1º lado do triangulo:");
            int lado1 = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("Insira o 2º lado do triangulo:");
            int lado2 = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("Insira o 3º lado do triangulo:");
            int lado3 = Convert.ToInt32(Console.ReadLine());

            Triangulo triangulo = new Triangulo(lado1, lado2, lado3);

         //   Program.ExercicioTriangulo();

          //  Triangulo.

            if (triangulo.IsEquilatero())
                Console.WriteLine("O triangulo é Equilátero");
            else  if (triangulo.IsEscaleno())
                Console.WriteLine("O triangulo é Escaleno");
            else
                Console.WriteLine("O triangulo é Isoceles");

            //triangulo.
        }
        static void ExercicioSupermercado()
        {
            Produto arroz = new Produto();
            arroz.QuantidadeEstoque = 100;
            arroz.Preco = 150.000M;

            Produto feijao = new Produto();
            feijao.Preco = 1.50M;
            feijao.QuantidadeEstoque = 5000;

            Pedido Rafael = new Pedido();


            Item item1 = new Item();

            item1.Produto = arroz;
            item1.QuantidadeProduto = 20;

            
            Rafael.Itens.Add(item1);

            Item item2 = new Item();

            item2.Produto = feijao;
            item2.QuantidadeProduto = 30;

            Rafael.Itens.Add(item2);

            Console.WriteLine(Rafael.ValorTotal());

        }
        static void ExercicioInstituicao()
        {
            Endereco endereco1 = new Endereco();
            endereco1.rua = "Manoel Gomes Gonçalves";
            endereco1.numero = 434;
            endereco1.bairro = "Jardim Padroeira";


            Instituicao instituicao1 = new Instituicao();

            instituicao1.endereco = endereco1;

            Departamento departamento1 = new Departamento();

           
            departamento1.nome = "Teologia";

           // Console.WriteLine(departamento1.GetId());

            Departamento departamento2 = new Departamento();
            departamento2.nome = "Graduação Marsili";

            //departamento2.AdicionarCurso()

            //departamento1.Id

            Console.WriteLine(departamento1.Id);

          //  departamento1.Id = 0;



            instituicao1.departamentos.Add(departamento1);
            instituicao1.departamentos.Add(departamento2);

            XmlSerializer x = new XmlSerializer(typeof(Instituicao));
            TextWriter writer = new StreamWriter(@"C:\Temp\arquivo.xml");
            x.Serialize(writer, instituicao1);

            writer.Flush();

        }
        static void ExercicioContaBancaria()
        {
            try
            {
                //Exceção capturar 
                ContaBancaria conta1 = new ContaBancaria();
                conta1.Saldo = 1050100.56;
                conta1.sacar(1000);
                conta1.sacar(1050100.56);
           
                Console.WriteLine(conta1.getSaldoFormatado());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                     
            }
        }
    }
}
