using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Areas.Entities
{
    public class AreasAdmin
    {
        [Required(ErrorMessage = "El ID del área es obligatorio.")]
        public int IdArea { get; set; }

        [Required(ErrorMessage = "El nombre del área es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        [MinLength(2, ErrorMessage = "El nombre debe tener minimo 2 caracteres")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ ]{1,100}$",
            ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El IdJefatura es obligatorio.")]
        public int IdJefatura { get; set; }

    
        public string Descripcion { get; set; }


    }
}
