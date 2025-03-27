public class Veiculo
{
    public string Tipo { get; set; } // Ex: Carro, Moto, Caminhão
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public string Placa { get; set; }

    public Veiculo(string tipo, string marca, string modelo, string cor, string placa)
    {
        Tipo = tipo;
        Marca = marca;
        Modelo = modelo;
        Cor = cor;
        Placa = placa;
    }

    public void ImprimirInformacoes()
    {
        Console.WriteLine($"Tipo: {Tipo}");
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Cor: {Cor}");
        Console.WriteLine($"Placa: {Placa}");
    }
}