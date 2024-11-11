using System;

public static class MenuProductos
{
    public static void AdministrarProductos()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("Administrar Productos");
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
                    AccionesProducto.CrearProducto();
                    break;
                case 2:
                    AccionesProducto.EliminarProducto();
                    break;
                case 3:
                    AccionesProducto.ModificarProducto();
                    break;
                case 4:
                    AccionesProducto.ConsultarProducto();
                    break;
                case 5:
                    AccionesProducto.ListarProductos();
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
