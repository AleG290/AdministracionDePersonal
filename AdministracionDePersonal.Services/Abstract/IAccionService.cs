using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministracionDePersonal.Entities;

namespace AdministracionDePersonal.Services.Abstract
{
    public interface IAccionService
    {
        Task<IEnumerable<Accion>> GetAllAsync(); // <-- Cambio aquí
        Task<Accion?> GetByIdAsync(int id);
        Task<int> InsertAsync(Accion accion);
        Task<int> UpdateAsync(Accion accion);
        Task<int> DeleteAsync(int id);

        // NUEVOS MÉTODOS
       
    }
}
