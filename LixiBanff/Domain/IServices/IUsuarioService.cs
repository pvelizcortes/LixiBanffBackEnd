using LixiBanff.Domain.Models;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
    }
}
