using System.Collections.Generic;
using MyApp.Entities;

namespace MyApp.DataAccess
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void Add(Cliente entity)
        {
            clientes.Add(entity);
        }

        public void Remove(int id)
        {
            clientes.RemoveAll(c => c.Id == id);
        }

        public void Update(Cliente entity)
        {
            var index = clientes.FindIndex(c => c.Id == entity.Id);
            if (index != -1)
            {
                clientes[index] = entity;
            }
        }

        public Cliente GetById(int id)
        {

            return clientes.Find(c => c.Id == id);


        public List<Cliente> GetAll()
        {
            return new List<Cliente>(clientes);
        }
    }
}
