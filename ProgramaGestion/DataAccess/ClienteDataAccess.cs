using System.Collections.Generic;

public static class ClienteDataAccess
{
    private static List<Cliente> clientes = new List<Cliente>();

    public static List<Cliente> ObtenerClientes()
    {
        return clientes;
    }

    public static void AgregarCliente(Cliente cliente)
    {
        cliente.Id = clientes.Count + 1; // Asignar un ID automático.
        clientes.Add(cliente);
    }

    public static void EliminarCliente(int id)
    {
        Cliente cliente = clientes.Find(c => c.Id == id);
        if (cliente != null)
        {
            clientes.Remove(cliente);
        }
    }

    public static void ModificarCliente(Cliente clienteModificado)
    {
        Cliente cliente = clientes.Find(c => c.Id == clienteModificado.Id);
        if (cliente != null)
        {
            cliente.Nombre = clienteModificado.Nombre;
            cliente.Apellido = clienteModificado.Apellido;
            cliente.Email = clienteModificado.Email;
            cliente.Telefono = clienteModificado.Telefono;
        }
    }

    public static Cliente ObtenerClientePorId(int id)
    {
        return clientes.Find(c => c.Id == id);
    }
}
