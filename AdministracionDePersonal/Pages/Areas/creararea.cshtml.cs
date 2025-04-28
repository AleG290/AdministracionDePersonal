using Area.Services.Abstract;
using Areas.Entities;
using Areas.Entities.Areas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDePersonal.Pages.Areas
{
    public class crearareaModel : PageModel
    {
        private readonly IAreaServices _areaServices;

        public crearareaModel(IAreaServices areaServices)
        {
            _areaServices = areaServices;
            NuevaArea = new AreasAdmin();
        }

        [BindProperty]
        public AreasAdmin NuevaArea { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _areaServices.crearareaAsync(NuevaArea);
            return RedirectToPage("Index");
        }
       public List<Accion> Accion { get; set; } = new List<Accion>(); // Definir propiedad

        public async Task OnGetAsync()
        {
            Accion = (await _areaServices.GetIdJefaturaAsync()).ToList(); // Cargar lista de Jefaturas
        }
      

    }
}
