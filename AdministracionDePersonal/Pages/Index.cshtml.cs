using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AdminDePersonal.Pages
{
    using global::Areas.Entities.Areas.Entities;
    using global::Areas.Repository;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Area1Repository _repository;

        public IndexModel(ILogger<IndexModel> logger, Area1Repository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public List<Accion> Jefaturas { get; set; } = new List<Accion>();

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Jefaturas = (await _repository.GetIdJefaturaAsync()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al obtener jefaturas: {ErrorMessage}", ex.Message);
            }

            return Page();
        }
    }




    //public class IndexModel : PageModel
    //{
    //    private readonly ILogger<IndexModel> _logger;

    //    public IndexModel(ILogger<IndexModel> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public void OnGet()
    //    {

    //    }
    //}

}
