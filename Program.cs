using System;
using System.Collections.Generic;
using System.Globalization;

List<string> VeiculosEstacionados = new List<string>();

Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!");
Console.WriteLine("Digite o preço inicial:");
decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Digite o preço por hora:");
decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());

bool executando = true;

do
{
    Console.WriteLine("\nDigite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Sair");

    int opcao = Convert.ToInt32(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine(); // CORRIGIDO: faltava atribuição correta

            if (!string.IsNullOrWhiteSpace(placa))
            {
                VeiculosEstacionados.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
            }
            break;

        case 2:
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placaRemover = Console.ReadLine();

            if (VeiculosEstacionados.Contains(placaRemover))
            {
                Console.WriteLine("Digite o tempo estacionado (formato HH:mm):");
                string tempo = Console.ReadLine();

                 if (TimeSpan.TryParse(tempo, out TimeSpan tempoEstacionado))

                    {
                        decimal totalMinutos = (decimal)tempoEstacionado.TotalMinutes;
                    decimal precoPorMinuto = precoPorHora / 60;
                    decimal precoAPagar = precoInicial + (precoPorMinuto * totalMinutos);

                    VeiculosEstacionados.Remove(placaRemover);

                    Console.WriteLine($"O veículo {placaRemover} foi removido e o preço foi de R$ {precoAPagar:F2}");
                }
                else
                {
                    Console.WriteLine("Formato de tempo inválido. Use HH:mm (ex: 3:45).");
                }
            }
            else
            {
                Console.WriteLine("Placa não encontrada...");
            }
            break;

        case 3:
            Console.WriteLine("Listando veículos estacionados:");
            if (VeiculosEstacionados.Count == 0)
            {
                Console.WriteLine("Nenhum veículo estacionado...");
            }
            else
            {
                foreach (var veiculo in VeiculosEstacionados)
                {
                    Console.WriteLine(veiculo);
                }
            }
            break;

        case 4:
            Console.WriteLine("Saindo do sistema...");
            executando = false;
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

} while (executando);
