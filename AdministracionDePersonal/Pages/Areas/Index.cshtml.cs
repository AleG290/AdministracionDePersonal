using Area.Services.Abstract;
using Areas.Entities; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDePersonal.Pages.Areas
{
    public class IndexModel : PageModel
    {
      

        private readonly IAreaServices _areaservices;

        public IndexModel(IAreaServices areaservices)
        {
            _areaservices = areaservices;

        }

        public IEnumerable<AreasAdmin> Areas { get; set; }

        public async Task OnGetAsync()
        {
            Areas = await _areaservices.GetAllAsync();

        }
       


    }
}
