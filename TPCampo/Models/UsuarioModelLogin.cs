using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class UsuarioModelLogin
    {
        public int IdUsuario { get; set; }
       
        public string? Nombre { get; set; }
      
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string? Contraseña { get; set; }
        
        public string? Rol { get; set; }
        
        public string? FechaNacimiento { get; set; }
        
        public string? TipoDocumento { get; set; }
     
        public int? Dni { get; set; }
        
        public int? Telefono { get; set; }

    }
}
