using System.Collections.Generic;
using MyApp.Entities;

namespace MyApp.DataAccess
{
    public class ProductoRepository : IRepository<Producto>
    {
        private List<Producto> productos = new List<Producto>();

        public void Add(Producto entity)
        {
            productos.Add(entity);
        }

        public void Remove(int id)
        {
            productos.RemoveAll(p => p.Id == id);
        }

        public void Update(Producto entity)
        {
            var index = productos.FindIndex(p => p.Id == entity.Id);
            if (index != -1)
            {
                productos[index] = entity;
            }
        }

        public Producto GetById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return productos.Find(p => p.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public List<Producto> GetAll()
        {
            return new List<Producto>(productos);
        }
    }
}
