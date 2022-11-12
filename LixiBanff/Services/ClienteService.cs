﻿using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Services
{
    public class PilaService : IPilaService
    {
        private readonly IPilaRepository _repository;
        public PilaService(IPilaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Pila _obj)
        {          
            await _repository.Create(_obj);
        }

        public async Task Save(Pila _obj)
        {
            await _repository.Save(_obj);
        }

        public async Task<bool> ValidateExistence(Pila _obj, string opcion)
        {
            return await _repository.ValidateExistence(_obj, opcion);
        }

        public async Task<List<Pila>> GetList()
        {
            return await _repository.GetList();
        }

        public async Task Delete(int identity_id)
        {
            await _repository.Delete(identity_id);
        }
    }
}
