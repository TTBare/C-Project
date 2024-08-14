using System.Collections.Generic;
using MyApp.Entities;
using MyApp.DataAccess;
using System.Reflection.Metadata.Ecma335;

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

        public Producto ObtenerProductoPorId(int? id)
        {if(id== null){
            Console.WriteLine("Ingrese un ID valido");
            return null;
        }else{

            return _productoRepository.GetById(id.Value);
        }
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            return _productoRepository.GetAll();
        }
        public bool ProductoYaExistente(int IDVENTA)
        {
        List<Producto> a=ObtenerTodosLosProductos();
            Boolean b;
           return  b = a.Any(p => p.Id == IDVENTA);
           }
        public void DescontarStock(int cantidad, Producto p){
            p.Stock -= cantidad;
        }
        public List<Producto> CargarProductos(Pedido pedido){
            string respuesta;
            List<Producto> penlista = new List<Producto>();
            do {
                
                Console.Write("ID del Producto: ");
                int? productoenventa = int.Parse(Console.ReadLine());
                if(true){};
                if (!ProductoYaExistente(productoenventa.Value)){
                    Console.WriteLine("Ingrese un ID de un Prodducto existente");
                }else{
                    if(pedido.Productosdepedido.Any(p => p.Id == productoenventa)){
                        Console.Write("Cantidad: ");
                        Producto? productovendido = pedido.Productosdepedido.Find(p=> p.Id == productoenventa);
                        int Cantidad = int.Parse(Console.ReadLine());
                        if(productovendido.CantidadComprada==null){
                            productovendido.CantidadComprada=0;
                            }
                        productovendido.CantidadComprada += Cantidad;
                        Producto pedidoenstock = ObtenerProductoPorId(productoenventa);
                        DescontarStock(Cantidad,pedidoenstock);
                        penlista.Add(productovendido);
                        }   
                    }
                Console.WriteLine("¿Desea agregar algun producto? Si su respuesta en si toque enter sino lo es aprete 0 y enter");
                respuesta = (Console.ReadLine());
        }while(respuesta !="0");
        return penlista;
        }
        
    }
}
