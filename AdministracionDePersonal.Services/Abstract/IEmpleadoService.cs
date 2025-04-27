using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministracionDePersonal.Entities;

namespace AdministracionDePersonal.Services.Abstract
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetEmpleadosAsync();
        Task<IEnumerable<Empleado>> GetJefaturasAsync();
    }
}
