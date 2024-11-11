using System;

public static class MenuServicios
{
    public static int LeerOpcion()
    {
        Console.Write("Seleccione una opción: ");
        if (int.TryParse(Console.ReadLine(), out int opcion))
        {
            return opcion;
        }
        else
        {
            Console.WriteLine("Opción inválida. Intente nuevamente.");
            return -1; // Valor que fuerza la repetición del menú
        }
    }

    public static void Pausar()
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
