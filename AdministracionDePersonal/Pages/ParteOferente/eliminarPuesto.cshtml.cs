using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Servicess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.ParteOferente
{
    public class eliminarPuestoModel : PageModel
    {
        private readonly IPuestoService _puestoService;

        public eliminarPuestoModel(IPuestoService puestoService)
        {
            _puestoService = puestoService;
        }

        [BindProperty]
        public Puesto? Puesto { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Puesto = await _puestoService.GetByIdAsync(id);

            if (Puesto == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            await _puestoService.DeleteAsync(id);

            return RedirectToPage("Index");
        }

    }
}
