using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.Acciones
{
    public class IndexModel : PageModel
    {
        private readonly IAccionService _accionService;

        public IndexModel(IAccionService accionService)
        {
            _accionService = accionService;
            Acciones = new List<Accion>();
        }

        public IEnumerable<Accion> Acciones { get; set; }

        public async Task OnGetAsync()
        {
            Acciones = await _accionService.GetAllAsync();
        }
    }
}
