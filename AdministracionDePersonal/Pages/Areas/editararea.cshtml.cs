using Area.Services.Abstract;
using Areas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDePersonal.Pages.Areas
{
    public class editarareaModel : PageModel
    {
        private readonly IAreaServices _areaServices;

        public editarareaModel(IAreaServices areaService)
        {
            _areaServices = areaService;
        }

        [BindProperty]
        public AreasAdmin AreaEdit { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (!int.TryParse(id, out int idParsed))
            {
                return BadRequest("El ID proporcionado no es válido.");
            }
            AreaEdit = await _areaServices.GetByIdAsync(idParsed);
            if (AreaEdit == null)
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
            await _areaServices.editarareaAsync(AreaEdit);

        

            return RedirectToPage("Index");
        }
    }
}
