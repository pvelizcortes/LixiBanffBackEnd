using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.Models;
using LixiBanff.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LixiBanff.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AplicationDbContext _context;
        public ClienteRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Cliente _obj)
        {
            _obj.CreateDate = System.DateTime.Now;
            _context.Add(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task Save(Cliente _obj)
        {
            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Cliente _obj, string opcion)
        {
            var validateExistence = false;
            if (opcion == "id")
            {
                validateExistence = await _context.Cliente.AnyAsync(x => x.ClienteId == _obj.ClienteId);
            }
            if (opcion == "nombre")
            {
                validateExistence = await _context.Cliente.AnyAsync(x => x.NombreCliente == _obj.NombreCliente);
            }
            return validateExistence;
        }

        public async Task<List<Cliente>> GetList()
        {
            var listData = await _context.Cliente
                //.Where(x => x.Active == true)
                .ToListAsync();
            return listData;
        }

        public async Task Delete(int identity_id)
        {
            var _obj = await _context.Cliente.Where(x => x.ClienteId == identity_id).FirstOrDefaultAsync();
            _obj.Active = false;

            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
