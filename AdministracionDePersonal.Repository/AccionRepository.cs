using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionDePersonal.Repository
{
    public class AccionRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public AccionRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Accion>> GetAllAsync()
        {
            try
            {
                using (var connection = _dbConnectionFactory.CreateConnection())
                {
                    var sql = @"
                SELECT 
                    a.IdAccion,
                    a.IdEmpleado,
                    a.IdJefatura,
                    a.Fecha,
                    a.Descripcion,
                    a.TipoAccion,
                    a.Observaciones,
                    e1.Nombre AS NombreEmpleado,
                    e2.Nombre AS NombreJefatura
                FROM Accion a
                LEFT JOIN Empleado e1 ON a.IdEmpleado = e1.IdEmpleado
                LEFT JOIN Empleado e2 ON a.IdJefatura = e2.IdEmpleado";

                    return await connection.QueryAsync<Accion>(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllAsync: {ex.Message}");
                return new List<Accion>();
            }
        }

        public async Task<Accion?> GetByIdAsync(int id)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Accion>(
                    "SELECT IdAccion, IdEmpleado, IdJefatura, Fecha, Descripcion, TipoAccion, Observaciones FROM Accion WHERE IdAccion = @Id",
                    new { Id = id }
                );
            }
        }

        public async Task<int> InsertAsync(Accion accion)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO Accion (IdAccion, IdEmpleado, IdJefatura, Fecha, Descripcion, TipoAccion, Observaciones) VALUES (@IdAccion, @IdEmpleado, @IdJefatura, @Fecha, @Descripcion, @TipoAccion, @Observaciones)";
                return await connection.ExecuteAsync(sql, accion);
            }
        }

        public async Task<int> UpdateAsync(Accion accion)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var sql = "UPDATE Accion SET IdAccion = @IdAccion, IdEmpleado = @IdEmpleado, IdJefatura = @IdJefatura, Fecha = @Fecha, Descripcion = @Descripcion, TipoAccion = @TipoAccion, Observaciones = @Observaciones WHERE IdAccion = @IdAccion";
                return await connection.ExecuteAsync(sql, accion);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var sql = "DELETE FROM Accion WHERE IdAccion = @Id";
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
