using System.ComponentModel.DataAnnotations;

namespace ProyectoParcial2.Data.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Fecha de caducidad")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        [Required]
        [Display(Name = "Cantidad disponible")]
        public int Quantity { get; set; }
        [Required]
        public ICollection<Treatment>? Treatments { get; set; }

    }
}
