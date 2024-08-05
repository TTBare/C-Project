using System.Collections.Generic;
using MyApp.Entities;
using MyApp.DataAccess;

namespace MyApp.BusinessLogic
{
    public class PedidoService
    {
        private readonly IRepository<Pedido> _pedidoRepository;

        public PedidoService(IRepository<Pedido> pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void CrearPedido(Pedido pedido)
        {
            _pedidoRepository.Add(pedido);
        }

        public void EliminarPedido(int id)
        {
            _pedidoRepository.Remove(id);
        }

        public void ActualizarPedido(Pedido pedido)
        {
            _pedidoRepository.Update(pedido);
        }

        public Pedido ObtenerPedidoPorId(int id)
        {
            return _pedidoRepository.GetById(id);
        }

        public List<Pedido> ObtenerTodosLosPedidos()
        {
            return _pedidoRepository.GetAll();
        }
    }
}
