using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Servicess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.ParteOferente
{
    public class editarPuestoModel : PageModel
    {
        private readonly IPuestoService _puestoService;

        public editarPuestoModel(IPuestoService puestoService)
        {
            _puestoService = puestoService;
            Puesto = new Puesto();
        }

        [BindProperty]
        public Puesto Puesto { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {

            Puesto = await _puestoService.GetByIdAsync(id);

            if (Puesto == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _puestoService.UpdateAsync(Puesto);

            return RedirectToPage("Index");
        }
    }
}
