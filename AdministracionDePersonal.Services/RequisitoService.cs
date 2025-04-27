using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Repository
{
    public class RequisitoService : IRequisitoService
    {
        private readonly RequisitoRepository _requisitoRepository;

        public RequisitoService(RequisitoRepository requisitoRepository)
        {
            _requisitoRepository = requisitoRepository;
        }

        public Task<IEnumerable<Requisito>> GetAllAsync()
        {
            return _requisitoRepository.GetAllAsync();
        }

        public Task<Requisito?> GetByIdAsync(int id)
        {
            return _requisitoRepository.GetByIdAsync(id);
        }

        public Task<int> InsertAsync(Requisito requisito)
        {
            return _requisitoRepository.InsertAsync(requisito);
        }

        public Task<int> UpdateAsync(Requisito requisito)
        {
            return _requisitoRepository.UpdateAsync(requisito);
        }

        public Task<int> DeleteAsync(int id)
        {
            return _requisitoRepository.DeleteAsync(id);
        }
    }
}
