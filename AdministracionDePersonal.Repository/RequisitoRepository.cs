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
    public class RequisitoRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public RequisitoRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Requisito>> GetAllAsync()
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<Requisito>("SELECT IdRequisito, IdPuesto, Descripcion, Tipo FROM Requisito");
            }
        }

        public async Task<Requisito?> GetByIdAsync(int id)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Requisito>(
                    "SELECT IdRequisito, IdPuesto, Descripcion, Tipo FROM Requisito WHERE IdRequisito = @Id",
                    new { Id = id }
                );
            }
        }

        public async Task<int> InsertAsync(Requisito requisito)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO Requisito (IdPuesto, Descripcion, Tipo) VALUES (@IdPuesto, @Descripcion, @Tipo)";
                return await connection.ExecuteAsync(sql, requisito);
            }
        }

        public async Task<int> UpdateAsync(Requisito requisito)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var sql = "UPDATE Requisito SET IdPuesto = @IdPuesto, Descripcion = @Descripcion, Tipo = @Tipo WHERE IdRequisito = @IdRequisito";
                return await connection.ExecuteAsync(sql, requisito);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var sql = "DELETE FROM Requisito WHERE IdRequisito = @Id";
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
