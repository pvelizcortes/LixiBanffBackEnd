using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.Models;
using LixiBanff.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Cliente cliente)
        {
            var validateExistence = await _context.Cliente.AnyAsync(x => x.NombreCliente == cliente.NombreCliente);
            return validateExistence;
        }
    }
}
