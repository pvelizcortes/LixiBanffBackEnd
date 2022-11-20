using LixiBanff.Domain.Models;
using LixiBanff.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IRepositories
{
    public interface IPanoRepository
    {
        Task Create(Pano _obj);
        Task Save(Pano _obj);
        Task<bool> ValidateExistence(Pano _obj, string opcion);
        Task<List<Pano>> GetList(int idCliente);
        Task<List<SelectDTO>> GetSelect(int idCliente, int pilaId);
        Task Delete(int identity_id, int idCliente);
    }
}
