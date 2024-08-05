using System.Collections.Generic;
using MyApp.Entities;
using MyApp.DataAccess;

namespace MyApp.BusinessLogic
{
    public class ClienteService
    {
        private readonly IRepository<Cliente> _clienteRepository;

        public ClienteService(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void CrearCliente(Cliente cliente)
        {
            _clienteRepository.Add(cliente);
        }

        public void EliminarCliente(int id)
        {
            _clienteRepository.Remove(id);
        }

        public void ActualizarCliente(Cliente cliente)
        {
            _clienteRepository.Update(cliente);
        }

        public Cliente ObtenerClientePorId(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return _clienteRepository.GetAll();
        }
    }
}
