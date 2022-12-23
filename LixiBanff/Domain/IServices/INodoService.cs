using LixiBanff.Domain.Models;
using LixiBanff.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IServices
{
    public interface INodoService
    {
        Task Create(Nodo _obj);
        Task Save(Nodo _obj);
        Task<bool> ValidateExistence(Nodo _obj, string opcion);
        Task<List<Nodo>> GetList(int idCliente);
        Task<List<SelectDTO>> GetSelect(int idCliente, int panoId);
        Task<List<SelectDTO>> GetTipoNodoSelect(int idCliente);
        Task Delete(int identity_id, int idCliente);
        Task<Nodo> GetById(int nodoId);
    }
}
