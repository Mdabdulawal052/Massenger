using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(15,MinimumLength = 6,ErrorMessage ="You must specify password into 15 to 6 character")]
        public string Password { get; set; }
    }
}
