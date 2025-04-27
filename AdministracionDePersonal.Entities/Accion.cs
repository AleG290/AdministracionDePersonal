using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Entities
{
    public class Accion
    {
        public int IdAccion { get; set; }

        public string? NombreEmpleado { get; set; }
        public string? NombreJefatura { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdJefatura { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public string TipoAccion { get; set; }
        public string Observaciones { get; set; }
        
        //Parte alejandro
        public string? NombreEmpleado { get; set; }
        public string? NombreJefatura { get; set; }
    }
}
