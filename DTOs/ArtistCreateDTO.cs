using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class ArtistCreateDTO
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }
        [Required]
        [StringLength(50)]
        public required string Genre { get; set; }
        [Required]
        [StringLength(50)]
        public required string Country { get; set; }
    }
}
