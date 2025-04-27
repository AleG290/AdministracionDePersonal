using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Repository;
using AdministracionDePersonal.Servicess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Servicess
{
    public class OferenteService : IOferenteService
    {
        private readonly OferenteRepository _oferenteRepository;

        public OferenteService(OferenteRepository oferenteRepository)
        {
            _oferenteRepository = oferenteRepository;
        }

        // Llamar al SP para convertir Oferente a Empleado
        
        public Task<Resultado> ConvertirOferenteAEmpleadoAsync(int oferenteID, int puestoID)
        {
            return _oferenteRepository.ConvertirOferenteAEmpleadoAsync(oferenteID, puestoID);
        }
        

        public Task<Accion> CrearAccionAsync(int idEmpleado, int puestoID, DateTime fecha, string descripcion, string tipoAccion, string observaciones)
        {
            return _oferenteRepository.CrearAccionAsync(idEmpleado, puestoID, fecha, descripcion, tipoAccion, observaciones);
        }

        // Obtener todos los oferentes
        public Task<IEnumerable<Oferente>> GetOferentesAsync()
        {
            return _oferenteRepository.GetOferentesAsync();
        }

        // Obtener todos los puestos
        public Task<IEnumerable<Puesto>> GetPuestosAsync()
        {
            return _oferenteRepository.GetPuestosAsync();
        }
    }
}
