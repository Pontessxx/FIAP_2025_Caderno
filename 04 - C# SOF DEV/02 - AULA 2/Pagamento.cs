public class Pagamento
{
    public Cliente Cliente { get; set; }
    public float Valor { get; set; }
    public DateTime DataPagamento { get; set; }

    public Pagamento(Cliente cliente, float valor)
    {
        Cliente = cliente;
        Valor = valor;
        DataPagamento = DateTime.Now;
    }

    public void ImprimirInformacoes()
    {
        Console.WriteLine($"Cliente: {Cliente.Nome}");
        Console.WriteLine($"Valor: {Valor:C}");
        Console.WriteLine($"Data do Pagamento: {DataPagamento}");
    }
}