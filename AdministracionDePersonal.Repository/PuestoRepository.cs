using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministracionDePersonal.Entities;
using Dapper;

namespace AdministracionDePersonal.Repository
{
    public class PuestoRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public PuestoRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Puesto>> GetAllAsync()
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<Puesto>("SELECT IdPuesto, Nombre, Salario, IdJefatura FROM Puesto");
            }
        }

        public async Task<Puesto?> GetByIdAsync(string id)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Puesto>("SELECT IdPuesto, Nombre, Salario, IdJefatura FROM Puesto WHERE IdPuesto = @Id",
                    new { Id = id });
            }
        }

        public async Task<int> InsertAsync(Puesto puesto)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO Puesto (Nombre, Salario, IdJefatura) VALUES (@Nombre, @Salario, @IdJefatura)";
                return await connection.ExecuteAsync(sql, puesto);
            }
        }

        public async Task<int> UpdateAsync(Puesto puesto)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var sql = "UPDATE Puesto SET Nombre = @Nombre, Salario = @Salario, IdJefatura = @IdJefatura WHERE IdPuesto = @IdPuesto";
                return await connection.ExecuteAsync(sql, puesto);
            }
        }

        public async Task<int> DeleteAsync(string id)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var sql = "DELETE FROM Puesto WHERE IdPuesto = @Id";
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
