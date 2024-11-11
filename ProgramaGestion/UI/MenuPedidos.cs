using System;

public static class MenuPedidos
{
    public static void AdministrarPedidos()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("Administrar Pedidos");
            Console.WriteLine("1. Crear Pedido");
            Console.WriteLine("2. Eliminar Pedido");
            Console.WriteLine("3. Consultar Pedido");
            Console.WriteLine("4. Listar todos los Pedidos");
            Console.WriteLine("5. Volver");
            int opcion = MenuServicios.LeerOpcion();

            switch (opcion)
            {
                case 1:
                    AccionesPedido.CrearPedido();
                    break;
                case 2:
                    AccionesPedido.EliminarPedido();
                    break;
                case 3:
                    AccionesPedido.ConsultarPedido();
                    break;
                case 4:
                    AccionesPedido.ListarPedidos();
                    break;
                case 5:
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
