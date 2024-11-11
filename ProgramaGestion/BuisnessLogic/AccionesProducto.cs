using System;

public static class AccionesProducto
{
    public static void CrearProducto()
    {
        Console.Clear();
        Console.WriteLine("Crear Producto");
        Producto producto = new Producto();
        Console.Write("Nombre: ");
        producto.Nombre = Console.ReadLine();
        Console.Write("Precio: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal precio))
        {
            producto.Precio = precio;
            Console.Write("Descripción: ");
            producto.Descripcion = Console.ReadLine();
            Console.Write("Stock: ");
            if (int.TryParse(Console.ReadLine(), out int stock))
            {
                producto.Stock = stock;
                Console.Write("Categoría: ");
                producto.Categoria = Console.ReadLine();
                ProductoDataAccess.AgregarProducto(producto);
                Console.WriteLine("Producto creado con éxito.");
            }
            else
            {
                Console.WriteLine("Stock inválido. Intente nuevamente.");
            }
        }
        else
        {
            Console.WriteLine("Precio inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void EliminarProducto()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Producto");
        Console.Write("ID del Producto: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            ProductoDataAccess.EliminarProducto(id);
            Console.WriteLine("Producto eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ModificarProducto()
    {
        Console.Clear();
        Console.WriteLine("Modificar Producto");
        Console.Write("ID del Producto: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Producto producto = ProductoDataAccess.ObtenerProductoPorId(id);
            if (producto != null)
            {
                Console.Write($"Nombre ({producto.Nombre}): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nombre)) producto.Nombre = nombre;

                Console.Write($"Precio ({producto.Precio}): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal precio)) producto.Precio = precio;

                Console.Write($"Descripción ({producto.Descripcion}): ");
                string descripcion = Console.ReadLine();
                if (!string.IsNullOrEmpty(descripcion)) producto.Descripcion = descripcion;

                Console.Write($"Stock ({producto.Stock}): ");
                if (int.TryParse(Console.ReadLine(), out int stock)) producto.Stock = stock;

                Console.Write($"Categoría ({producto.Categoria}): ");
                string categoria = Console.ReadLine();
                if (!string.IsNullOrEmpty(categoria)) producto.Categoria = categoria;

                ProductoDataAccess.ModificarProducto(producto);
                Console.WriteLine("Producto modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ConsultarProducto()
    {
        Console.Clear();
        Console.WriteLine("Consultar Producto");
        Console.Write("ID del Producto: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Producto producto = ProductoDataAccess.ObtenerProductoPorId(id);
            if (producto != null)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}");
                Console.WriteLine($"Precio: {producto.Precio}");
                Console.WriteLine($"Descripción: {producto.Descripcion}");
                Console.WriteLine($"Stock: {producto.Stock}");
                Console.WriteLine($"Categoría: {producto.Categoria}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ListarProductos()
    {
        Console.Clear();
        Console.WriteLine("Listar Todos los Productos");
        foreach (var producto in ProductoDataAccess.ObtenerProductos())
        {
            Console.WriteLine($"ID: {producto.Id} - Nombre: {producto.Nombre} - Precio: {producto.Precio} - Descripción: {producto.Descripcion} - Stock: {producto.Stock} - Categoría: {producto.Categoria}");
        }
        MenuServicios.Pausar();
    }
}
