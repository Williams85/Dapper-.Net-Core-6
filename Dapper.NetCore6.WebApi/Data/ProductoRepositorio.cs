using Dapper.NetCore6.WebApi.Data.Db;
using Dapper.NetCore6.WebApi.Data.Service;
using Dapper.NetCore6.WebApi.Model;
using System.Data;

namespace Dapper.NetCore6.WebApi.Data
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        readonly IConnectionFactory _connectionFactory;

        public ProductoRepositorio(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<ProductoEntidad>> ListarAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "usp_Producto_Listar";
                return await connection.QueryAsync<ProductoEntidad>(query, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ProductoEntidad> BuscarAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "usp_Producto_Buscar";
                var parameters = new DynamicParameters();
                parameters.Add("Codi_Producto", id);
                return await connection.QuerySingleAsync<ProductoEntidad>(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<ProductoEntidad>> FiltrarAsync(ProductoEntidad entidad)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "usp_Producto_Filtrar";
                var parameters = new DynamicParameters();
                parameters.Add("Descripcion_Producto", entidad.Descripcion_Producto);
                return await connection.QueryAsync<ProductoEntidad>(query, param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ProductoEntidad> RegistrarAsync(ProductoEntidad entidad)
        {
            using (var connection = _connectionFactory.GetConnection)
            {

                using (var transaction = connection.BeginTransaction())
                {
                    var query = "usp_Producto_Registrar";
                    var parameters = new DynamicParameters();
                    parameters.Add("Descripcion_Producto", entidad.Descripcion_Producto);
                    parameters.Add("Cantidad_Producto", entidad.Cantidad_Producto);
                    parameters.Add("Precio_Producto", entidad.Precio_Producto);
                    parameters.Add("Activo", entidad.Activo);
                    var result = await connection.ExecuteAsync(query, param: parameters,transaction:transaction, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        transaction.Commit();
                        return entidad;
                    }
                    else
                    {
                        transaction.Rollback();
                        return new ProductoEntidad();
                    }

                }
            }
        }

        public async Task<ProductoEntidad> ModificarAsync(ProductoEntidad entidad)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                using (var transaction = connection.BeginTransaction())
                {
                    var query = "usp_Producto_Modificar";
                    var parameters = new DynamicParameters();
                    parameters.Add("Codi_Producto", entidad.Codi_Producto);
                    parameters.Add("Descripcion_Producto", entidad.Descripcion_Producto);
                    parameters.Add("Cantidad_Producto", entidad.Cantidad_Producto);
                    parameters.Add("Precio_Producto", entidad.Precio_Producto);
                    parameters.Add("Activo", entidad.Activo);
                    var result = await connection.ExecuteAsync(query, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        transaction.Commit();
                        return entidad;
                    }
                    else
                    {
                        transaction.Rollback();
                        return new ProductoEntidad();
                    }

                }

            }
        }
        public async Task<bool> EliminarAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                using (var transaction = connection.BeginTransaction())
                {
                    var query = "usp_Producto_Eliminar";
                    var parameters = new DynamicParameters();
                    parameters.Add("Codi_Producto", id);
                    var result = await connection.ExecuteAsync(query, param: parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                    if(result > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

            }
        }

    }
}
