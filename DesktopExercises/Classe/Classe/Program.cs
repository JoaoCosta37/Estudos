using Classe.FormasGeometricas;
using Classe.Ingressos;
using System;
using System.Collections.Generic;
using Classe.ProdutoReal;
using Classe.ContaBancariaHeranca;
using Classe.Transportes;
using Classe.Equipamentos;
using Classe.FormarGeometricas2;
using Classe.ContaBancaria;
using Classe.Employees;

namespace Classe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exercicio_Data();
            //Banco_Contas();
            //ListaVetores();
            //Ingressos();
            // ProdutoReal();
            //ContaBancaria();
            //Transporte();
            TestaEmployee();
        }
        static void Exercicio_Data()
        {
            Console.WriteLine("Dia:");
            sbyte dia = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("Mês:");
            sbyte mes = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("Ano:");
            int ano = Convert.ToInt32(Console.ReadLine());


            Data data = new Data(dia,mes,ano);
            Console.WriteLine(data.FormatoDDMMAAAA());
            Console.WriteLine(data.FormatoDDMESAAAA());
            Console.WriteLine(data.FormatoAAAAMMDD());
            Console.WriteLine(data.Semestre());

        }
        static void Banco_Contas()
        {

            Banco itau = new Banco();
            itau.codigo = 1;
            itau.descricao = "premium";


            ContaBancaria.ContaCorrente joao = new ContaBancaria.ContaCorrente();

            joao.numero = 1;
            joao.saldo = 5000;
            joao.statusEspecial = false;
            joao.limite = 0;

            itau.contas.Add(joao);


            Movimentacao movimentacao = new Movimentacao();
            movimentacao.descricao = "TED RFB";
            movimentacao.tipo = 'C';
            movimentacao.valor = 5000;


            joao.movimentacoes.Add(movimentacao);

            joao.sacar(100);

            joao.depositar(550);
        }
        static void ListaVetores()
        {
            const int quantidadeVetor = 1;
            int[] idade = new int[quantidadeVetor];
            string[] nome = new string[quantidadeVetor];
            bool[] festa = new bool[quantidadeVetor];
            char[] sexo = new char[quantidadeVetor];

            for(int i = 0; i < quantidadeVetor; i++)
            {
                idade[i] = Convert.ToInt32(Console.ReadLine());
                nome[i] = (Console.ReadLine());
                festa[i] = Convert.ToBoolean(Console.ReadLine());
                sexo[i] = Convert.ToChar(Console.ReadLine());
            }
            List<int> dados;
            dados = new List<int>();

            for (int i= 0; i < idade.Length; i++)
            {
                
                Console.WriteLine(nome[i]);
                Console.WriteLine(idade[i]);
                Console.WriteLine(sexo[i]);
                if (festa[i] == true)
                    Console.WriteLine("Vai colar");
                else
                {
                    if (sexo[i] == 'M')
                    {
                        dados.Add(idade[i]);
                        Console.WriteLine("Vacilão/Trouxa viadinho");
                    }
                        

                    else
                        Console.WriteLine("Vacilona");
                }
                
            }
            Console.WriteLine(dados[0]);
        }

        static void Heranca()
        {
            PessoaFisica pessoaFisica = new PessoaFisica();

           // Pessoa pessoa = new Pessoa();

            // pessoaFisica.
            //  pessoaFisica.

            AdicionarPessoa(pessoaFisica);
        }
     
        static void AdicionarPessoa(Pessoa pessoa)
        {

        }

        static void Formas()
        {
           var formas = new List<FiguraGeometrica>();

            formas.Add(new FormarGeometricas2.Quadrado());
            formas.Add(new FormarGeometricas2.Retangulo());
            formas.Add(new FormarGeometricas2.Círculo());
            //  formas.Add(new Triangulo());

            SomaAreas(formas);
        }

        static void Ingressos()
        {
            var ingresso = new Ingresso();

            Console.WriteLine(ingresso.ToString());

        }

        static void SomaAreas(List<FiguraGeometrica> formas)
        {
            decimal somaAreas = 0;
            foreach(var forma in formas)
            {
              somaAreas +=  forma.CalcularArea();
            }
        }
        static void ProdutoReal()
        {

            Produto bolacha = new Produto();

            Console.WriteLine("Insira o valor de Custo do produto:");
            bolacha.PrecoCusto = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Insira o valor de Venda do produto:");
            bolacha.PrecoVenda = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(nameof(bolacha));

            //Console.WriteLine(bolacha.ToString); é possível imprimir o nome da referencia ao objeto?????????????

           // Console.WriteLine(bolacha.calcularMargemLucro(bolacha.PrecoCusto, bolacha.PrecoVenda));
            //Console.WriteLine(bolacha.calcularMargemLucroPorcentual(bolacha.PrecoCusto, bolacha.PrecoVenda));
        }
        static void ContaBancaria()
        {
            Cliente joao = new Cliente();
            joao.Nome = "João Costa";
            Console.WriteLine(joao.ToString());

            ContaBancariaHeranca.ContaCorrente contaCorrenteRafael = new ContaBancariaHeranca.ContaCorrente(5000);

            ContaBancariaHeranca.ContaCorrente contaCorrenteJoao = new ContaBancariaHeranca.ContaCorrente(80000);
            
            ContaEspecial prime = new ContaEspecial(1000,3000);


            contaCorrenteRafael.transferir(400, contaCorrenteJoao);
            contaCorrenteRafael.transferir(400, prime);


            //prime.s
            // prime.saldo
        }
        static void Transporte()
        {
            Transporte carro = new Transporte();
           // carro.velocidade = 100;
            carro.ligado = true;
            //carro.desliga();
           // Console.WriteLine($"{carro.velocidade}, {carro.ligado}");
        }

        static void TestaEquipamento()
        {
            EquipamentoSonoro equipamentoSonoro = EquipamentoSonoro.CriarEquipamentoComVolume(5);

           // TimeSpan timeSpan = new TimeSpan(2, 30, 5);
           // TimeSpan timeSpan2 = new TimeSpan(2, 0, 0);

           // TimeSpan.FromHours(2);

        }

        static void TestaTransporte()
        {
            Carro carro = new Carro();

           // Console.WriteLine(carro.quilometragem);


        }
        static void TestaEmployee()
        {
            // Employee employee = new Employee("João", "Costa", "123");

            //try
            //{
            //    SalariedEmployee salariedEmployee = new SalariedEmployee("John", "Cost", "1234", -5000);
            //    Console.WriteLine("Construiu o objeto");
            //}
            //catch (ArgumentException aException)
            //{
            //    Console.WriteLine(aException.Message);
            //}

            //Console.WriteLine("Fim");
            SalariedEmployee thiago = new SalariedEmployee("Thiago", "Delanhese", "98", 2000);
            SalariedEmployee joao = new SalariedEmployee("João", "Costa", "2836", 8000);
            HourlyEmployee rafael = new HourlyEmployee("Rafael", "Delanhese", "01",150,40);
            HourlyEmployee guilherme = new HourlyEmployee("Guilherme", "Roque", "1245", 80, 40);

            List<Employee> employees = new List<Employee>
            {
                joao,
                rafael,
                thiago,
                guilherme
            };
            var sum = 0M;
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
                var earning = employee.CalculateEarnings();
                sum += earning;
                Console.WriteLine(earning);
            }
            Console.WriteLine(sum);

        }
    }
}
