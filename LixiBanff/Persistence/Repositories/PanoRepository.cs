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
    public class PanoRepository : IPanoRepository
    {
        private readonly AplicationDbContext _context;
        public PanoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Pano _obj)
        {
            _obj.CreateDate = System.DateTime.Now;
            _context.Add(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task Save(Pano _obj)
        {
            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Pano _obj, string opcion)
        {
            var validateExistence = false;
            if (opcion == "id")
            {
                validateExistence = await _context.Pano.AnyAsync(x => x.PanoId == _obj.PanoId
                && x.ClienteId == _obj.ClienteId);
            }
            if (opcion == "codigo")
            {
                validateExistence = await _context.Pano.AnyAsync(x => x.CodigoPano == _obj.CodigoPano
                && x.ClienteId == _obj.ClienteId);
            }
            return validateExistence;
        }

        public async Task<List<Pano>> GetList(int idCliente)
        {
            var listData = await _context.Pano
                .Where(x => x.ClienteId == idCliente)
                .ToListAsync();
            return listData;
        }

        public async Task<List<SelectDTO>> GetSelect(int idCliente)
        {
            var listData = await _context.Pano
                .Where(x => x.PanoId == idCliente && x.Active == true)
                .Select(x => new SelectDTO
                {
                    id = x.PanoId,
                    text = x.NombrePano
                })
                .ToListAsync();
            return listData;
        }

        public async Task Delete(int identity_id, int idCliente)
        {
            var _obj = await _context.Pano
                .Where(x => x.PanoId == identity_id && x.ClienteId == idCliente)
                .FirstOrDefaultAsync();

            _obj.Active = false;
            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
