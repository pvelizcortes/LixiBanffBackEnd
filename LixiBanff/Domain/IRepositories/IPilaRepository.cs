using LixiBanff.Domain.Models;
using LixiBanff.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LixiBanff.Domain.IRepositories
{
    public interface IPilaRepository
    {
        Task Create(Pila _obj);
        Task Save(Pila _obj);
        Task<bool> ValidateExistence(Pila _obj, string opcion);
        Task<List<Pila>> GetList(int idCliente);
        Task<List<SelectDTO>> GetSelect(int idCliente);
        Task Delete(int identity_id, int idCliente);
    }
}
