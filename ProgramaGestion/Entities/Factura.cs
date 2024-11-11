public class Factura
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaEmision { get; set; }
    public List<ProductoPedido> Productos { get; set; }
    public decimal Total { get; set; }

    public Factura()
    {
        Productos = new List<ProductoPedido>();
    }
}
