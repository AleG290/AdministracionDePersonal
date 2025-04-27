using AdministracionDePersonal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Servicess.Abstract
{
    public interface IOferenteService
    {
        Task<Resultado> ConvertirOferenteAEmpleadoAsync(int oferenteID, int puestoID);
        Task<IEnumerable<Oferente>> GetOferentesAsync();
        Task<IEnumerable<Puesto>> GetPuestosAsync();
        Task<Accion> CrearAccionAsync(int idEmpleado, int puestoID, DateTime fecha, string descripcion, string tipoAccion, string observaciones);
    }

}
