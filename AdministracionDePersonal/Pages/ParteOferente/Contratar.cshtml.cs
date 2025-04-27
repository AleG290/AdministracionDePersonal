using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Repository;
using AdministracionDePersonal.Servicess;
using AdministracionDePersonal.Servicess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.ParteOferente
{
    public class ContratarModel : PageModel
    {
        private readonly IOferenteService _oferenteService;

        public ContratarModel(IOferenteService oferenteService)
        {
            _oferenteService = oferenteService;
            Oferentes = new List<Oferente>();
        }

        public IEnumerable<Oferente> Oferentes { get; set; }

        public async Task OnGetAsync()
        {
            Oferentes = await _oferenteService.GetOferentesAsync();
        }
    }
}
