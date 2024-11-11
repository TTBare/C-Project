using System;

public static class MenuFacturas
{
    public static void AdministrarFacturas()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("Administrar Facturas");
            Console.WriteLine("1. Crear Factura");
            Console.WriteLine("2. Consultar Factura");
            Console.WriteLine("3. Listar todas las Facturas");
            Console.WriteLine("4. Volver");
            int opcion = MenuServicios.LeerOpcion();

            switch (opcion)
            {
                case 1:
                    AccionesFactura.CrearFactura();
                    break;
                case 2:
                    AccionesFactura.ConsultarFactura();
                    break;
                case 3:
                    AccionesFactura.ListarFacturas();
                    break;
                case 4:
                    back = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                    MenuServicios.Pausar();
                    break;
            }
        }
    }
}
