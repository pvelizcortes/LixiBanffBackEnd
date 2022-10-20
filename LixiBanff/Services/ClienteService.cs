using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
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
            await _clienteRepository.CreateCliente(cliente);
        }

        public async Task<bool> ValidateExistence(Cliente cliente)
        {
            return await _clienteRepository.ValidateExistence(cliente);
        }
    }
}
