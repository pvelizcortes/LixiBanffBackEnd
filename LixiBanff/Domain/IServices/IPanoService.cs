using LixiBanff.Domain.Models;
using LixiBanff.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IServices
{
    public interface IPanoService
    {
        Task Create(Pano _obj);
        Task Save(Pano _obj);
        Task<bool> ValidateExistence(Pano _obj, string opcion);
        Task<List<Pano>> GetList(int idCliente);
        Task<List<SelectDTO>> GetSelect(int idCliente);
        Task Delete(int identity_id, int idCliente);
    }
}
