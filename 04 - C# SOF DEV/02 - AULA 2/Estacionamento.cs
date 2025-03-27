
public class Estacionamento{
    private List<Veiculo> veiculosEstacionados = new List<Veiculo>();
    private List<Cliente> clientes = new List<Cliente>();

    public void AdicionarVeiculo(Veiculo veiculo, Cliente cliente)
    {
        veiculosEstacionados.Add(veiculo);
        clientes.Add(cliente);
        Console.WriteLine($"Veículo {veiculo.Placa} estacionado para o cliente {cliente.Nome}.");
    }

    public void ListarVeiculos()
    {
        Console.WriteLine("Veículos Estacionados:");
        foreach (var veiculo in veiculosEstacionados)
        {
            veiculo.ImprimirInformacoes();
            Console.WriteLine();
        }
    }
}