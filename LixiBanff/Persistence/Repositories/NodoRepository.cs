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
    public class NodoRepository : INodoRepository
    {
        private readonly AplicationDbContext _context;
        public NodoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Nodo _obj)
        {
            _obj.CreateDate = System.DateTime.Now;
            _context.Add(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task Save(Nodo _obj)
        {
            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Nodo _obj, string opcion)
        {
            var validateExistence = false;
            if (opcion == "id")
            {
                validateExistence = await _context.Nodo.AnyAsync(x => x.NodoId == _obj.NodoId
                && x.ClienteId == _obj.ClienteId);
            }
            if (opcion == "codigo")
            {
                validateExistence = await _context.Nodo.AnyAsync(x => x.CodigoNodo == _obj.CodigoNodo
                && x.ClienteId == _obj.ClienteId);
            }
            return validateExistence;
        }

        public async Task<List<Nodo>> GetList(int idCliente)
        {
            var listData = await _context.Nodo
                .Where(x => x.ClienteId == idCliente)
                .ToListAsync();
            return listData;
        }

        public async Task<List<SelectDTO>> GetSelect(int idCliente)
        {
            var listData = await _context.Nodo
                .Where(x => x.NodoId == idCliente && x.Active == true)
                .Select(x => new SelectDTO
                {
                    id = x.NodoId,
                    text = x.NombreNodo
                })
                .ToListAsync();
            return listData;
        }

        public async Task Delete(int identity_id, int idCliente)
        {
            var _obj = await _context.Nodo
                .Where(x => x.NodoId == identity_id && x.ClienteId == idCliente)
                .FirstOrDefaultAsync();

            _obj.Active = false;
            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Others
        public async Task<List<SelectDTO>> GetTipoNodoSelect(int idCliente)
        {
            var listData = await _context.TipoNodo
                .Where(x => x.Active == true)
                .Select(x => new SelectDTO
                {
                    id = x.TipoNodoId,
                    text = x.NombreTipoNodo
                })
                .ToListAsync();
            return listData;
        }
    }
}
