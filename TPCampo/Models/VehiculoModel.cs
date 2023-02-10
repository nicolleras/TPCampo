using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class VehiculoModel
    {
        public int IdVehiculo { get; set; }
        [Required(ErrorMessage = "El campo Marca es obligatorio")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "El campo Modelo es obligatorio")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "El campo Imagen es obligatorio")]
        public string? Imagen { get; set; }
        [Required(ErrorMessage = "El campo PrecioPorDia es obligatorio")]
        public float? PrecioPorDia { get; set; }
        [Required(ErrorMessage = "El campo CapacidadPasajeros es obligatorio")]
        public string? CapacidadPasajeros { get; set; }
        [Required(ErrorMessage = "El campo CapacidadEquipaje es obligatorio")]
        public string? CapacidadEquipaje { get; set; }
        [Required(ErrorMessage = "El campo TipoCaja es obligatorio")]
        public string? TipoCaja { get; set; }
        [Required(ErrorMessage = "El campo CantidadDePuertas es obligatorio")]
        public int? CantidadDePuertas { get; set; }
        [Required(ErrorMessage = "El campo AireAcondicionado es obligatorio")]
        public string? AireAcondicionado { get; set; }
        [Required(ErrorMessage = "El campo TipoDeCobertura es obligatorio")]
        public string? TipoDeCobertura { get; set; }
        [Required(ErrorMessage = "El campo KmHabilitado es obligatorio")]
        public int? KmHabilitado { get; set; }
        [Required(ErrorMessage = "El campo IdEmpresaProveedora es obligatorio")]
        public int? IdEmpresaProveedora { get; set; }

    }
}
