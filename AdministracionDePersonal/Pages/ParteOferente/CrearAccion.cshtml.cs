using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Servicess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdministracionDePersonal.Pages.ParteOferente
{
    public class CrearAccionModel : PageModel
    {
        private readonly IOferenteService _oferenteService;

        public CrearAccionModel(IOferenteService oferenteService)
        {
            _oferenteService = oferenteService;
            Acciones = new Accion();
        }

        public Accion Acciones;

        public int IdOferente { get; set; }


        public string Descripcion { get; set; }

        public string TipoAccion { get; set; }

        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }

        [BindProperty(SupportsGet = true)]
        public int IdPuesto { get; set; }
        [BindProperty(SupportsGet = true)]
        public int IdEmpleado { get; set; }

        /*
        [BindProperty]
        public string Descripcion { get; set; }
        [BindProperty]
        public string TipoAccion { get; set; }
        [BindProperty]
        public string Observaciones { get; set; }
        [BindProperty]
        public DateTime Fecha { get; set; }
        
        */

        public void OnGet()
        {
            // Intentar leer los parámetros directamente desde la URL
            IdOferente = Convert.ToInt32(Request.Query["idOferente"]);
            IdPuesto = Convert.ToInt32(Request.Query["idPuesto"]);
            IdEmpleado = Convert.ToInt32(Request.Query["empleado"]);

            Console.WriteLine($"IdOferente: {IdOferente}, IdPuesto: {IdPuesto}, IdEmpleado: {IdEmpleado}");
        }

        public async Task<IActionResult> OnPostCrearAccionAsync()
        {
            int idEmpleado = Convert.ToInt32(Request.Form["IdEmpleado"]);
            int idPuesto = Convert.ToInt32(Request.Form["IdPuesto"]);
            DateTime fecha = Convert.ToDateTime(Request.Form["Fecha"]);
            string descripcion = Request.Form["Descripcion"];
            string tipoAccion = Request.Form["TipoAccion"];
            string observaciones = Request.Form["Observaciones"];

            Console.WriteLine($"idEmpleado: {idEmpleado}, idPuesto: {idPuesto}, fecha: {fecha}, descripcion: {descripcion}, tipoAccion: {tipoAccion}, observaciones: {observaciones}");

            if (ModelState.IsValid)
            {
                var empleadoCreado = await _oferenteService.CrearAccionAsync(idEmpleado, idPuesto, fecha, descripcion, tipoAccion, observaciones);

                return RedirectToPage("/ParteOferente/Contratar");
            }

            return Page();
        }
        //Metodo sin passar por el js
        /*
        public async Task<IActionResult> OnPostCrearAccionAsync()
        {
            Console.WriteLine($"idEmpleado: {IdEmpleado}, idPuesto: {IdPuesto}, fecha: {Fecha}, descripcion: {Descripcion}, tipoAccion: {TipoAccion}, observaciones: {Observaciones}");

            if (ModelState.IsValid)
            {
                var empleadoCreado = await _oferenteService.CrearAccionAsync(IdEmpleado, IdPuesto, Fecha, Descripcion, TipoAccion, Observaciones);

                return RedirectToPage("/ParteOferente/Contratar");
            }

            return Page();
        }
        */

        /*
        public void OnGet(int idOferente, int idPuesto, int idEmpleado)
        {
            IdOferente = idOferente;
            IdPuesto = idPuesto;
            IdEmpleado = idEmpleado; 
        }
        */


        /*
        public async Task<IActionResult> OnPostCrearAccionAsync([Bind("IdEmpleado, IdPuesto")] int idEmpleado, int idPuesto, DateTime fecha, string descripcion, string tipoAccion, string observaciones)
        {
            Console.WriteLine($"idEmpleado: {idEmpleado}, idPuesto: {idPuesto}, fecha: {fecha}, descripcion: {descripcion}, tipoAccion: {tipoAccion}, observaciones: {observaciones}");

            Console.WriteLine($"idEmpleado: {idEmpleado}, idPuesto: {idPuesto}, fecha: {Fecha}, descripcion: {Descripcion}, tipoAccion: {TipoAccion}, observaciones: {Observaciones}");
            if (ModelState.IsValid)
            {
                var empleadoCreado = await _oferenteService.CrearAccionAsync(idEmpleado, idPuesto, fecha, descripcion, tipoAccion, observaciones);

                return RedirectToPage("/ParteOferente/Contratar");
            }

            return Page();
        }
        */

        /*
        public async Task<IActionResult> OnPostCrearAccionAsync(int idEmpleado, int idPuesto, DateTime fecha, string descripcion, string tipoAccion, string observaciones)
        {
            Console.WriteLine($"idEmpleado: {idEmpleado}, idPuesto: {idPuesto}, fecha: {fecha}, descripcion: {descripcion}, tipoAccion: {tipoAccion}, observaciones: {observaciones}");

            if (ModelState.IsValid)
            {
                var empleadoCreado = await _oferenteService.CrearAccionAsync(idEmpleado, idPuesto, fecha, descripcion, tipoAccion, observaciones);

                return RedirectToPage("/ParteOferente/Contratar");
            }

            return Page();
        }
        */
    }
}
