using System.Collections.Generic;
using MyApp.Entities;
using MyApp.DataAccess;

namespace MyApp.BusinessLogic
{
    public class ProveedorService
    {
        private readonly IRepository<Proveedor> _proveedorRepository;

        public ProveedorService(IRepository<Proveedor> proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public void CrearProveedor(Proveedor proveedor)
        {
            _proveedorRepository.Add(proveedor);
        }

        public void EliminarProveedor(int id)
        {
            _proveedorRepository.Remove(id);
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            _proveedorRepository.Update(proveedor);
        }

        public Proveedor ObtenerProveedorPorId(int id)
        {
            return _proveedorRepository.GetById(id);
        }

        public List<Proveedor> ObtenerTodosLosProveedores()
        {
            return _proveedorRepository.GetAll();
        }

    }
}
