using System.ComponentModel.DataAnnotations;
using PawConnect.Domain.Entities;

namespace PawConnect.Api.API.Adoptions.RequestObject
{
    public class UpdateAdoptionStatusRequest
    {
        [Required]
        public AdoptionStatus Status { get; set; }
    }
}
