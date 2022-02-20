using Dapper.NetCore6.WebApi.Data.Service;
using Dapper.NetCore6.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.NetCore6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepositorio _empleadoRepositorio;
        public EmpleadoController(IEmpleadoRepositorio empleadoRepositorio)
        {
            _empleadoRepositorio = empleadoRepositorio;
        }

        [HttpGet("GetAllEmployeeAsync")]
        public async Task<Object> Listar()
        {
            return await _empleadoRepositorio.ListarAsync();
        }

        [HttpGet("GetbyIdEmployeeAsync/{id}")]
        public async Task<Object> Buscar(int id)
        {
            return await _empleadoRepositorio.BuscarAsync(id);
        }

        [HttpPost("GetFilterEmployeeAsync")]
        public async Task<Object> Filtrar([FromBody] EmpleadoEntidad entidad)
        {
            return await _empleadoRepositorio.FiltrarAsync(entidad);
        }

        [HttpPost("InsertEmployeeAsync")]
        public async Task<Object> Registrar([FromBody] EmpleadoEntidad entidad)
        {
            return await _empleadoRepositorio.RegistrarAsync(entidad);
        }

        [HttpPut("UpdateEmployeeAsync")]
        public async Task<Object> Modificar([FromBody] EmpleadoEntidad entidad)
        {
            return await _empleadoRepositorio.ModificarAsync(entidad);
        }

        [HttpGet("DeleteEmployeeAsync/{id}")]
        public async Task<Object> Eliminar(int id)
        {
            return await _empleadoRepositorio.EliminarAsync(id);
        }


    }
}
