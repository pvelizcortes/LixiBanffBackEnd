using LixiBanff.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IServices
{
    public interface IClienteService
    {
        Task Create(Cliente _obj);
        Task Save(Cliente _obj);
        Task<bool> ValidateExistence(Cliente _obj, string opcion);
        Task<List<Cliente>> GetList();
        Task Delete(int identity_id);
    }
}
