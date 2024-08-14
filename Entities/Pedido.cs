namespace MyApp.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public List<Producto> Productosdepedido {get;set;}
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
