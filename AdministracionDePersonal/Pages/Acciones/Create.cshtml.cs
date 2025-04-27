using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdministracionDePersonal.Pages.Acciones
{
    public class CreateModel : PageModel
    {
        private readonly IAccionService _accionService;
        private readonly IEmpleadoService _empleadoService;

        public CreateModel(IAccionService accionService, IEmpleadoService empleadoService)
        {
            _accionService = accionService;
            _empleadoService = empleadoService;
        }

        [BindProperty]
        public Accion Accion { get; set; }

        public List<SelectListItem> Empleados { get; set; }
        public List<SelectListItem> Jefaturas { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await CargarCombosAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Verificar si los campos requeridos están seleccionados
            if (Accion.IdEmpleado == 0 || Accion.IdJefatura == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe seleccionar un empleado y una jefatura.");
                await CargarCombosAsync(); // Recargar combos si falla validación
                return Page();
            }

            // Si el modelo es válido, insertar la acción
            if (!ModelState.IsValid)
            {
                await CargarCombosAsync(); // Recargar combos si falla validación
                return Page();
            }

            // Insertar la acción en la base de datos
            await _accionService.InsertAsync(Accion);

            // Redirigir a la página de índice después de insertar
            return RedirectToPage("Index");
        }

        private async Task CargarCombosAsync()
        {
            // Obtener lista de empleados
            var empleados = await _empleadoService.GetEmpleadosAsync();
            Empleados = empleados.Select(e => new SelectListItem
            {
                Value = e.IdEmpleado.ToString(),
                Text = e.Nombre
            }).ToList();

            // Obtener lista de jefaturas
            var jefaturas = await _empleadoService.GetJefaturasAsync();
            Jefaturas = jefaturas.Select(j => new SelectListItem
            {
                Value = j.IdEmpleado.ToString(),
                Text = j.Nombre
            }).ToList();
        }
    }
}
