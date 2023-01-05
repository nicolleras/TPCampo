using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class BuscarModel
    {

        public string? Destino { get; set; }
        public string? FechaInicio { get; set; }

        public string? FechaFin { get; set; }  

    }
}