using LixiBanff.Domain.Models;
using LixiBanff.DTO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IRepositories
{
    public interface ILoginRepository
    {        Task<Usuario> ValidateUser(UsuarioLoginDTO usuario);
    }
}
