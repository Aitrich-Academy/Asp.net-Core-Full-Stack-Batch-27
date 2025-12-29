using System.ComponentModel.DataAnnotations;

namespace HireMeNow_API.API.JOBSeeker.RequestObjects
{
    public class JobSeekerLoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
