using System;
using MyApp.Entities;
using MyApp.DataAccess;
using MyApp.BusinessLogic;

namespace MyApp.UI
{
    class Program
    {
        private static ClienteService _clienteService;
        private static ProductoService _productoService;
        private static PedidoService _pedidoService;
        private static ProveedorService _proveedorService;
        private static EmpleadoService _empleadoService;

    static void Main(string[] args)
        {
            InitializeServices();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Sistema de Gestión");
                Console.WriteLine("1. Administrar Clientes");
                Console.WriteLine("2. Administrar Productos");
                Console.WriteLine("3. Administrar Pedidos");
                Console.WriteLine("4. Administrar Proveedores");
                Console.WriteLine("5. Administrar Empleados");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AdministrarClientes();
                        break;
                    case "2":
                        AdministrarProductos();
                        break;
                    case "3":
                        AdministrarPedidos();
                        break;
                    case "4":
                        AdministrarProveedores();
                        break;
                    case "5":
                        AdministrarEmpleados();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }

    private static void InitializeServices()
        {
            _clienteService = new ClienteService(new ClienteRepository());
            _productoService = new ProductoService(new ProductoRepository());
            _pedidoService = new PedidoService(new PedidoRepository());
            _proveedorService = new ProveedorService(new ProveedorRepository());
            _empleadoService = new EmpleadoService(new EmpleadoRepository());
        }


    private static void AdministrarClientes()
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
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CrearCliente();
                        break;
                    case "2":
                        EliminarCliente();
                        break;
                    case "3":
                        ModificarCliente();
                        break;
                    case "4":
                        ConsultarCliente();
                        break;
                    case "5":
                        ListarClientes();
                        break;
                    case "6":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }

    private static void CrearCliente()
        {
            Console.Clear();
            Console.WriteLine("Crear Cliente");

            Cliente cliente = new Cliente();
            Console.Write("Nombre: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            cliente.Apellido = Console.ReadLine();
            Console.Write("Email: ");
            cliente.Email = Console.ReadLine();
            Console.Write("Teléfono: ");
            cliente.Telefono = Console.ReadLine();

            _clienteService.CrearCliente(cliente);
            Console.WriteLine("Cliente creado con éxito. Presione una tecla para continuar.");
            Console.ReadKey();
        }

    private static void EliminarCliente()
        {
            Console.Clear();
            Console.WriteLine("Eliminar Cliente");

            Console.Write("ID del Cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            _clienteService.EliminarCliente(id);
            Console.WriteLine("Cliente eliminado con éxito. Presione una tecla para continuar.");
            Console.ReadKey();
        }

    private static void ModificarCliente()
        {
            Console.Clear();
            Console.WriteLine("Modificar Cliente");

            Console.Write("ID del Cliente a modificar: ");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = _clienteService.ObtenerClientePorId(id);
            if (cliente != null)
            {
                Console.Write($"Nombre ({cliente.Nombre}): ");
                cliente.Nombre = Console.ReadLine();
                Console.Write($"Apellido ({cliente.Apellido}): ");
                cliente.Apellido = Console.ReadLine();
                Console.Write($"Email ({cliente.Email}): ");
                cliente.Email = Console.ReadLine();
                Console.Write($"Teléfono ({cliente.Telefono}): ");
                cliente.Telefono = Console.ReadLine();

                _clienteService.ActualizarCliente(cliente);
                Console.WriteLine("Cliente modificado con éxito. Presione una tecla para continuar.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado. Presione una tecla para continuar.");
            }
            Console.ReadKey();
        }

    private static void ConsultarCliente()
        {
            Console.Clear();
            Console.WriteLine("Consultar Cliente");

            Console.Write("ID del Cliente: ");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = _clienteService.ObtenerClientePorId(id);
            if (cliente != null)
            {
                Console.WriteLine($"Nombre: {cliente.Nombre}");
                Console.WriteLine($"Apellido: {cliente.Apellido}");
                Console.WriteLine($"Email: {cliente.Email}");
                Console.WriteLine($"Teléfono: {cliente.Telefono}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();
        }

    private static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("Listar Todos los Clientes");

            var clientes = _clienteService.ObtenerTodosLosClientes();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id} - Nombre: {cliente.Nombre} {cliente.Apellido} - Email: {cliente.Email} - Teléfono: {cliente.Telefono}");
            }
            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadKey();
        }


    private static void AdministrarProductos()
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
        Console.Write("Seleccione una opción: ");

        switch (Console.ReadLine())
        {
            case "1":
                CrearProducto();
                break;
            case "2":
                EliminarProducto();
                break;
            case "3":
                ModificarProducto();
                break;
            case "4":
                ConsultarProducto();
                break;
            case "5":
                ListarProductos();
                break;
            case "6":
                back = true;
                break;
            default:
                Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                Console.ReadKey();
                break;
        }
    }
}

    private static void CrearProducto()
{
    Console.Clear();
    Console.WriteLine("Crear Producto");

    Producto producto = new Producto();
    Console.Write("Nombre: ");
    producto.Nombre = Console.ReadLine();
    Console.Write("Precio: ");
    producto.Precio = decimal.Parse(Console.ReadLine());
    Console.Write("Stock: ");
    producto.Stock = int.Parse(Console.ReadLine());
    Console.Write("ID del Proveedor: ");
    producto.ProveedorId = int.Parse(Console.ReadLine());

    _productoService.CrearProducto(producto);
    Console.WriteLine("Producto creado con éxito. Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void EliminarProducto()
{
    Console.Clear();
    Console.WriteLine("Eliminar Producto");

    Console.Write("ID del Producto a eliminar: ");
    int id = int.Parse(Console.ReadLine());

    _productoService.EliminarProducto(id);
    Console.WriteLine("Producto eliminado con éxito. Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void ModificarProducto()
{
    Console.Clear();
    Console.WriteLine("Modificar Producto");

    Console.Write("ID del Producto a modificar: ");
    int id = int.Parse(Console.ReadLine());

    Producto producto = _productoService.ObtenerProductoPorId(id);
    if (producto != null)
    {
        Console.Write($"Nombre ({producto.Nombre}): ");
        producto.Nombre = Console.ReadLine();
        Console.Write($"Precio ({producto.Precio}): ");
        producto.Precio = decimal.Parse(Console.ReadLine());
        Console.Write($"Stock ({producto.Stock}): ");
        producto.Stock = int.Parse(Console.ReadLine());
        Console.Write($"ID del Proveedor ({producto.ProveedorId}): ");
        producto.ProveedorId = int.Parse(Console.ReadLine());

        _productoService.ActualizarProducto(producto);
        Console.WriteLine("Producto modificado con éxito. Presione una tecla para continuar.");
    }
    else
    {
        Console.WriteLine("Producto no encontrado. Presione una tecla para continuar.");
    }
    Console.ReadKey();
}

    private static void ConsultarProducto()
{
    Console.Clear();
    Console.WriteLine("Consultar Producto");

    Console.Write("ID del Producto: ");
    int id = int.Parse(Console.ReadLine());

    Producto producto = _productoService.ObtenerProductoPorId(id);
    if (producto != null)
    {
        Console.WriteLine($"Nombre: {producto.Nombre}");
        Console.WriteLine($"Precio: {producto.Precio}");
        Console.WriteLine($"Stock: {producto.Stock}");
        Console.WriteLine($"ID del Proveedor: {producto.ProveedorId}");
    }
    else
    {
        Console.WriteLine("Producto no encontrado.");
    }
    Console.WriteLine("Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void ListarProductos()
{
    Console.Clear();
    Console.WriteLine("Listar Todos los Productos");

    var productos = _productoService.ObtenerTodosLosProductos();
    foreach (var producto in productos)
    {
        Console.WriteLine($"ID: {producto.Id} - Nombre: {producto.Nombre} - Precio: {producto.Precio} - Stock: {producto.Stock} - ID del Proveedor: {producto.ProveedorId}");
    }
    Console.WriteLine("Presione una tecla para continuar.");
    Console.ReadKey();
}


    private static void AdministrarPedidos()
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("Administrar Pedidos");
        Console.WriteLine("1. Alta");
        Console.WriteLine("2. Baja");
        Console.WriteLine("3. Modificación");
        Console.WriteLine("4. Consulta");
        Console.WriteLine("5. Listar todos");
        Console.WriteLine("6. Volver");
        Console.Write("Seleccione una opción: ");

        switch (Console.ReadLine())
        {
            case "1":
                CrearPedido();
                break;
            case "2":
                EliminarPedido();
                break;
            case "3":
                ModificarPedido();
                break;
            case "4":
                ConsultarPedido();
                break;
            case "5":
                ListarPedidos();
                break;
            case "6":
                back = true;
                break;
            default:
                Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                Console.ReadKey();
                break;
        }
    }
}

    private static void CrearPedido()
{
    Console.Clear();
    Console.WriteLine("Crear Pedido");

    Pedido pedido = new Pedido();
    Console.Write("ID del Cliente: ");
    pedido.ClienteId = int.Parse(Console.ReadLine());
    Console.Write("ID del Producto: ");
    pedido.ProductoId = int.Parse(Console.ReadLine());
    Console.Write("Cantidad: ");
    pedido.Cantidad = int.Parse(Console.ReadLine());
    pedido.Fecha = DateTime.Now;

    _pedidoService.CrearPedido(pedido);
    Console.WriteLine("Pedido creado con éxito. Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void EliminarPedido()
{
    Console.Clear();
    Console.WriteLine("Eliminar Pedido");

    Console.Write("ID del Pedido a eliminar: ");
    int id = int.Parse(Console.ReadLine());

    _pedidoService.EliminarPedido(id);
    Console.WriteLine("Pedido eliminado con éxito. Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void ModificarPedido()
{
    Console.Clear();
    Console.WriteLine("Modificar Pedido");

    Console.Write("ID del Pedido a modificar: ");
    int id = int.Parse(Console.ReadLine());

    Pedido pedido = _pedidoService.ObtenerPedidoPorId(id);
    if (pedido != null)
    {
        Console.Write($"ID del Cliente ({pedido.ClienteId}): ");
        pedido.ClienteId = int.Parse(Console.ReadLine());
        Console.Write($"ID del Producto ({pedido.ProductoId}): ");
        pedido.ProductoId = int.Parse(Console.ReadLine());
        Console.Write($"Cantidad ({pedido.Cantidad}): ");
        pedido.Cantidad = int.Parse(Console.ReadLine());

        _pedidoService.ActualizarPedido(pedido);
        Console.WriteLine("Pedido modificado con éxito. Presione una tecla para continuar.");
    }
    else
    {
        Console.WriteLine("Pedido no encontrado. Presione una tecla para continuar.");
    }
    Console.ReadKey();
}

    private static void ConsultarPedido()
{
    Console.Clear();
    Console.WriteLine("Consultar Pedido");

    Console.Write("ID del Pedido: ");
    int id = int.Parse(Console.ReadLine());

    Pedido pedido = _pedidoService.ObtenerPedidoPorId(id);
    if (pedido != null)
    {
        Console.WriteLine($"ID del Cliente: {pedido.ClienteId}");
        Console.WriteLine($"ID del Producto: {pedido.ProductoId}");
        Console.WriteLine($"Cantidad: {pedido.Cantidad}");
        Console.WriteLine($"Fecha: {pedido.Fecha}");
    }
    else
    {
        Console.WriteLine("Pedido no encontrado.");
    }
    Console.WriteLine("Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void ListarPedidos()
{
    Console.Clear();
    Console.WriteLine("Listar Todos los Pedidos");

    var pedidos = _pedidoService.ObtenerTodosLosPedidos();
    foreach (var pedido in pedidos)
    {
        Console.WriteLine($"ID: {pedido.Id} - ID del Cliente: {pedido.ClienteId} - ID del Producto: {pedido.ProductoId} - Cantidad: {pedido.Cantidad} - Fecha: {pedido.Fecha}");
    }
    Console.WriteLine("Presione una tecla para continuar.");
    Console.ReadKey();
}


    private static void AdministrarProveedores()
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
        Console.Write("Seleccione una opción: ");

        switch (Console.ReadLine())
        {
            case "1":
                CrearProveedor();
                break;
            case "2":
                EliminarProveedor();
                break;
            case "3":
                ModificarProveedor();
                break;
            case "4":
                ConsultarProveedor();
                break;
            case "5":
                ListarProveedores();
                break;
            case "6":
                back = true;
                break;
            default:
                Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                Console.ReadKey();
                break;
        }
    }
}

    private static void CrearProveedor()
{
    Console.Clear();
    Console.WriteLine("Crear Proveedor");

    Proveedor proveedor = new Proveedor();
    Console.Write("Nombre: ");
    proveedor.Nombre = Console.ReadLine();
    Console.Write("Contacto: ");
    proveedor.Contacto = Console.ReadLine();
    Console.Write("Teléfono: ");
    proveedor.Telefono = Console.ReadLine();
    Console.Write("Email: ");
    proveedor.Email = Console.ReadLine();

    _proveedorService.CrearProveedor(proveedor);
    Console.WriteLine("Proveedor creado con éxito. Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void EliminarProveedor()
{
    Console.Clear();
    Console.WriteLine("Eliminar Proveedor");

    Console.Write("ID del Proveedor a eliminar: ");
    int id = int.Parse(Console.ReadLine());

    _proveedorService.EliminarProveedor(id);
    Console.WriteLine("Proveedor eliminado con éxito. Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void ModificarProveedor()
{
    Console.Clear();
    Console.WriteLine("Modificar Proveedor");

    Console.Write("ID del Proveedor a modificar: ");
    int id = int.Parse(Console.ReadLine());

    Proveedor proveedor = _proveedorService.ObtenerProveedorPorId(id);
    if (proveedor != null)
    {
        Console.Write($"Nombre ({proveedor.Nombre}): ");
        proveedor.Nombre = Console.ReadLine();
        Console.Write($"Contacto ({proveedor.Contacto}): ");
        proveedor.Contacto = Console.ReadLine();
        Console.Write($"Teléfono ({proveedor.Telefono}): ");
        proveedor.Telefono = Console.ReadLine();
        Console.Write($"Email ({proveedor.Email}): ");
        proveedor.Email = Console.ReadLine();

        _proveedorService.ActualizarProveedor(proveedor);
        Console.WriteLine("Proveedor modificado con éxito. Presione una tecla para continuar.");
    }
    else
    {
        Console.WriteLine("Proveedor no encontrado. Presione una tecla para continuar.");
    }
    Console.ReadKey();
}

    private static void ConsultarProveedor()
{
    Console.Clear();
    Console.WriteLine("Consultar Proveedor");

    Console.Write("ID del Proveedor: ");
    int id = int.Parse(Console.ReadLine());

    Proveedor proveedor = _proveedorService.ObtenerProveedorPorId(id);
    if (proveedor != null)
    {
        Console.WriteLine($"Nombre: {proveedor.Nombre}");
        Console.WriteLine($"Contacto: {proveedor.Contacto}");
        Console.WriteLine($"Teléfono: {proveedor.Telefono}");
        Console.WriteLine($"Email: {proveedor.Email}");
    }
    else
    {
        Console.WriteLine("Proveedor no encontrado.");
    }
    Console.WriteLine("Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void ListarProveedores()
{
    Console.Clear();
    Console.WriteLine("Listar Todos los Proveedores");

    var proveedores = _proveedorService.ObtenerTodosLosProveedores();
    foreach (var proveedor in proveedores)
    {
        Console.WriteLine($"ID: {proveedor.Id} - Nombre: {proveedor.Nombre} - Contacto: {proveedor.Contacto} - Teléfono: {proveedor.Telefono} - Email: {proveedor.Email}");
    }
    Console.WriteLine("Presione una tecla para continuar.");
    Console.ReadKey();
}


private static void AdministrarEmpleados()
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
        Console.Write("Seleccione una opción: ");

        switch (Console.ReadLine())
        {
            case "1":
                CrearEmpleado();
                break;
            case "2":
                EliminarEmpleado();
                break;
            case "3":
                ModificarEmpleado();
                break;
            case "4":
                ConsultarEmpleado();
                break;
            case "5":
                ListarEmpleados();
                break;
            case "6":
                back = true;
                break;
            default:
                Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                Console.ReadKey();
                break;
        }
    }
}

private static void CrearEmpleado()
{
    Console.Clear();
    Console.WriteLine("Crear Empleado");

    Empleado empleado = new Empleado();
    Console.Write("Nombre: ");
    empleado.Nombre = Console.ReadLine();
    Console.Write("Apellido: ");
    empleado.Apellido = Console.ReadLine();
    Console.Write("Cargo: ");
    empleado.Cargo = Console.ReadLine();
    Console.Write("Salario: ");
    empleado.Salario = decimal.Parse(Console.ReadLine());

    _empleadoService.CrearEmpleado(empleado);
    Console.WriteLine("Empleado creado con éxito. Presione una tecla para continuar.");
    Console.ReadKey();
}

private static void EliminarEmpleado()
{
    Console.Clear();
    Console.WriteLine("Eliminar Empleado");

    Console.Write("ID del Empleado a eliminar: ");
    int id = int.Parse(Console.ReadLine());

    _empleadoService.EliminarEmpleado(id);
    Console.WriteLine("Empleado eliminado con éxito. Presione una tecla para continuar.");
    Console.ReadKey();
}

    private static void ModificarEmpleado()
{
        Console.Clear();
        Console.WriteLine("Modificar Empleado");

        Console.Write("ID del Empleado a modificar: ");
        int id = int.Parse(Console.ReadLine());

        Empleado empleado = _empleadoService.ObtenerEmpleadoPorId(id);
        if (empleado != null)
        {
            Console.Write($"Nombre ({empleado.Nombre}): ");
            empleado.Nombre = Console.ReadLine();
            Console.Write($"Apellido ({empleado.Apellido}): ");
            empleado.Apellido = Console.ReadLine();
            Console.Write($"Cargo ({empleado.Cargo}): ");
            empleado.Cargo = Console.ReadLine();
            Console.Write($"Salario ({empleado.Salario}): ");
            empleado.Salario = decimal.Parse(Console.ReadLine());

            _empleadoService.ActualizarEmpleado(empleado);
            Console.WriteLine("Empleado modificado con éxito. Presione una tecla para continuar.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado. Presione una tecla para continuar.");
        }
        Console.ReadKey();
}   

    private static void ConsultarEmpleado()
{
        Console.Clear();
        Console.WriteLine("Consultar Empleado");

        Console.Write("ID del Empleado: ");
        int id = int.Parse(Console.ReadLine());

        Empleado empleado = _empleadoService.ObtenerEmpleadoPorId(id);
        if (empleado != null)
        {
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Apellido: {empleado.Apellido}");
            Console.WriteLine($"Cargo: {empleado.Cargo}");
            Console.WriteLine($"Salario: {empleado.Salario}");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
        Console.WriteLine("Presione una tecla para continuar.");
        Console.ReadKey();
}

    private static void ListarEmpleados()
{   
        Console.Clear();
        Console.WriteLine("Listar Todos los Empleados");

        var empleados = _empleadoService.ObtenerTodosLosEmpleados();
        foreach (var empleado in empleados)
            {
            Console.WriteLine($"ID: {empleado.Id} - Nombre: {empleado.Nombre} {empleado.Apellido} - Cargo: {empleado.Cargo} - Salario: {empleado.Salario}");
        }
        Console.WriteLine("Presione una tecla para continuar.");
        Console.ReadKey();
}

    }
}
