using System.Collections.Generic;

public static class EmpleadoDataAccess
{
    private static List<Empleado> empleados = new List<Empleado>();

    public static List<Empleado> ObtenerEmpleados()
    {
        return empleados;
    }

    public static void AgregarEmpleado(Empleado empleado)
    {
        empleado.Id = empleados.Count + 1; // Asignar un ID automático.
        empleados.Add(empleado);
    }

    public static void EliminarEmpleado(int id)
    {
        Empleado empleado = empleados.Find(e => e.Id == id);
        if (empleado != null)
        {
            empleados.Remove(empleado);
        }
    }

    public static void ModificarEmpleado(Empleado empleadoModificado)
    {
        Empleado empleado = empleados.Find(e => e.Id == empleadoModificado.Id);
        if (empleado != null)
        {
            empleado.Nombre = empleadoModificado.Nombre;
            empleado.Apellido = empleadoModificado.Apellido;
            empleado.Cargo = empleadoModificado.Cargo;
            empleado.Salario = empleadoModificado.Salario;
            empleado.FechaContratacion = empleadoModificado.FechaContratacion;
            empleado.Telefono = empleadoModificado.Telefono;
            empleado.Direccion = empleadoModificado.Direccion;
        }
    }

    public static Empleado ObtenerEmpleadoPorId(int id)
    {
        return empleados.Find(e => e.Id == id);
    }
}
