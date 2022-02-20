using Dapper.NetCore6.WebApi.Model;

namespace Dapper.NetCore6.WebApi.Data.Service
{
    public interface IEmpleadoRepositorio
    {
        Task<IEnumerable<EmpleadoEntidad>> ListarAsync();
        Task<EmpleadoEntidad> BuscarAsync(int id);
        Task<IEnumerable<EmpleadoEntidad>> FiltrarAsync(EmpleadoEntidad entidad);
        Task<EmpleadoEntidad> RegistrarAsync(EmpleadoEntidad entidad);
        Task<EmpleadoEntidad> ModificarAsync(EmpleadoEntidad entidad);
        Task<bool> EliminarAsync(int id);
    }
}
