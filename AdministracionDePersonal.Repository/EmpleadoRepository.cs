using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministracionDePersonal.Entities;
using AdministracionDePersonal.Repository;
using System.Data.Entity;

namespace AdministracionDePersonal.Repository
{
    public class EmpleadoRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public EmpleadoRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Empleado>> GetEmpleadosAsync()
        {
            var sql = @"SELECT IdEmpleado, Nombre FROM Empleado";
            using var connection = _dbConnectionFactory.CreateConnection();
            return await connection.QueryAsync<Empleado>(sql);
        }

        public async Task<IEnumerable<Empleado>> GetJefaturasAsync()
        {
            var sql = @"SELECT e.IdEmpleado, e.Nombre
                FROM Empleado e
                INNER JOIN Puestos p ON e.Puesto = p.IdPuesto
                WHERE p.Jefatura IS NOT NULL";
            using var connection = _dbConnectionFactory.CreateConnection();
            return await connection.QueryAsync<Empleado>(sql);
        }
    }
}
