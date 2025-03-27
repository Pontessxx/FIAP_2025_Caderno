using System;
using System.Collections.Generic;

public class Veiculo
{
    public string Tipo { get; set; }
    public string Marca { get; set; }
    public string Cor { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }

//construtor
    public Veiculo(string tipo, string marca, string cor, string modelo, string placa)
    {
        Tipo = tipo;
        Marca = marca;
        Cor = cor;
        Modelo = modelo;
        Placa = placa;
    }
}

//classe cliente
public class Cliente
{
    public string Nome { get; set; }
    public string Documento { get; set; }
    public List<Veiculo> Veiculos { get; set; }

    public Cliente(string nome, string documento)
    {
        Nome = nome;
        Documento = documento;
        Veiculos = new List<Veiculo>();
    }

    public void AdicionarVeiculo(Veiculo veiculo)
    {
        Veiculos.Add(veiculo);
    }
}

public class Servico
{
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public Servico(string descricao, decimal preco)
    {
        Descricao = descricao;
        Preco = preco;
    }
}

public class Pagamento
{
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public string Metodo { get; set; }

    public Pagamento(decimal valor, string metodo)
    {
        Valor = valor;
        Metodo = metodo;
        Data = DateTime.Now;
    }
}

public class Estacionamento
{
    private List<Cliente> clientes;
    private List<Servico> servicos;

    public Estacionamento()
    {
        clientes = new List<Cliente>();
        servicos = new List<Servico>();
    }

    public void AdicionarCliente(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    public void AdicionarServico(Servico servico)
    {
        servicos.Add(servico);
    }

    public List<Cliente> GetClientes()
    {
        return clientes;
    }

    public void RealizarPagamento(Cliente cliente, decimal valor, string metodo)
    {
        Pagamento pagamento = new Pagamento(valor, metodo);
        Console.WriteLine($"Pagamento de {valor:C} realizado por {cliente.Nome} em {pagamento.Data} via {metodo}.");
    }

    public void ListarClientes()
    {
        if (clientes.Count == 0)
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return;
        }

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Cliente: {cliente.Nome} \nDocumento: {cliente.Documento}");
            foreach (var veiculo in cliente.Veiculos)
            {
                Console.WriteLine($" Veículo: {veiculo.Tipo} \nMarca: {veiculo.Marca} \nModelo: {veiculo.Modelo} \nPlaca: {veiculo.Placa}");
            }
        }
    }

    public void ListarServicos()
    {
        if (servicos.Count == 0)
        {
            Console.WriteLine("Nenhum serviço cadastrado.");
            return;
        }

        foreach (var servico in servicos)
        {
            Console.WriteLine($"Serviço: {servico.Descricao} - Preço: {servico.Preco:C}");
        }
    }
}

class Program
{
    static Estacionamento estacionamento = new Estacionamento();

    static void Main(string[] args)
    {
        bool rodando = true;
        
        // Adicionando alguns serviços para demonstração
        estacionamento.AdicionarServico(new Servico("Estacionamento Diurno", 10.00m));
        estacionamento.AdicionarServico(new Servico("Estacionamento Noturno", 15.00m));

        while (rodando)
        {
            Console.Clear();
            Console.WriteLine("===== Menu do Estacionamento =====");
            Console.WriteLine("1. Cadastrar Cliente e Veículo");
            Console.WriteLine("2. Listar Clientes e Veículos");
            Console.WriteLine("3. Realizar Pagamento");
            Console.WriteLine("4. Listar Serviços");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarClienteEVeiculo();
                    break;

                case 2:
                    estacionamento.ListarClientes();
                    Pausar();
                    break;

                case 3:
                    RealizarPagamento();
                    break;

                case 4:
                    estacionamento.ListarServicos();
                    Pausar();
                    break;

                case 5:
                    rodando = false;
                    Console.WriteLine("Saindo do programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Pausar();
                    break;
            }
        }
    }

    static void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void CadastrarClienteEVeiculo()
    {
        Console.WriteLine("\nDigite o nome do cliente:");
        string nomeCliente = Console.ReadLine();
        Console.WriteLine("Digite o documento do cliente:");
        string documentoCliente = Console.ReadLine();
        Cliente cliente = new Cliente(nomeCliente, documentoCliente);

        // Entrada de veículos
        Console.WriteLine($"Quantos veículos {nomeCliente} possui?");
        int numVeiculos = int.Parse(Console.ReadLine());
        for (int j = 0; j < numVeiculos; j++)
        {
            Console.WriteLine($"Digite o tipo do veículo {j + 1} (Ex: Carro, Moto):");
            string tipoVeiculo = Console.ReadLine();
            Console.WriteLine("Digite a marca do veículo:");
            string marcaVeiculo = Console.ReadLine();
            Console.WriteLine("Digite a cor do veículo:");
            string corVeiculo = Console.ReadLine();
            Console.WriteLine("Digite o modelo do veículo:");
            string modeloVeiculo = Console.ReadLine();
            Console.WriteLine("Digite a placa do veículo:");
            string placaVeiculo = Console.ReadLine();

            Veiculo veiculo = new Veiculo(tipoVeiculo, marcaVeiculo, corVeiculo, modeloVeiculo, placaVeiculo);
            cliente.AdicionarVeiculo(veiculo);
        }

        estacionamento.AdicionarCliente(cliente);
        Console.WriteLine($"Cliente {cliente.Nome} cadastrado com sucesso!");
        Pausar();
    }

    static void RealizarPagamento()
    {
        Console.WriteLine("\nDigite o nome do cliente para realizar o pagamento:");
        string nomePagamento = Console.ReadLine();
        
        Cliente clientePagamento = estacionamento.GetClientes().Find(c => c.Nome.Equals(nomePagamento, StringComparison.OrdinalIgnoreCase));

        if (clientePagamento != null)
        {
            Console.WriteLine("Digite o valor do pagamento:");
            decimal valorPagamento = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite o método de pagamento (Ex: Cartão de Crédito, Dinheiro):");
            string metodoPagamento = Console.ReadLine();

            estacionamento.RealizarPagamento(clientePagamento, valorPagamento, metodoPagamento);
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
        Pausar();
    }
}