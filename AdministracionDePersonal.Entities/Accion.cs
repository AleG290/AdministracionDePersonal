namespace AdministracionDePersonal.Entities
{
    public class Accion
    {
        public int IdAccion { get; set; }
        public int IdEmpleado { get; set; }
        public int IdJefatura { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string TipoAccion { get; set; }
        public string Observaciones { get; set; }

        public string? NombreEmpleado { get; set; }
        public string? NombreJefatura { get; set; }
    }
}
