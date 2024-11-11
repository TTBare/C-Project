using System;

public static class MenuProveedores
{
    public static void AdministrarProveedores()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("Administrar Proveedores");
            Console.WriteLine("1. Alta");
            Console.WriteLine("2. Baja");
            Console.WriteLine("3. Modificación");
            Console.WriteLine("4. Consulta");
            Console.WriteLine("5. Listar todos");
            Console.WriteLine("6. Volver");
            int opcion = MenuServicios.LeerOpcion();

            switch (opcion)
            {
                case 1:
                    AccionesProveedor.CrearProveedor();
                    break;
                case 2:
                    AccionesProveedor.EliminarProveedor();
                    break;
                case 3:
                    AccionesProveedor.ModificarProveedor();
                    break;
                case 4:
                    AccionesProveedor.ConsultarProveedor();
                    break;
                case 5:
                    AccionesProveedor.ListarProveedores();
                    break;
                case 6:
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
