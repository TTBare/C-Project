using System;

public static class MenuPrincipal
{
    public static void MostrarMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("=== Sistema de Gestión ===");
        Console.WriteLine("1. Administrar Clientes");
        Console.WriteLine("2. Administrar Productos");
        Console.WriteLine("3. Administrar Empleados");
        Console.WriteLine("4. Administrar Proveedores");
        Console.WriteLine("5. Administrar Pedidos");
        Console.WriteLine("6. Administrar Facturas");
        Console.WriteLine("0. Salir");
    }

    public static bool EjecutarOpcionPrincipal(int opcion)
    {
        switch (opcion)
        {
            case 1:
                MenuClientes.AdministrarClientes();
                break;
            case 2:
                MenuProductos.AdministrarProductos();
                break;
            case 3:
                MenuEmpleados.AdministrarEmpleados();
                break;
            case 4:
                MenuProveedores.AdministrarProveedores();
                break;
            case 5:
                MenuPedidos.AdministrarPedidos();
                break;
            case 6:
                MenuFacturas.AdministrarFacturas();
                break;
            case 0:
                return false;
            default:
                Console.WriteLine("Opción no válida. Intente nuevamente.");
                MenuServicios.Pausar();
                break;
        }
        return true;
    }
}
