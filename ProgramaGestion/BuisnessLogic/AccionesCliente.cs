using System;

public static class AccionesCliente
{
    public static void CrearCliente()
    {
        Console.Clear();
        Console.WriteLine("Crear Cliente");
        Cliente cliente = new Cliente();
        Console.Write("Nombre: ");
        cliente.Nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        cliente.Apellido = Console.ReadLine();
        Console.Write("Email: ");
        cliente.Email = Console.ReadLine();
        Console.Write("Teléfono: ");
        cliente.Telefono = Console.ReadLine();
        ClienteDataAccess.AgregarCliente(cliente);
        Console.WriteLine("Cliente creado con éxito.");
        MenuServicios.Pausar();
    }

    public static void EliminarCliente()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Cliente");
        Console.Write("ID del Cliente: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            ClienteDataAccess.EliminarCliente(id);
            Console.WriteLine("Cliente eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ModificarCliente()
    {
        Console.Clear();
        Console.WriteLine("Modificar Cliente");
        Console.Write("ID del Cliente: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Cliente cliente = ClienteDataAccess.ObtenerClientePorId(id);
            if (cliente != null)
            {
                Console.Write($"Nombre ({cliente.Nombre}): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nombre)) cliente.Nombre = nombre;

                Console.Write($"Apellido ({cliente.Apellido}): ");
                string apellido = Console.ReadLine();
                if (!string.IsNullOrEmpty(apellido)) cliente.Apellido = apellido;

                Console.Write($"Email ({cliente.Email}): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) cliente.Email = email;

                Console.Write($"Teléfono ({cliente.Telefono}): ");
                string telefono = Console.ReadLine();
                if (!string.IsNullOrEmpty(telefono)) cliente.Telefono = telefono;

                ClienteDataAccess.ModificarCliente(cliente);
                Console.WriteLine("Cliente modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ConsultarCliente()
    {
        Console.Clear();
        Console.WriteLine("Consultar Cliente");
        Console.Write("ID del Cliente: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Cliente cliente = ClienteDataAccess.ObtenerClientePorId(id);
            if (cliente != null)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre}");
                Console.WriteLine($"Apellido: {cliente.Apellido}");
                Console.WriteLine($"Email: {cliente.Email}");
                Console.WriteLine($"Teléfono: {cliente.Telefono}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ListarClientes()
    {
        Console.Clear();
        Console.WriteLine("Listar Todos los Clientes");
        foreach (var cliente in ClienteDataAccess.ObtenerClientes())
        {
            Console.WriteLine($"ID: {cliente.Id} - Nombre: {cliente.Nombre} {cliente.Apellido} - Email: {cliente.Email} - Teléfono: {cliente.Telefono}");
        }
        MenuServicios.Pausar();
    }
}
