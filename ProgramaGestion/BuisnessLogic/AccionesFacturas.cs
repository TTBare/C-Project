using System;

public static class AccionesFactura
{
    public static void CrearFactura()
    {
        Console.Clear();
        Console.WriteLine("Crear Factura");
        Factura factura = new Factura();
        Console.Write("ID del Cliente: ");
        if (int.TryParse(Console.ReadLine(), out int clienteId))
        {
            factura.ClienteId = clienteId;
            factura.FechaEmision = DateTime.Now;

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
                            factura.Productos.Add(productoPedido);
                            Console.WriteLine($"Producto {producto.Nombre} agregado a la factura.");
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

            factura.Total = CalcularTotal(factura);
            FacturaDataAccess.AgregarFactura(factura);
            Console.WriteLine("Factura creada con éxito.");
        }
        else
        {
            Console.WriteLine("ID del Cliente inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ConsultarFactura()
    {
        Console.Clear();
        Console.WriteLine("Consultar Factura");
        Console.Write("ID de la Factura: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Factura factura = FacturaDataAccess.ObtenerFacturaPorId(id);
            if (factura != null)
            {
                Console.WriteLine($"ID del Cliente: {factura.ClienteId}");
                Console.WriteLine($"Fecha de Emisión: {factura.FechaEmision}");
                Console.WriteLine("Productos:");
                foreach (var producto in factura.Productos)
                {
                    Console.WriteLine($"- {producto.Nombre}, Cantidad: {producto.Cantidad}, Precio Unitario: {producto.PrecioUnitario}, SubTotal: {producto.SubTotal}");
                }
                Console.WriteLine($"Total: {factura.Total}");
            }
            else
            {
                Console.WriteLine("Factura no encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ListarFacturas()
    {
        Console.Clear();
        Console.WriteLine("Listar Todas las Facturas");
        foreach (var factura in FacturaDataAccess.ObtenerFacturas())
        {
            Console.WriteLine($"ID: {factura.Id}, Cliente ID: {factura.ClienteId}, Fecha de Emisión: {factura.FechaEmision}, Total: {factura.Total}");
        }
        MenuServicios.Pausar();
    }

    private static decimal CalcularTotal(Factura factura)
    {
        decimal total = 0;
        foreach (var producto in factura.Productos)
        {
            total += producto.SubTotal;
        }
        return total;
    }
}
