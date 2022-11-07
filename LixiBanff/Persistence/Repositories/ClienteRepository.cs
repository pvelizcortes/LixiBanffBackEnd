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

        public async Task CreateCliente(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task SaveCliente(Cliente cliente)
        {            
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Cliente cliente, string opcion)
        {
            var validateExistence = false;
            if (opcion == "id")
            {
                validateExistence = await _context.Cliente.AnyAsync(x => x.ClienteId == cliente.ClienteId);
            }
            if (opcion == "nombre")
            {
                validateExistence = await _context.Cliente.AnyAsync(x => x.NombreCliente == cliente.NombreCliente);
            }            
            return validateExistence;
        }

        public async Task<List<Cliente>> GetListClients()
        {
            var listData = await _context.Cliente
                .Where(x => x.Active == true)
                .ToListAsync();
            return listData;
        }

        public async Task DeleteCliente(int clienteId)
        {
            var cliente = await _context.Cliente.Where(x => x.ClienteId == clienteId).FirstOrDefaultAsync();
            cliente.Active = false;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
