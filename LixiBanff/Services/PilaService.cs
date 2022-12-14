using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using LixiBanff.DTO;
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

        public async Task<List<Pila>> GetList(int idCliente)
        {
            return await _repository.GetList(idCliente);
        }

        public async Task<List<SelectDTO>> GetSelect(int idCliente)
        {
            return await _repository.GetSelect(idCliente);
        }

        public async Task Delete(int identity_id, int idCliente)
        {
            await _repository.Delete(identity_id, idCliente);
        }
    }
}
