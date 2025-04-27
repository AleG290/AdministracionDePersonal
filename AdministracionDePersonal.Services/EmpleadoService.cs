using AdministracionDePersonal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;

namespace AdministracionDePersonal.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly EmpleadoRepository _empleadoRepository;

        public EmpleadoService(EmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public Task<IEnumerable<Empleado>> GetEmpleadosAsync()
        {
            return _empleadoRepository.GetEmpleadosAsync();
        }

        public Task<IEnumerable<Empleado>> GetJefaturasAsync()
        {
            return _empleadoRepository.GetJefaturasAsync();
        }
    }
}
