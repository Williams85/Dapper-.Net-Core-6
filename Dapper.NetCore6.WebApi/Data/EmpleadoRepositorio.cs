using Dapper.NetCore6.WebApi.Data.Db;
using Dapper.NetCore6.WebApi.Data.Service;
using Dapper.NetCore6.WebApi.Model;
using System.Data;

namespace Dapper.NetCore6.WebApi.Data
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {

        private readonly IConnectionFactory _connectionFactory;

        public EmpleadoRepositorio(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<EmpleadoEntidad>> ListarAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "usp_Empleado_Listar";
                return await connection.QueryAsync<EmpleadoEntidad>(query, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<EmpleadoEntidad> BuscarAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "usp_Empleado_BuscarPorId";
                var parameters = new DynamicParameters();
                parameters.Add("Codi_Empleado", id);
                return await connection.QuerySingleAsync<EmpleadoEntidad>(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<EmpleadoEntidad>> FiltrarAsync(EmpleadoEntidad entidad)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "usp_Empleado_Filtrar";
                var parameters = new DynamicParameters();
                parameters.Add("Nombres_Empleado", entidad.Nombres_Empleado);
                parameters.Add("Apellidos_Empleado", entidad.Apellidos_Empleado);
                return await connection.QueryAsync<EmpleadoEntidad>(query, param: parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<EmpleadoEntidad> RegistrarAsync(EmpleadoEntidad entidad)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "usp_Empleado_Registrar";
                var parameters = new DynamicParameters();
                parameters.Add("Nombres_Empleado", entidad.Nombres_Empleado);
                parameters.Add("Apellidos_Empleado", entidad.Apellidos_Empleado);
                parameters.Add("Direccion_Empleado", entidad.Direccion_Empleado);
                parameters.Add("Telefono_Empleado", entidad.Telefono_Empleado);
                parameters.Add("Email_Empleado", entidad.Email_Empleado);
                parameters.Add("FechaNacimiento_Empleado", entidad.FechaNacimiento_Empleado);
                parameters.Add("Sueldo_Empleado", entidad.Sueldo_Empleado);
                parameters.Add("Activo", entidad.Activo);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return entidad;
                else
                    return new EmpleadoEntidad();
            }
        }

        public async Task<EmpleadoEntidad> ModificarAsync(EmpleadoEntidad entidad)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "usp_Empleado_Modificar";
                var parameters = new DynamicParameters();
                parameters.Add("Codi_Empleado", entidad.Codi_Empleado);
                parameters.Add("Nombres_Empleado", entidad.Nombres_Empleado);
                parameters.Add("Apellidos_Empleado", entidad.Apellidos_Empleado);
                parameters.Add("Direccion_Empleado", entidad.Direccion_Empleado);
                parameters.Add("Telefono_Empleado", entidad.Telefono_Empleado);
                parameters.Add("Email_Empleado", entidad.Email_Empleado);
                parameters.Add("FechaNacimiento_Empleado", entidad.FechaNacimiento_Empleado);
                parameters.Add("Sueldo_Empleado", entidad.Sueldo_Empleado);
                parameters.Add("Activo", entidad.Activo);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return entidad;
                else
                    return new EmpleadoEntidad();
            }
        }
        public async Task<bool> EliminarAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "usp_Empleado_Eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("Codi_Empleado", id);
                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

    }
}
