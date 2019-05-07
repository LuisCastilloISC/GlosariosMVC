using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Glosarios.Models
{
    public class Usuario : IdentityUser
    {
        [Key]
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "Nombre obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 50 caracteres")]
        public string ApellidoMaterno { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 50 caracteres")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Nickname Obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Password obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Password { get; set; }
        public bool status { get; set; }
        [Required(ErrorMessage = "Correo")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ingrese correo valido")]
        public string Correo { get; set; }
    }
}
