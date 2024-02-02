using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{

    public class Carro
    {
        public string Placa {get; set; }
        public DateTime HoraEntrada {get; set; }


        public Carro(string placa)
        {
            Placa = placa;
            HoraEntrada = DateTime.Now;
        }
    }
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Carro> veiculos = new List<Carro>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI* ---------------------------------------------------------------------------------------DONE!!!
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine();

            // Validação da placa usando Regex
            if (Regex.IsMatch(placa, @"^[A-Z]{3}\d{4}$"))
            {
                // Verifica se o veículo já está cadastrado
                if (veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Esse veículo já está cadastrado no estacionamento.");
                }
                else
                {
                    veiculos.Add(new Carro(placa.ToUpper()));
                    Console.WriteLine($"Veículo com a placa {placa} adicionado com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Placa inválida. Certifique-se de que a placa está no formato correto (AAA1234).");
            }
                   
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI* ---------------------------------------------------------------------------------------DONE!!!
            string placa = Console.ReadLine();

            // Verifica se o veículo existe

             if (veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());

                Carro carro = veiculos.First(x => x.Placa.ToUpper() == placa.ToUpper());
                veiculos.Remove(carro);

                decimal valorTotal = precoInicial + (precoPorHora * horas);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }

            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI* ---------------------------------------------------------------------------------------DONE!!!
                foreach(Carro carro in veiculos)
                {
                    Console.WriteLine($"Placa: {carro.Placa}, Hora de entrada: {carro.HoraEntrada}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
