using Area.Services.Abstract;
using Areas.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminDePersonal.Pages.Areas
{

    public class DeleteModel : PageModel
    {
        private readonly IAreaServices _areaService;

        public DeleteModel(IAreaServices areaService)
        {
            _areaService = areaService;
        }

        [BindProperty]
        public AreasAdmin? Areas { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            Areas = await _areaService.GetByIdAsync(id);

            if (Areas == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Areas == null || Areas.IdArea <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var resultado = await _areaService.DeleteAsync(Areas.IdArea);

            if (resultado == -1)
            {
                ModelState.AddModelError("", "No se puede eliminar un registro con datos relacionados.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }






















    //    public class DeleteModel : PageModel
    //    {
    //        private readonly IAreaServices _areaService;

    //        public DeleteModel(IAreaServices areaService)
    //        {
    //            _areaService = areaService;
    //        }

    //        [BindProperty]
    //        public AreasAdmin? Areas { get; set; }



    //        public async Task<IActionResult> OnGetAsync(int id)
    //        {
    //            if (id <= 0)
    //            {
    //                return BadRequest("ID inválido.");
    //            }

    //            Areas = await _areaService.GetByIdAsync(id);

    //            if (Areas == null)
    //            {
    //                return NotFound();
    //            }

    //            return Page();
    //        }

    //        public async Task<IActionResult> OnPostAsync()
    //        {
    //            if (Areas == null || Areas.IdArea <= 0)
    //            {
    //                return BadRequest("ID inválido.");
    //            }

    //            await _areaService.DeleteAsync(Areas.IdArea);

    //            return RedirectToPage("Index");
    //        }
    //    }
}
