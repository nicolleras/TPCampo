using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class ModeloReservasVehiculos
    {

        public List<ReservaModel> reservaModel { get; set; }
        public List<VehiculoModel> vehiculosModel{ get; set; }
    }
}