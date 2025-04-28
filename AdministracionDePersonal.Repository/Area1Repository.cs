using AdministracionDePersonal.Repository;
using Areas.Entities;
using Areas.Entities.Areas.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Areas.Repository
{
    public class Area1Repository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public Area1Repository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<IEnumerable<AreasAdmin>> GetAllAsync()
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            return await connection.QueryAsync<AreasAdmin>("CALL GetAllAreas();");
        }

      


        //**************************************************
        public async Task<AreasAdmin?> GetByIdAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<AreasAdmin>(
                "CALL GetAreaById(@IdArea);",
                new { IdArea = id }
            );
        }
        private bool ValidarNombre(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre) &&
                   Regex.IsMatch(nombre, @"^[A-Za-zÁÉÍÓÚáéíóúÑñ ]{1,100}$");
        }

        //********************************************************************


        public async Task<int> crearareaAsync(AreasAdmin area)
        {
            if (!ValidarNombre(area.Nombre))
            {
                throw new ArgumentException("El nombre solo puede contener letras y espacios, con un máximo de 10 caracteres.");
            }

            if (area.IdJefatura < 1 || area.IdJefatura > 1000)
            {
                throw new ArgumentException("El IdJefatura debe estar entre 1 y 10.");
            }
            using var connection = _dbConnectionFactory.CreateConnection();
            var sql = "CALL creararea(@IdArea, @Nombre, @IdJefatura, @Descripcion);";
            return await connection.ExecuteAsync(sql, area);
        }


        //*****************************************************


        public async Task<int> editarareaAsync(AreasAdmin area)
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            var sql = "CALL EditArea(@IdArea, @Nombre, @IdJefatura, @Descripcion);";
            return await connection.ExecuteAsync(sql, area);
        }
        // Editar 
        //public async Task<int> editarareaAsync(AreasAdmin area)
        //{
        //    using var connection = _dbConnectionFactory.CreateConnection();
        //    var sql = "UPDATE Area SET Nombre = @Nombre, IdJefatura = @IdJefatura, Descripcion = @Descripcion WHERE IdArea = @IdArea";
        //    return await connection.ExecuteAsync(sql, area);
        //}



        public async Task<bool> TieneAsignacionesAsync(IDbConnection connection, int id)
        {
            var sql = "SELECT COUNT(*) FROM empleado WHERE IdArea = @IdArea";
            int count = await connection.ExecuteScalarAsync<int>(sql, new { IdArea = id });
            return count > 0; 
        }

       

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = _dbConnectionFactory.CreateConnection();

            bool tieneAsignaciones = await TieneAsignacionesAsync(connection, id);
            if (tieneAsignaciones)
            {
                return -1; // Indica que no se puede eliminar
            }

            var sql = "DELETE FROM area WHERE IdArea = @IdArea";
            return await connection.ExecuteAsync(sql, new { IdArea = id });
        }
        public async Task<IEnumerable<Accion>> GetIdJefaturaAsync()
        {
            using var connection = _dbConnectionFactory.CreateConnection();
            return await connection.QueryAsync<Accion>("SELECT IdJefatura FROM accion;");

        }




    }
}
