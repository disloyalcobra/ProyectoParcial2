using System.ComponentModel.DataAnnotations;

namespace ProyectoParcial2.Data.Entities
{
    public class Disease
    {
        public int Id {  get; set; }
        [Required]
        [Display(Name = "Enfermedad")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? DiseaseName { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? DiseaseDescription { get; set; }
        [Required]
        public ICollection<PatientDisease>? PatientDiseases { get; set; }
        public ICollection<Treatment>? Treatments { get; set; }
    }
}
