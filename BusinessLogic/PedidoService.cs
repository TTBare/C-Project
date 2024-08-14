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
        public static void GetProductosDelPedido(Pedido entity){
            foreach(Producto producto in entity.Productosdepedido){
                Console.WriteLine($"Producto: {producto.Nombre}");
                Console.WriteLine($"Id del producto: {producto.Id}");
                Console.WriteLine($"Precio: {producto.Precio}");
                Console.WriteLine($"Cantidad: {producto.CantidadComprada}");
            }
        }
        public void MostrarProductos(int id) 
        {
            GetProductosDelPedido(_pedidoRepository.GetById(id));
        }
        public void ActualizarProductos(Pedido entity){
                foreach(Producto producto in entity.Productosdepedido){
                Console.WriteLine($"Producto: {producto.Nombre}");
                
                Console.WriteLine($"Id del producto: {producto.Id}");

                Console.WriteLine($"Precio: {producto.Precio}");
                
                Console.WriteLine($"Cantidad: {producto.CantidadComprada}");

            }
        }
        public void CargarPDeLista(Pedido p,List<Producto> c){
            p.Productosdepedido = c;
            
        }
    }
}
