using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdministracionDePersonal.Pages.Acciones
{
    public class EditModel : PageModel
    {
        private readonly IAccionService _accionService;
        private readonly IEmpleadoService _empleadoService;

        public EditModel(IAccionService accionService, IEmpleadoService empleadoService)
        {
            _accionService = accionService;
            _empleadoService = empleadoService;
            Accion = new Accion();
        }

        [BindProperty]
        public Accion Accion { get; set; }

        public SelectList Empleados { get; set; }
        public SelectList Jefaturas { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (!int.TryParse(id, out int idParsed))
            {
                return BadRequest("El ID proporcionado no es válido.");
            }

            Accion = await _accionService.GetByIdAsync(idParsed);

            if (Accion == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(Accion.Descripcion))
            {
                Accion.Descripcion = "Sin descripción";
            }

            await CargarListasAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CargarListasAsync();
                return Page();
            }

            await _accionService.UpdateAsync(Accion);
            return RedirectToPage("Index");
        }

        private async Task CargarListasAsync()
        {
            var empleados = await _empleadoService.GetEmpleadosAsync();
            var jefaturas = await _empleadoService.GetJefaturasAsync();

            Empleados = new SelectList(empleados, "IdEmpleado", "Nombre");
            Jefaturas = new SelectList(jefaturas, "IdEmpleado", "Nombre");
        }
    }
}
