using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class GlobalUser
    {
        public static int? IdUsuario { get; set; }
        public static string? Rol { get; set; }
        public static string? Nombre { get; set; }

    }
}