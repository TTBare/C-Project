using System;

public static class AccionesEmpleado
{
    public static void CrearEmpleado()
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
        if (decimal.TryParse(Console.ReadLine(), out decimal salario))
        {
            empleado.Salario = salario;
            Console.Write("Fecha de Contratación (dd/MM/yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaContratacion))
            {
                empleado.FechaContratacion = fechaContratacion;
                Console.Write("Teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Dirección: ");
                empleado.Direccion = Console.ReadLine();
                EmpleadoDataAccess.AgregarEmpleado(empleado);
                Console.WriteLine("Empleado creado con éxito.");
            }
            else
            {
                Console.WriteLine("Fecha de contratación inválida. Intente nuevamente.");
            }
        }
        else
        {
            Console.WriteLine("Salario inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void EliminarEmpleado()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Empleado");
        Console.Write("ID del Empleado: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            EmpleadoDataAccess.EliminarEmpleado(id);
            Console.WriteLine("Empleado eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ModificarEmpleado()
    {
        Console.Clear();
        Console.WriteLine("Modificar Empleado");
        Console.Write("ID del Empleado: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Empleado empleado = EmpleadoDataAccess.ObtenerEmpleadoPorId(id);
            if (empleado != null)
            {
                Console.Write($"Nombre ({empleado.Nombre}): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nombre)) empleado.Nombre = nombre;

                Console.Write($"Apellido ({empleado.Apellido}): ");
                string apellido = Console.ReadLine();
                if (!string.IsNullOrEmpty(apellido)) empleado.Apellido = apellido;

                Console.Write($"Cargo ({empleado.Cargo}): ");
                string cargo = Console.ReadLine();
                if (!string.IsNullOrEmpty(cargo)) empleado.Cargo = cargo;

                Console.Write($"Salario ({empleado.Salario}): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal salario)) empleado.Salario = salario;

                Console.Write($"Fecha de Contratación ({empleado.FechaContratacion:dd/MM/yyyy}): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaContratacion)) empleado.FechaContratacion = fechaContratacion;

                Console.Write($"Teléfono ({empleado.Telefono}): ");
                string telefono = Console.ReadLine();
                if (!string.IsNullOrEmpty(telefono)) empleado.Telefono = telefono;

                Console.Write($"Dirección ({empleado.Direccion}): ");
                string direccion = Console.ReadLine();
                if (!string.IsNullOrEmpty(direccion)) empleado.Direccion = direccion;

                EmpleadoDataAccess.ModificarEmpleado(empleado);
                Console.WriteLine("Empleado modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ConsultarEmpleado()
    {
        Console.Clear();
        Console.WriteLine("Consultar Empleado");
        Console.Write("ID del Empleado: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Empleado empleado = EmpleadoDataAccess.ObtenerEmpleadoPorId(id);
            if (empleado != null)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Apellido: {empleado.Apellido}");
                Console.WriteLine($"Cargo: {empleado.Cargo}");
                Console.WriteLine($"Salario: {empleado.Salario}");
                Console.WriteLine($"Fecha de Contratación: {empleado.FechaContratacion:dd/MM/yyyy}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Intente nuevamente.");
        }
        MenuServicios.Pausar();
    }

    public static void ListarEmpleados()
    {
        Console.Clear();
        Console.WriteLine("Listar Todos los Empleados");
        foreach (var empleado in EmpleadoDataAccess.ObtenerEmpleados())
        {
            Console.WriteLine($"ID: {empleado.Id} - Nombre: {empleado.Nombre} {empleado.Apellido} - Cargo: {empleado.Cargo} - Salario: {empleado.Salario} - Fecha de Contratación: {empleado.FechaContratacion:dd/MM/yyyy} - Teléfono: {empleado.Telefono} - Dirección: {empleado.Direccion}");
        }
        MenuServicios.Pausar();
    }
}
