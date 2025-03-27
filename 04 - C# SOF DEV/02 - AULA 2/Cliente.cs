public class Cliente
{
    public string Nome { get; set; }
    public string Documento { get; set; }
    public string Telefone { get; set; }

    public Cliente(string nome, string documento, string telefone)
    {
        Nome = nome;
        Documento = documento;
        Telefone = telefone;
    }

    public void ImprimirInformacoes()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Documento: {Documento}");
        Console.WriteLine($"Telefone: {Telefone}");
    }
}