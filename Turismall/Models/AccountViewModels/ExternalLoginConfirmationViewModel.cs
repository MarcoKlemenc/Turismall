using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turismall.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Debe introducir un correo")]
        [EmailAddress(ErrorMessage = "El correo introducido no es válido")]
        public string Email { get; set; }
    }
}
