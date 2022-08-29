using LixiBanff.Domain.Models;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
    }
}
