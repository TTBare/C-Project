using System;
using System.Collections.Generic;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaPedido { get; set; }
    public List<ProductoPedido> Productos { get; set; }
    public decimal Total { get; set; }

    public Pedido()
    {
        Productos = new List<ProductoPedido>();
    }
}
