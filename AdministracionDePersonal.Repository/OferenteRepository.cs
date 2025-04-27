using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministracionDePersonal.Entities;
using Dapper;

namespace AdministracionDePersonal.Repository
{
    public class OferenteRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public OferenteRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        //Llamar al SP

        public async Task<Resultado> ConvertirOferenteAEmpleadoAsync(int oferenteID, int puestoID)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("OferenteID", oferenteID, DbType.Int32);
                parameters.Add("PuestoID", puestoID, DbType.Int32);
                parameters.Add("NuevoEmpleadoID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Ejecutar el procedimiento almacenado
                await connection.ExecuteAsync(
                    "SP_ConvertirOferente",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                // Obtener el valor del parámetro de salida
                var nuevoEmpleadoID = parameters.Get<int>("NuevoEmpleadoID");

                // Si no se obtuvo un ID de empleado, es un error
                if (nuevoEmpleadoID == 0)
                {
                    return new Resultado
                    {
                        Message = "Error desconocido",
                        NuevoEmpleadoID = nuevoEmpleadoID
                    };
                }

                // Si se obtuvo el ID, entonces está todo bien
                return new Resultado
                {
                    Message = "Empleado creado con exito",
                    NuevoEmpleadoID = nuevoEmpleadoID
                };
            }
        }



        /*
        public async Task<Resultado> ConvertirOferenteAEmpleadoAsync(int oferenteID, int puestoID)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("OferenteID", oferenteID, DbType.Int32);
                parameters.Add("PuestoID", puestoID, DbType.Int32);
                parameters.Add("NuevoEmpleadoID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Ejecutar el procedimiento almacenado
                var result = await connection.QueryAsync<Resultado>(
                    "SP_ConvertirOferente",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                // Obtener el valor del parámetro de salida
                var nuevoEmpleadoID = parameters.Get<int>("NuevoEmpleadoID");

                return result.FirstOrDefault() ?? new Resultado
                {
                    Message = "Error desconocido",
                    NuevoEmpleadoID = nuevoEmpleadoID
                };
            }
        }
        */

        //Obtner oferente
        public async Task<IEnumerable<Oferente>> GetOferentesAsync()
        {
            if (_dbConnectionFactory == null)
            {
                throw new InvalidOperationException("DbConnectionFactory no ha sido inicializado.");
                
            }
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var oferentes = await connection.QueryAsync<Oferente>("SELECT IdOferente, Nombre, Direccion, TipoIdentificacion, FechaNacimiento, EstadoCivil, Nacionalidad, IdDistrito FROM Oferente");
                return oferentes;
            }
        }

        //Obtener puestos
        public async Task<IEnumerable<Puesto>> GetPuestosAsync()
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var puestos = await connection.QueryAsync<Puesto>("SELECT IdPuesto, Nombre, Salario, IdJefatura FROM Puesto");
                return puestos;
            }
        }

        //Crear accion
        public async Task<Accion> CrearAccionAsync(int idEmpleado, int idPuesto, DateTime fecha, string descripcion, string tipoAccion, string observaciones)
        {
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                // Ejecutar el SP CrearAccion
                var result = await connection.QueryAsync<Accion>(
                    "CrearAccion", // Nombre del SP
                    new
                    {
                        p_IdEmpleado = idEmpleado,
                        p_IdPuesto = idPuesto,
                        p_Fecha = fecha,
                        p_Descripcion = descripcion,
                        p_TipoAccion = tipoAccion,
                        p_Observaciones = observaciones
                    },
                    commandType: CommandType.StoredProcedure // Indicar que es un SP
                );

                return result.FirstOrDefault() ?? new Accion();
            }
        }


    }
}
