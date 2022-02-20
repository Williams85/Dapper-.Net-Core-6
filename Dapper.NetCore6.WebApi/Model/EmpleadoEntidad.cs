namespace Dapper.NetCore6.WebApi.Model
{
    public class EmpleadoEntidad
    {
        public int Codi_Empleado { get; set; }
        public string Nombres_Empleado { get; set; } = string.Empty;
        public string Apellidos_Empleado { get; set; } = string.Empty;
        public string Direccion_Empleado { get; set; } = string.Empty;
        public string Telefono_Empleado { get; set; } = string.Empty;
        public string Email_Empleado { get; set; } = string.Empty;
        public DateTime FechaNacimiento_Empleado { get; set; }
        public double Sueldo_Empleado { get; set; }
        public bool Activo { get; set; } 


    }
}
