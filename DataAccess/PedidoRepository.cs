using System.Collections.Generic;
using System.Text.RegularExpressions;
using MyApp.Entities;

namespace MyApp.DataAccess
{
    public class PedidoRepository : IRepository<Pedido>
    {
        private List<Pedido> pedidos = new List<Pedido>();

        public void Add(Pedido entity)
        {
            {if(pedidos.LastOrDefault()!=null){
            int ultimo_id = pedidos.Last().Id+1;
            entity.Id = ultimo_id+1;}

            pedidos.Add(entity);
        }
        }

        public void Remove(int id)
        {
            pedidos.RemoveAll(p => p.Id == id);
        }

        public void Update(Pedido entity)
        {
            var index = pedidos.FindIndex(p => p.Id == entity.Id);
            if (index != -1)
            {
                pedidos[index] = entity;
            }
        }

        public Pedido GetById(int id)
        {

            return pedidos.Find(p => p.Id == id);

        }

        public List<Pedido> GetAll()
        {
            return new List<Pedido>(pedidos);
        }

        
    }
}
