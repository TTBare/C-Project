using System.Collections.Generic;

public static class PedidoDataAccess
{
    private static List<Pedido> pedidos = new List<Pedido>();

    public static List<Pedido> ObtenerPedidos()
    {
        return pedidos;
    }

    public static void AgregarPedido(Pedido pedido)
    {
        pedido.Id = pedidos.Count + 1; // Asignar un ID automático.
        pedidos.Add(pedido);
    }

    public static void EliminarPedido(int id)
    {
        Pedido pedido = pedidos.Find(p => p.Id == id);
        if (pedido != null)
        {
            pedidos.Remove(pedido);
        }
    }

    public static Pedido ObtenerPedidoPorId(int id)
    {
        return pedidos.Find(p => p.Id == id);
    }
}
