using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turismall.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Debe introducir un correo")]
        [EmailAddress(ErrorMessage="El correo introducido no es válido")]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe introducir una constraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
