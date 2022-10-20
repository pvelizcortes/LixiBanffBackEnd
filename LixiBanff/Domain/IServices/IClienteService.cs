using LixiBanff.Domain.Models;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IServices
{
    public interface IClienteService
    {
        Task CreateCliente(Cliente cliente);
        Task SaveCliente(Cliente cliente);
        Task<bool> ValidateExistence(Cliente cliente);
    }
}
