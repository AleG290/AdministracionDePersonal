using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Repository;
using AdministracionDePersonal.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Services
{
    public class AccionService : IAccionService
    {
        private readonly AccionRepository _accionRepository;

        public AccionService(AccionRepository accionRepository)
        {
            _accionRepository = accionRepository;
        }

        public Task<IEnumerable<Accion>> GetAllAsync()
        {
            return _accionRepository.GetAllAsync();
        }

        public Task<Accion?> GetByIdAsync(int id)
        {
            return _accionRepository.GetByIdAsync(id);
        }

        public Task<int> InsertAsync(Accion accion)
        {
            return _accionRepository.InsertAsync(accion);
        }

        public Task<int> UpdateAsync(Accion accion)
        {
            return _accionRepository.UpdateAsync(accion);
        }

        public Task<int> DeleteAsync(int id)
        {
            return _accionRepository.DeleteAsync(id);
        }
    }
}
