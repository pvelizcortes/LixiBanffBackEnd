using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.Models;
using LixiBanff.DTO;
using LixiBanff.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LixiBanff.Persistence.Repositories
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly AplicationDbContext _context;
        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Usuario _obj)
        {
            _obj.CreateDate = System.DateTime.Now;
            _context.Add(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task Save(Usuario _obj)
        {
            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Usuario _obj, string opcion)
        {
            var validateExistence = false;
            if (opcion == "id")
            {
                validateExistence = await _context.Usuario.AnyAsync(x => x.UsuarioId == _obj.UsuarioId
                && x.ClienteId == _obj.ClienteId);
            }
            if (opcion == "nombre")
            {
                validateExistence = await _context.Usuario.AnyAsync(x => x.NombreUsuario == _obj.NombreUsuario
                && x.ClienteId == _obj.ClienteId);
            }
            return validateExistence;
        }

        public async Task<List<Usuario>> GetList(int idCliente)
        {
            var listData = await _context.Usuario           
                .Include(x => x.Cliente)
                //.Where(x => x.ClienteId == idCliente)                
                .ToListAsync();
            return listData;
        }

        public async Task<List<SelectDTO>> GetSelect(int idCliente)
        {
            var listData = await _context.Usuario
                .Where(x =>
                    x.ClienteId == idCliente
                    && x.Active == true)
                .Select(x => new SelectDTO
                {
                    id = x.UsuarioId,
                    text = x.NombreUsuario
                })
                .ToListAsync();
            return listData;
        }

        public async Task Delete(int identity_id, int idCliente)
        {
            var _obj = await _context.Usuario
                .Where(x => x.UsuarioId == identity_id)
                .FirstOrDefaultAsync();

            _obj.Active = false;
            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Others
        public async Task<List<SelectDTO>> GetPerfilSelect(int idCliente)
        {
            var listData = await _context.Perfil
                .Where(x => x.Active == true)
                .Select(x => new SelectDTO
                {
                    id = x.PerfilId,
                    text = x.NombrePerfil
                })
                .ToListAsync();
            return listData;
        }
    }
}
