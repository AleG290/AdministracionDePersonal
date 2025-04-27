using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.Requisitos
{
    public class IndexModel : PageModel
    {
        private readonly IRequisitoService _requisitoService;

        public IndexModel(IRequisitoService requisitoService)
        {
            _requisitoService = requisitoService;
            Requisitos = new List<Requisito>();
        }

        public IEnumerable<Requisito> Requisitos { get; set; }

        public async Task OnGetAsync()
        {
            Requisitos = await _requisitoService.GetAllAsync();
        }
    }
}
