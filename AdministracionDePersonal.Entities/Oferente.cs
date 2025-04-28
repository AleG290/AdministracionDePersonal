using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Entities
{
    public class Oferente
    {
        public int IdOferente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string TipoIdentificacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidad { get; set; }
        public int? IdDistrito { get; set; }
        public int? PuestoId { get; set; }
    }

}
