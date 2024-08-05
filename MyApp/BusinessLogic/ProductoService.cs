using System.Collections.Generic;
using MyApp.Entities;
using MyApp.DataAccess;

namespace MyApp.BusinessLogic
{
    public class ProductoService
    {
        private readonly IRepository<Producto> _productoRepository;

        public ProductoService(IRepository<Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public void CrearProducto(Producto producto)
        {
            _productoRepository.Add(producto);
        }

        public void EliminarProducto(int id)
        {
            _productoRepository.Remove(id);
        }

        public void ActualizarProducto(Producto producto)
        {
            _productoRepository.Update(producto);
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return _productoRepository.GetById(id);
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            return _productoRepository.GetAll();
        }
    }
}
