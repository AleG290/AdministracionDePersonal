using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Entities
{
    public class Puesto
    {
        public int IdPuesto { get; set; }
        public string Nombre { get; set; }
        public decimal? Salario { get; set; } 
        public int? IdJefatura { get; set; }   
    }

}
