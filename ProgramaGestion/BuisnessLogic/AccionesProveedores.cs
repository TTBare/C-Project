using System;

public static class AccionesProveedor
{
    public static void CrearProveedor()
    {
        Console.Clear();
        Console.WriteLine("Crear Proveedor");
        Proveedor proveedor = new Proveedor();
        Console.Write("Nombre: ");
        proveedor.Nombre = Console.ReadLine();
        Console.Write("Dirección: ");
        proveedor.Direccion = Console.ReadLine();
        Console.Write("Teléfono: ");
        proveedor.Telefono = Console.ReadLine();
        Console.Write("Email: ");
        proveedor.Email = Console.ReadLine();
        ProveedorDataAccess.AgregarProveedor(proveedor);
        Console.WriteLine("Proveedor creado con éxito.");
        MenuServicios.Pausar();
    }

    public static void EliminarProveedor()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Proveedor");
        Console.Write("ID del Proveedor: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            ProveedorDataAccess.EliminarProveedor(id);
            Console.WriteLine("Proveedor eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ModificarProveedor()
    {
        Console.Clear();
        Console.WriteLine("Modificar Proveedor");
        Console.Write("ID del Proveedor: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Proveedor proveedor = ProveedorDataAccess.ObtenerProveedorPorId(id);
            if (proveedor != null)
            {
                Console.Write($"Nombre ({proveedor.Nombre}): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nombre)) proveedor.Nombre = nombre;

                Console.Write($"Dirección ({proveedor.Direccion}): ");
                string direccion = Console.ReadLine();
                if (!string.IsNullOrEmpty(direccion)) proveedor.Direccion = direccion;

                Console.Write($"Teléfono ({proveedor.Telefono}): ");
                string telefono = Console.ReadLine();
                if (!string.IsNullOrEmpty(telefono)) proveedor.Telefono = telefono;

                Console.Write($"Email ({proveedor.Email}): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) proveedor.Email = email;

                ProveedorDataAccess.ModificarProveedor(proveedor);
                Console.WriteLine("Proveedor modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Proveedor no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ConsultarProveedor()
    {
        Console.Clear();
        Console.WriteLine("Consultar Proveedor");
        Console.Write("ID del Proveedor: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Proveedor proveedor = ProveedorDataAccess.ObtenerProveedorPorId(id);
            if (proveedor != null)
            {
                Console.WriteLine($"Nombre: {proveedor.Nombre}");
                Console.WriteLine($"Dirección: {proveedor.Direccion}");
                Console.WriteLine($"Teléfono: {proveedor.Telefono}");
                Console.WriteLine($"Email: {proveedor.Email}");
            }
            else
            {
                Console.WriteLine("Proveedor no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ListarProveedores()
    {
        Console.Clear();
        Console.WriteLine("Listar Todos los Proveedores");
        foreach (var proveedor in ProveedorDataAccess.ObtenerProveedores())
        {
            Console.WriteLine($"ID: {proveedor.Id} - Nombre: {proveedor.Nombre} - Dirección: {proveedor.Direccion} - Teléfono: {proveedor.Telefono} - Email: {proveedor.Email}");
        }
        MenuServicios.Pausar();
    }
}
