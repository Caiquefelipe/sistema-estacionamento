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
            string placa = Console.ReadLine();
            if (placa != null)
            {
                VeiculosEstacionados.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso!");

            }
            break;

        case 2:
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placaRemover = Console.ReadLine();

            if (VeiculosEstacionados.Contains(placaRemover))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horasEstacionado = Convert.ToInt32(Console.ReadLine());

                decimal precoAPagar = precoInicial + (precoPorHora * horasEstacionado);
                VeiculosEstacionados.Remove(placaRemover);

                Console.WriteLine($"O veículo {placaRemover} foi removido e o preço foi de R$ {precoAPagar}");
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
}
while (executando);
