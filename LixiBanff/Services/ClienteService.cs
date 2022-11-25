using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using LixiBanff.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Cliente _obj)
        {          
            await _repository.Create(_obj);
        }

        public async Task Save(Cliente _obj)
        {
            await _repository.Save(_obj);
        }

        public async Task<bool> ValidateExistence(Cliente _obj, string opcion)
        {
            return await _repository.ValidateExistence(_obj, opcion);
        }

        public async Task<List<Cliente>> GetList()
        {
            return await _repository.GetList();
        }

        public async Task<List<SelectDTO>> GetSelect()
        {
            return await _repository.GetSelect();
        }

        public async Task Delete(int identity_id)
        {
            await _repository.Delete(identity_id);
        }
    }
}
