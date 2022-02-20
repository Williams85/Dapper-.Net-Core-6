using Dapper.NetCore6.WebApi.Data.Service;
using Dapper.NetCore6.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.NetCore6.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        readonly IProductoRepositorio _productoRepositorio;
        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        [HttpGet("GetAllProductAsync")]
        public async Task<IEnumerable<ProductoEntidad>> Listar()
        {
            return await _productoRepositorio.ListarAsync();
        }

        [HttpGet("GetbyIdProductAsync/{id}")]
        public async Task<ProductoEntidad> Buscar(int id)
        {
            return await _productoRepositorio.BuscarAsync(id);
        }

        [HttpPost("GetFilterProductAsync")]
        public async Task<IEnumerable<ProductoEntidad>> Filtrar([FromBody] ProductoEntidad entidad)
        {
            return await _productoRepositorio.FiltrarAsync(entidad);
        }

        [HttpPost("InsertProductAsync")]
        public async Task<ProductoEntidad> Registrar([FromBody] ProductoEntidad entidad)
        {
            return await _productoRepositorio.RegistrarAsync(entidad);
        }

        [HttpPut("UpdateProductAsync")]
        public async Task<ProductoEntidad> Modificar([FromBody] ProductoEntidad entidad)
        {
            return await _productoRepositorio.ModificarAsync(entidad);
        }

        [HttpDelete("DeleteProductAsync/{id}")]
        public async Task<bool> Eliminar(int id)
        {
            return await _productoRepositorio.EliminarAsync(id);
        }

    }
}
