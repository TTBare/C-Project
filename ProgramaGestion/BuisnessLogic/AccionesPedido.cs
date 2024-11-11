using System;

public static class AccionesPedido
{
    public static void CrearPedido()
    {
        Console.Clear();
        Console.WriteLine("Crear Pedido");
        Pedido pedido = new Pedido();
        Console.Write("ID del Cliente: ");
        if (int.TryParse(Console.ReadLine(), out int clienteId))
        {
            pedido.ClienteId = clienteId;
            pedido.FechaPedido = DateTime.Now;

            bool agregarProductos = true;
            while (agregarProductos)
            {
                Console.Write("ID del Producto (0 para finalizar): ");
                if (int.TryParse(Console.ReadLine(), out int productoId) && productoId != 0)
                {
                    Producto producto = ProductoDataAccess.ObtenerProductoPorId(productoId);
                    if (producto != null)
                    {
                        Console.Write("Cantidad: ");
                        if (int.TryParse(Console.ReadLine(), out int cantidad))
                        {
                            ProductoPedido productoPedido = new ProductoPedido
                            {
                                ProductoId = producto.Id,
                                Nombre = producto.Nombre,
                                Cantidad = cantidad,
                                PrecioUnitario = producto.Precio
                            };
                            pedido.Productos.Add(productoPedido);
                            Console.WriteLine($"Producto {producto.Nombre} agregado al pedido.");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad inválida. Intente nuevamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                }
                else
                {
                    agregarProductos = false;
                }
            }

            pedido.Total = CalcularTotal(pedido);
            PedidoDataAccess.AgregarPedido(pedido);
            Console.WriteLine("Pedido creado con éxito.");
        }
        else
        {
            Console.WriteLine("ID del Cliente inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void EliminarPedido()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Pedido");
        Console.Write("ID del Pedido: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            PedidoDataAccess.EliminarPedido(id);
            Console.WriteLine("Pedido eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ConsultarPedido()
    {
        Console.Clear();
        Console.WriteLine("Consultar Pedido");
        Console.Write("ID del Pedido: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Pedido pedido = PedidoDataAccess.ObtenerPedidoPorId(id);
            if (pedido != null)
            {
                Console.WriteLine($"ID del Cliente: {pedido.ClienteId}");
                Console.WriteLine($"Fecha del Pedido: {pedido.FechaPedido}");
                Console.WriteLine("Productos:");
                foreach (var producto in pedido.Productos)
                {
                    Console.WriteLine($"- {producto.Nombre}, Cantidad: {producto.Cantidad}, Precio Unitario: {producto.PrecioUnitario}, SubTotal: {producto.SubTotal}");
                }
                Console.WriteLine($"Total: {pedido.Total}");
            }
            else
            {
                Console.WriteLine("Pedido no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ListarPedidos()
    {
        Console.Clear();
        Console.WriteLine("Listar Todos los Pedidos");
        foreach (var pedido in PedidoDataAccess.ObtenerPedidos())
        {
            Console.WriteLine($"ID: {pedido.Id}, Cliente ID: {pedido.ClienteId}, Fecha: {pedido.FechaPedido}, Total: {pedido.Total}");
        }
        MenuServicios.Pausar();
    }

    private static decimal CalcularTotal(Pedido pedido)
    {
        decimal total = 0;
        foreach (var producto in pedido.Productos)
        {
            total += producto.SubTotal;
        }
        return total;
    }
}
