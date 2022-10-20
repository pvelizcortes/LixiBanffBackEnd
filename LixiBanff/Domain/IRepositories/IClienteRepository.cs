using LixiBanff.Domain.Models;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IRepositories
{
    public interface IClienteRepository
    {
        Task CreateCliente(Cliente cliente);
        Task SaveCliente(Cliente cliente);
        Task<bool> ValidateExistence(Cliente cliente);
    }
}
