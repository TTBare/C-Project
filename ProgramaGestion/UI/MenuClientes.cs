using System;

public static class MenuClientes
{
    public static void AdministrarClientes()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("Administrar Clientes");
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
                    AccionesCliente.CrearCliente();
                    break;
                case 2:
                    AccionesCliente.EliminarCliente();
                    break;
                case 3:
                    AccionesCliente.ModificarCliente();
                    break;
                case 4:
                    AccionesCliente.ConsultarCliente();
                    break;
                case 5:
                    AccionesCliente.ListarClientes();
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
