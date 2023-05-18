using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [StringLength(20,ErrorMessage ="First name must be between 2 and 20",MinimumLength =2)]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
