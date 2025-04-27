using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.Requisitos
{
    public class DeleteModel : PageModel
    {
        private readonly IRequisitoService _requisitoService;

        public DeleteModel(IRequisitoService requisitoService)
        {
            _requisitoService = requisitoService;
        }

        [BindProperty]
        public Requisito? Requisito { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (!int.TryParse(id, out int requisitoId))
            {
                return BadRequest();
            }

            Requisito = await _requisitoService.GetByIdAsync(requisitoId);

            if (Requisito == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!int.TryParse(id, out int requisitoId))
            {
                return BadRequest();
            }

            await _requisitoService.DeleteAsync(requisitoId);

            return RedirectToPage("Index");
        }

    }
}
