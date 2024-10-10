using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace estagio_são_paulo
{
    public class FaturamentoDiarioDistribuidora
    {
        public DateOnly Data { get; set; }
        public decimal Valor { get; set; }
        public List<FaturamentoDiarioDistribuidora> Registros { get; set; }

        public FaturamentoDiarioDistribuidora()
        {
            Registros = new List<FaturamentoDiarioDistribuidora>();
        }
        public FaturamentoDiarioDistribuidora(DateOnly data, decimal valor) : this()
        {
            Data = data;
            Valor = valor;
        }

        public void AdicionarRegistro(DateOnly data, decimal valor)
        {
            Registros.Add(new FaturamentoDiarioDistribuidora(data, valor));
            Console.WriteLine("Registro adicionado com sucesso");
            EhDiaUtil(data);

        }

        public void RegistrarFaturamento()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite a data(dd/mm/aaaa) ou parar para parar de adicionar registros. ");
                var resposta = Console.ReadLine();

                if (resposta.ToLower() == "parar")
                {
                    break;
                }

                DateOnly data;
                while (!DateOnly.TryParse(resposta, out data))
                {
                    Console.WriteLine("Valor incorreto, digite novamente");
                    resposta = Console.ReadLine();
                }

                decimal valor;
                Console.WriteLine("Qual o valor do faturamento do dia?");

                while (!decimal.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine("Valor invalido, digite novamente");
                }
                AdicionarRegistro(data, valor);

            }

        }

        public void ListarRegistros(decimal maior, decimal menor, int quantidadeDeDiasAcimaDaMedia)
        {
            Console.WriteLine($"Menor valor de faturamento do mês: {menor}");
            Console.WriteLine($"Maior valor de faturamento do mês: {maior}");
            Console.WriteLine($"A quantidade de dias em que o faturamento diario ultrapassou a média: {quantidadeDeDiasAcimaDaMedia}");
            Console.ReadLine();
        }

       // comentar daqui 
        public void ListarRegistros()
        {
            Console.WriteLine("Registros adicionados:");
            foreach (var registro in Registros)
            {
                Console.WriteLine($"{registro.Data}: {registro.Valor}");
            }
        }
        // ate aqui

        public void CalcularEListarFaturamento()
        {
            decimal soma = 0;
            decimal media = 0;
            var menor = Registros.First().Valor;
            var maior = Registros.First().Valor;
            var quantidade = Registros.Count();


            foreach (var item in Registros)
            {
                if (!EhDiaUtil(item.Data))
                    continue;

                if (item.Valor < menor)
                    menor = item.Valor;

                if (item.Valor > maior)
                    maior = item.Valor;

                soma += item.Valor;

            }
            // se eu colocar mais de um registro aqui ele vai contar na media como dois dias 
            
            if (quantidade > 0)
            {
                foreach (var item in Registros)
                {
                    if (!EhDiaUtil(item.Data))
                    {
                        quantidade--;
                    }
                }
                    
                media = soma / quantidade;
            }
            else
            {
                Console.WriteLine("Sem Registro de faturamento diario, Insira antes de fazer uma leitura");
                Console.ReadLine();
                RegistrarFaturamento();

            }

            int quantidadeDeDiasAcimaDaMedia = 0;
            foreach (var item in Registros)
            {
                if (!EhDiaUtil(item.Data))
                    continue;
                if (item.Valor > media)
                {
                    quantidadeDeDiasAcimaDaMedia++;
                }
            }

            ListarRegistros(maior, menor, quantidadeDeDiasAcimaDaMedia);
        }

        public bool EhDiaUtil(DateOnly data)
        {
            List<DateOnly> feriados = new List<DateOnly>
            {
                new DateOnly(2024, 1, 1),
                new DateOnly(2024, 2, 12),
                new DateOnly(2024, 3, 29),
                new DateOnly(2024, 4, 21),
                new DateOnly(2024, 5, 1),
                new DateOnly(2024, 5, 30),
                new DateOnly(2024, 9, 7),
                new DateOnly(2024, 10, 12),
                new DateOnly(2024, 11, 2),
                new DateOnly(2024, 11, 15),
                new DateOnly(2024, 12, 25),
            };

            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday || feriados.Contains(data))
                return false;
            else
                return true;
        }
    }
}