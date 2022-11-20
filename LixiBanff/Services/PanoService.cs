using LixiBanff.Domain.IRepositories;
using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Services
{
    public class PanoService : IPanoService
    {
        private readonly IPanoRepository _repository;
        public PanoService(IPanoRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Pano _obj)
        {          
            await _repository.Create(_obj);
        }

        public async Task Save(Pano _obj)
        {
            await _repository.Save(_obj);
        }

        public async Task<bool> ValidateExistence(Pano _obj, string opcion)
        {
            return await _repository.ValidateExistence(_obj, opcion);
        }

        public async Task<List<Pano>> GetList(int idCliente)
        {
            return await _repository.GetList(idCliente);
        }

        public async Task Delete(int identity_id, int idCliente)
        {
            await _repository.Delete(identity_id, idCliente);
        }
    }
}
