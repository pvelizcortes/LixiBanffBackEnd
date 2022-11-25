using LixiBanff.Domain.Models;
using LixiBanff.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task Create(Usuario _obj);
        Task Save(Usuario _obj);
        Task<bool> ValidateExistence(Usuario _obj, string opcion);
        Task<List<Usuario>> GetList(int idCliente);
        Task<List<SelectDTO>> GetSelect(int idCliente);
        Task Delete(int identity_id, int idCliente);
        Task<List<SelectDTO>> GetPerfilSelect(int idCliente);
    }
}
