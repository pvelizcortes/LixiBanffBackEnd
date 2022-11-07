using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task CreateCliente(Cliente cliente)
        {
            await _clienteRepository.CreateCliente(cliente);
        }

        public async Task SaveCliente(Cliente cliente)
        {
            await _clienteRepository.SaveCliente(cliente);
        }

        public async Task<bool> ValidateExistence(Cliente cliente, string opcion)
        {
            return await _clienteRepository.ValidateExistence(cliente, opcion);
        }

        public async Task<List<Cliente>> GetListClients()
        {
            return await _clienteRepository.GetListClients();
        }

        public async Task DeleteCliente(int clienteId)
        {
            await _clienteRepository.DeleteCliente(clienteId);
        }
    }
}
