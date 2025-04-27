using AdministracionDePersonal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Services.Abstract
{
    public interface IRequisitoService
    {
        Task<IEnumerable<Requisito>> GetAllAsync();
        Task<Requisito?> GetByIdAsync(int id);
        Task<int> InsertAsync(Requisito requisito);
        Task<int> UpdateAsync(Requisito requisito);
        Task<int> DeleteAsync(int id);
    }
}
