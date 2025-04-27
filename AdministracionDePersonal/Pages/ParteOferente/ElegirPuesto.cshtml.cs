using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Servicess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.ParteOferente
{
    public class ElegirPuestoModel : PageModel
    {
        private readonly IOferenteService _oferenteService;

        public int idOferente { get; set; }
        public int idPuesto { get; set; }

        public ElegirPuestoModel(IOferenteService oferenteService)
        {
            _oferenteService = oferenteService;
            Puestos = new List<Puesto>();
        }

        public IEnumerable<Puesto> Puestos { get; set; }

        public async Task OnGetAsync(int id)
        {
            idOferente = id;
            Puestos = await _oferenteService.GetPuestosAsync();
        }




        public async Task<IActionResult> OnPostAsignarPuestoAsync(int idOferente, int idPuesto)
        {
            // Depura los valores
            Console.WriteLine($"idOferente: {idOferente}, idPuesto: {idPuesto}");

            if (ModelState.IsValid)
            {
                
                var empleadoCreado = await _oferenteService.ConvertirOferenteAEmpleadoAsync(idOferente, idPuesto);
                int idEmpleadoCreado = empleadoCreado.NuevoEmpleadoID;
                return RedirectToPage("/ParteOferente/CrearAccion", new { idOferente = idOferente, idPuesto = idPuesto, empleado = idEmpleadoCreado});
            }

            return Page();
        }




    }
}
