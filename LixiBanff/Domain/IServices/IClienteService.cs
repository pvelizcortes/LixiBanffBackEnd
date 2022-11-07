using LixiBanff.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IServices
{
    public interface IClienteService
    {
        Task CreateCliente(Cliente cliente);
        Task SaveCliente(Cliente cliente);
        Task<bool> ValidateExistence(Cliente cliente, string opcion);
        Task<List<Cliente>> GetListClients();
        Task DeleteCliente(int clienteId);
    }
}
