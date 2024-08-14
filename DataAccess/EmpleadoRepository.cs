using System.Collections.Generic;
using System.Net;
using MyApp.Entities;

namespace MyApp.DataAccess
{
    public class EmpleadoRepository : IRepository<Empleado>
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void Add(Empleado entity)
        {if(empleados.LastOrDefault()!=null){
            int ultimo_id = empleados.Last().Id+1;
            entity.Id = ultimo_id+1;}
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
        {   if(empleados.Count!=0){
#pragma warning disable CS8603 // Possible null reference return.
                return empleados.Find(e => e.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
            }
            else{
                Console.WriteLine("No hay Empleado con ese ID");
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        public List<Empleado> GetAll()
        {
            return new List<Empleado>(empleados);
        }
    }
}
