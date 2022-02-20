namespace Dapper.NetCore6.WebApi.Model
{
    public class ProductoEntidad
    {
        public int Codi_Producto { get; set; }
        public string Descripcion_Producto { get; set; } = String.Empty;
        public int Cantidad_Producto { get; set; }
        public decimal Precio_Producto { get; set; }
        public bool Activo { get; set; }

    }
}
