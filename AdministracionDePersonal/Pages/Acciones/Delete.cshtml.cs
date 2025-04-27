using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;

namespace AdministracionDePersonal.Pages.Acciones
{
    public class DeleteModel : PageModel
    {
        private readonly IAccionService _accionService;

        public DeleteModel(IAccionService accionService)
        {
            _accionService = accionService;
        }

        [BindProperty]
        public Accion? Accion { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (!int.TryParse(id, out int accionId))
            {
                return BadRequest();
            }

            Accion = await _accionService.GetByIdAsync(accionId);

            if (Accion == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!int.TryParse(id, out int accionId))
            {
                return BadRequest();
            }

            await _accionService.DeleteAsync(accionId);

            return RedirectToPage("Index");
        }
    }
}
