using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using LixiBanff.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Services
{
    public class NodoService : INodoService
    {
        private readonly INodoRepository _repository;
        public NodoService(INodoRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Nodo _obj)
        {          
            await _repository.Create(_obj);
        }

        public async Task Save(Nodo _obj)
        {
            await _repository.Save(_obj);
        }

        public async Task<bool> ValidateExistence(Nodo _obj, string opcion)
        {
            return await _repository.ValidateExistence(_obj, opcion);
        }

        public async Task<List<Nodo>> GetList(int idCliente)
        {
            return await _repository.GetList(idCliente);
        }

        public async Task<List<SelectDTO>> GetSelect(int idCliente)
        {
            return await _repository.GetSelect(idCliente);
        }

        public async Task<List<SelectDTO>> GetTipoNodoSelect(int idCliente)
        {
            return await _repository.GetTipoNodoSelect(idCliente);
        }

        public async Task Delete(int identity_id, int idCliente)
        {
            await _repository.Delete(identity_id, idCliente);
        }
    }
}
