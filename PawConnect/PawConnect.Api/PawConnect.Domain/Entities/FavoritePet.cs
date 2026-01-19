using System.ComponentModel.DataAnnotations.Schema;
using PawConnect.Domain.Entities;

namespace PawConnect.Domain.Entities
{
    public class FavoritePet
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public int PetId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [ForeignKey(nameof(PetId))]
        public Pet? Pet { get; set; }
    }
}
