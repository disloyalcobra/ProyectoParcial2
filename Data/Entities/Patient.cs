using System.ComponentModel.DataAnnotations;

namespace ProyectoParcial2.Data.Entities
{
    public class Patient
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre(s)")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]

        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Age { get; set; }
        [Display(Name = "Genero")]
        [MaxLength(50)]
        public string? Gender {  get; set; }
        [Required]
        [Display(Name = "Direccion")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? Adress {  get; set; }
        [Required]
        [Display(Name = "Número celular")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? CellPhone { get; set; }
        [Required]
        public User? User { get; set; }

        public ICollection<PatientDisease>? PatientDiseases { get; set; }

    }
}
