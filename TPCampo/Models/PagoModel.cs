using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class PagoModel
    {
        public int IdPago { get; set; }

        public float? MontoFinal { get; set; }

        public string? Estado { get; set; }

        public string? ServicioPago { get; set; }

        public string? MedioPago { get; set; }
        public int? UltimosCuatro { get; set; }
        public int? Cuotas { get; set; }
        public int? CodigoBarras { get; set; }
        public int? Cvu { get; set; }

        public int? IdReserva { get; set; }
    }
}