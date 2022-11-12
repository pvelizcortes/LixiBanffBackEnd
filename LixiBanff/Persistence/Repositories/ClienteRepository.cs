﻿using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.Models;
using LixiBanff.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LixiBanff.Persistence.Repositories
{
    public class PilaRepository : IPilaRepository
    {
        private readonly AplicationDbContext _context;
        public PilaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Pila _obj)
        {
            _obj.CreateDate = System.DateTime.Now;
            _context.Add(_obj);
            await _context.SaveChangesAsync();
        }

        public async Task Save(Pila _obj)
        {
            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Pila _obj, string opcion)
        {
            var validateExistence = false;
            if (opcion == "id")
            {
                validateExistence = await _context.Pila.AnyAsync(x => x.PilaId == _obj.PilaId);
            }
            if (opcion == "nombre")
            {
                validateExistence = await _context.Pila.AnyAsync(x => x.NombrePila == _obj.NombrePila);
            }
            return validateExistence;
        }

        public async Task<List<Pila>> GetList()
        {
            var listData = await _context.Pila
                //.Where(x => x.Active == true)
                .ToListAsync();
            return listData;
        }

        public async Task Delete(int identity_id)
        {
            var _obj = await _context.Pila.Where(x => x.PilaId == identity_id).FirstOrDefaultAsync();
            _obj.Active = false;

            _context.Entry(_obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
