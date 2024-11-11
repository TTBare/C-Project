using System.Collections.Generic;

public static class FacturaDataAccess
{
    private static List<Factura> facturas = new List<Factura>();

    public static List<Factura> ObtenerFacturas()
    {
        return facturas;
    }

    public static void AgregarFactura(Factura factura)
    {
        factura.Id = facturas.Count + 1; // Asignar un ID automático.
        facturas.Add(factura);
    }

    public static Factura ObtenerFacturaPorId(int id)
    {
        return facturas.Find(f => f.Id == id);
    }
}
