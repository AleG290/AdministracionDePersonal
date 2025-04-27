using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Pages.Requisitos
{
    public class EditModel : PageModel
    {
        private readonly IRequisitoService _requisitoService;

        public EditModel(IRequisitoService requisitoService)
        {
            _requisitoService = requisitoService;
            Requisito = new Requisito();
        }

        [BindProperty]
        public Requisito Requisito { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (!int.TryParse(id, out int idParsed))
            {
                return BadRequest("El ID proporcionado no es válido.");
            }

            Requisito = await _requisitoService.GetByIdAsync(idParsed);

            if (Requisito == null)
            {
                return NotFound();
            }

            // Asegurar que Descripcion no sea null
            if (string.IsNullOrEmpty(Requisito.Descripcion))
            {
                Requisito.Descripcion = "Sin descripción"; // Valor por defecto
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _requisitoService.UpdateAsync(Requisito);

            return RedirectToPage("Index");
        }
    }
}
