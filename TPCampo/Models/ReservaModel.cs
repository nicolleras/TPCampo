using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class ReservaModel
    {
        public int IdReserva { get; set; }

        public string? Destino { get; set; }
        public string? FechaInicio { get; set; }
        
        public string? FechaFin { get; set; }
        
        public string? Estado { get; set; }
        
        public float? MontoTotal { get; set; }
        [Required(ErrorMessage = "El campo IdVehiculo es obligatorio")]
        public int? IdVehiculo { get; set; }
        [Required(ErrorMessage = "El campo IdUsuario es obligatorio")]
        public int? IdUsuario { get; set; }

    }
}