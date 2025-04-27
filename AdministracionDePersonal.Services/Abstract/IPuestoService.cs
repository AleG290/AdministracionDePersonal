using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministracionDePersonal.Entities;

namespace AdministracionDePersonal.Servicess.Abstract
{
    public interface IPuestoService
    {
        Task<IEnumerable<Puesto>> GetAllAsync();
        Task<Puesto?> GetByIdAsync(string id);
        Task<int> InsertAsync(Puesto puesto);
        Task<int> UpdateAsync(Puesto puesto);
        Task<int> DeleteAsync(string id);

    }
}
