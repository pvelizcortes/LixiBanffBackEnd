using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.Models;
using LixiBanff.DTO.Login;
using LixiBanff.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LixiBanff.Persistence.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly AplicationDbContext _context;
        public LoginRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ValidateUser(UsuarioLoginDTO usuario)
        {
            var user = await _context.Usuario.Where(x => x.NombreUsuario == usuario.nombreUsuario
                                                && x.Password == usuario.password).FirstOrDefaultAsync();
            return user;
        }
    }
}
