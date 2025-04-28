using Areas.Entities;
using Areas.Entities.Areas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Services.Abstract
{
    public interface IAreaServices
    {
        Task<IEnumerable<AreasAdmin>> GetAllAsync();
        Task<AreasAdmin?> GetByIdAsync(int id);
        Task<int> crearareaAsync(AreasAdmin area);
        Task<int> editarareaAsync(AreasAdmin area);
        Task<int> DeleteAsync(int id);
        //Task<int> AsignacionAsync(int id);
        Task<IEnumerable<Accion>> GetIdJefaturaAsync();



    }


}
