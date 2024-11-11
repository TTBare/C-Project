using System;

public static class MenuEmpleados
{
    public static void AdministrarEmpleados()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("Administrar Empleados");
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
                    AccionesEmpleado.CrearEmpleado();
                    break;
                case 2:
                    AccionesEmpleado.EliminarEmpleado();
                    break;
                case 3:
                    AccionesEmpleado.ModificarEmpleado();
                    break;
                case 4:
                    AccionesEmpleado.ConsultarEmpleado();
                    break;
                case 5:
                    AccionesEmpleado.ListarEmpleados();
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
