using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProyectoParcial2.Data.Entities
{
    public class User:IdentityUser
    {
        [Required]
        [Display(Name = "Nombre(s)")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]

        public string? LastName { get; set; }
        [Required]
        [Display(Name = "Número celular")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]

        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }
    }
}
