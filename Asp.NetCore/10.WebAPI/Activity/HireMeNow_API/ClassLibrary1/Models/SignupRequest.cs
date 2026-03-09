using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Enum;

namespace Domain.Models
{
    public class SignupRequest
    {
        [Key]
        [Required]
        
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Status Status { get; set; }
    }
}
