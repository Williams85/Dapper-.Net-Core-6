using Dapper.NetCore6.WebApi.Model;

namespace Dapper.NetCore6.WebApi.Data.Service
{
    public interface IProductoRepositorio
    {
        Task<IEnumerable<ProductoEntidad>> ListarAsync();
        Task<ProductoEntidad> BuscarAsync(int id);
        Task<IEnumerable<ProductoEntidad>> FiltrarAsync(ProductoEntidad entidad);
        Task<ProductoEntidad> RegistrarAsync(ProductoEntidad entidad);
        Task<ProductoEntidad> ModificarAsync(ProductoEntidad entidad);
        Task<bool> EliminarAsync(int id);
    }
}
