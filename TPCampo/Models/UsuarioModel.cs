using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string? Contraseña { get; set; }
        [Required(ErrorMessage = "El campo Rol es obligatorio")]

        public string? ConfirmarContraseña { get; set; }
        [Required(ErrorMessage = "El campo Rol es obligatorio")]
        public string? Rol { get; set; }
        
        public string? FechaNacimiento { get; set; }
        
        public string? TipoDocumento { get; set; }
     
        public int? Dni { get; set; }
        
        public int? Telefono { get; set; }

    }
}
