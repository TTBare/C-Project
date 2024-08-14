using System.Collections.Generic;
using MyApp.Entities;

namespace MyApp.DataAccess
{
    public class ProveedorRepository : IRepository<Proveedor>
    {
        private List<Proveedor> proveedores = new List<Proveedor>();

        public void Add(Proveedor entity)
        {if(proveedores.LastOrDefault()!=null){
            int ultimo_id = proveedores.Last().Id+1;
            entity.Id = ultimo_id+1;}
            proveedores.Add(entity);
        }

        public void Remove(int id)
        {
            proveedores.RemoveAll(p => p.Id == id);
        }

        public void Update(Proveedor entity)
        {
            var index = proveedores.FindIndex(p => p.Id == entity.Id);
            if (index != -1)
            {
                proveedores[index] = entity;
            }
        }

        public Proveedor GetById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return proveedores.Find(p => p.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public List<Proveedor> GetAll()
        {
            return new List<Proveedor>(proveedores);
        }
    }
}
