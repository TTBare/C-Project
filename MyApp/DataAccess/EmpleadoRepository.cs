using System.Collections.Generic;
using MyApp.Entities;

namespace MyApp.DataAccess
{
    public class EmpleadoRepository : IRepository<Empleado>
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void Add(Empleado entity)
        {
            empleados.Add(entity);
        }

        public void Remove(int id)
        {
            empleados.RemoveAll(e => e.Id == id);
        }

        public void Update(Empleado entity)
        {
            var index = empleados.FindIndex(e => e.Id == entity.Id);
            if (index != -1)
            {
                empleados[index] = entity;
            }
        }

        public Empleado GetById(int id)
        {

            return empleados.Find(e => e.Id == id);

        }

        public List<Empleado> GetAll()
        {
            return new List<Empleado>(empleados);
        }
    }
}
