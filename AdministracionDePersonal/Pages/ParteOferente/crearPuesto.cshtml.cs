using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdministracionDePersonal.Servicess.Abstract;
namespace AdministracionDePersonal.Pages.ParteOferente
{
    public class crearPuestoModel : PageModel
    {
        private readonly IPuestoService _puestoService;

        public crearPuestoModel(IPuestoService puestoService)
        {
            _puestoService = puestoService;
            Puesto = new Puesto();
        }

        [BindProperty]
        public Puesto Puesto { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _puestoService.InsertAsync(Puesto);

            return RedirectToPage("Index");
        }
    }
}
