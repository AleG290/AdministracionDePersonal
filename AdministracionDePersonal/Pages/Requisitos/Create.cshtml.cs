using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.Requisitos
{
    public class CreateModel : PageModel
    {
        private readonly IRequisitoService _requisitoService;

        public CreateModel(IRequisitoService requisitoService)
        {
            _requisitoService = requisitoService;
            Requisito = new Requisito();
        }

        [BindProperty]
        public Requisito Requisito { get; set; }

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

            await _requisitoService.InsertAsync(Requisito);

            return RedirectToPage("Index");
        }
    }
}