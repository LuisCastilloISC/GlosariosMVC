using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Glosarios.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int idUsuario { get; set; }
        [Required(ErrorMessage ="Nombre obligatorio")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="El nombre debe tener entre 3 y 50 caracteres")]
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
        
    }
}
