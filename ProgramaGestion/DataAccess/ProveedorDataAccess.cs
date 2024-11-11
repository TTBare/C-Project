using System.Collections.Generic;

public static class ProveedorDataAccess
{
    private static List<Proveedor> proveedores = new List<Proveedor>();

    public static List<Proveedor> ObtenerProveedores()
    {
        return proveedores;
    }

    public static void AgregarProveedor(Proveedor proveedor)
    {
        proveedor.Id = proveedores.Count + 1; // Asignar un ID automático.
        proveedores.Add(proveedor);
    }

    public static void EliminarProveedor(int id)
    {
        Proveedor proveedor = proveedores.Find(p => p.Id == id);
        if (proveedor != null)
        {
            proveedores.Remove(proveedor);
        }
    }

    public static void ModificarProveedor(Proveedor proveedorModificado)
    {
        Proveedor proveedor = proveedores.Find(p => p.Id == proveedorModificado.Id);
        if (proveedor != null)
        {
            proveedor.Nombre = proveedorModificado.Nombre;
            proveedor.Direccion = proveedorModificado.Direccion;
            proveedor.Telefono = proveedorModificado.Telefono;
            proveedor.Email = proveedorModificado.Email;
        }
    }

    public static Proveedor ObtenerProveedorPorId(int id)
    {
        return proveedores.Find(p => p.Id == id);
    }
}
