using System.Collections.Generic;
using MyApp.Entities;
using MyApp.DataAccess;

namespace MyApp.BusinessLogic
{
    public class EmpleadoService
    {
        private readonly IRepository<Empleado> _empleadoRepository;

        public EmpleadoService(IRepository<Empleado> empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public void CrearEmpleado(Empleado empleado)
        {
            _empleadoRepository.Add(empleado);
        }

        public void EliminarEmpleado(int id)
        {
            _empleadoRepository.Remove(id);
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            _empleadoRepository.Update(empleado);
        }

        public Empleado ObtenerEmpleadoPorId(int id)
        {
            return _empleadoRepository.GetById(id);
        }

        public List<Empleado> ObtenerTodosLosEmpleados()
        {
            return _empleadoRepository.GetAll();
        }
    }
}
