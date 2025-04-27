using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using AdministracionDePersonal.Servicess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.ParteOferente
{
    public class IndexModel : PageModel
    {
        private readonly IPuestoService _puestoService;

        public IndexModel(IPuestoService puestoService)
        {
            _puestoService = puestoService;
            Puestos = new List<Puesto>();
        }

        public IEnumerable<Puesto> Puestos { get; set; }

        public async Task OnGetAsync()
        {
            Puestos = await _puestoService.GetAllAsync();
        }
    }
}
