public class ProductoPedido
{
    public int ProductoId { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal SubTotal
    {
        get
        {
            return Cantidad * PrecioUnitario;
        }
    }
}