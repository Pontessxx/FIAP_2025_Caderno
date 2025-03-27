/* 
    Hands on

    - Crie classes para um sistema de controle de estacionamento
    - Considere informações como tipo de veículo, marca, modelo, cor e placa
    - Proponha classes para o gerenciamento de clientes serviços e pagamentos

*/
Estacionamento estacionamento = new Estacionamento();
bool continuar = true;

while (continuar)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Adicionar Cliente e Veículo");
    Console.WriteLine("2. Listar Veículos Estacionados");
    Console.WriteLine("3. Realizar Pagamento");
    Console.WriteLine("4. Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            // Coletando informações do cliente
            Console.WriteLine("Digite o nome do cliente:");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite o documento do cliente (CPF/CNPJ):");
            string documentoCliente = Console.ReadLine();

            Console.WriteLine("Digite o telefone do cliente:");
            string telefoneCliente = Console.ReadLine();

            // Criando instância de Cliente
            Cliente cliente1 = new Cliente(nomeCliente, documentoCliente, telefoneCliente);

            // Coletando informações do veículo
            Console.WriteLine("Digite o tipo do veículo (Carro/Moto/Caminhão):");
            string tipoVeiculo = Console.ReadLine();

            Console.WriteLine("Digite a marca do veículo:");
            string marcaVeiculo = Console.ReadLine();

            Console.WriteLine("Digite o modelo do veículo:");
            string modeloVeiculo = Console.ReadLine();

            Console.WriteLine("Digite a cor do veículo:");
            string corVeiculo = Console.ReadLine();

            Console.WriteLine("Digite a placa do veículo:");
            string placaVeiculo = Console.ReadLine();

            // Criando instância de Veiculo
            Veiculo meuCarro = new Veiculo(tipoVeiculo, marcaVeiculo, modeloVeiculo, corVeiculo, placaVeiculo);

            // Adicionando veículo ao estacionamento
            estacionamento.AdicionarVeiculo(meuCarro, cliente1);
            break;

        case "2":
            // Listando veículos estacionados
            estacionamento.ListarVeiculos();
            break;

        case "3":
            // Coletando informações do pagamento
            Console.WriteLine("Digite o valor do pagamento:");
            string valorPagamentoInput = Console.ReadLine();
            float valorPagamento;

            // Verificando se a entrada é válida
            while (!float.TryParse(valorPagamentoInput, out valorPagamento))
            {
                Console.WriteLine("Valor inválido. Por favor, digite um valor numérico:");
                valorPagamentoInput = Console.ReadLine();
            }

            // Criando um pagamento
            Pagamento pagamento = new Pagamento(cliente1, valorPagamento);
            pagamento.ImprimirInformacoes();
            break;

        case "4":
            continuar = false;
            Console.WriteLine("Saindo do sistema...");
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

}