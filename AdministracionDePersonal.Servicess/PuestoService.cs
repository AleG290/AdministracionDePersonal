using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Repository;
using AdministracionDePersonal.Servicess.Abstract;

namespace AdministracionDePersonal.Servicess
{
    public class PuestoService : IPuestoService
    {
        private readonly PuestoRepository _puestoRepository;

        public PuestoService(PuestoRepository puestoRepository)
        {
            _puestoRepository = puestoRepository;
        }

        public Task<IEnumerable<Puesto>> GetAllAsync()
        {
            return _puestoRepository.GetAllAsync();
        }

        public Task<Puesto?> GetByIdAsync(string id)
        {
            return _puestoRepository.GetByIdAsync(id);
        }

        public Task<int> InsertAsync(Puesto puesto)
        {
            return _puestoRepository.InsertAsync(puesto);
        }

        public Task<int> UpdateAsync(Puesto puesto)
        {
            return _puestoRepository.UpdateAsync(puesto);
        }

        public Task<int> DeleteAsync(string id)
        {
            return _puestoRepository.DeleteAsync(id);
        }
    }
}
