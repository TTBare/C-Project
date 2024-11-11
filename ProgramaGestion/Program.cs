using System;

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            MenuPrincipal.MostrarMenuPrincipal();

            int opcion = MenuServicios.LeerOpcion();

            continuar = MenuPrincipal.EjecutarOpcionPrincipal(opcion);
        }

        Console.WriteLine("Gracias por usar el sistema. ¡Adiós!");
    }
}
