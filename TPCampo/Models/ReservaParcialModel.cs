using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class ReservaParcialModel
    {

        public int IdVehiculo { get; set; }
        public string? Destino { get; set; }

        public string? FechaInicio { get; set; }

        public string? FechaFin { get; set; }
        public float? MontoTotal { get; set; }

    }
}