using System.Collections.Generic;

public static class ProductoDataAccess
{
    private static List<Producto> productos = new List<Producto>();

    public static List<Producto> ObtenerProductos()
    {
        return productos;
    }

    public static void AgregarProducto(Producto producto)
    {
        producto.Id = productos.Count + 1; // Asignar un ID automático.
        productos.Add(producto);
    }

    public static void EliminarProducto(int id)
    {
        Producto producto = productos.Find(p => p.Id == id);
        if (producto != null)
        {
            productos.Remove(producto);
        }
    }

    public static void ModificarProducto(Producto productoModificado)
    {
        Producto producto = productos.Find(p => p.Id == productoModificado.Id);
        if (producto != null)
        {
            producto.Nombre = productoModificado.Nombre;
            producto.Precio = productoModificado.Precio;
            producto.Descripcion = productoModificado.Descripcion;
            producto.Stock = productoModificado.Stock;
            producto.Categoria = productoModificado.Categoria;
        }
    }

    public static Producto ObtenerProductoPorId(int id)
    {
        return productos.Find(p => p.Id == id);
    }
}
