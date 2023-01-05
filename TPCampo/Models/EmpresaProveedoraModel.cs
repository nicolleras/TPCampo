using System.ComponentModel.DataAnnotations;

namespace TPCampo.Models
{
    public class EmpresaProveedoraModel
    {
        public int IdEmpresaProveedora { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Logo es obligatorio")]
        public string? Logo { get; set; }
        [Required(ErrorMessage = "El campo Calificacion Promedio es obligatorio")]
        public string? CalificacionPromedio { get; set; }

    }
}
