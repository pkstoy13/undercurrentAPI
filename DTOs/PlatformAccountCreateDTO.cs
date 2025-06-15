using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class PlatformAccountCreateDTO
    {
        [Required]
        public string Platform { get; set; } = null!;

        [Required]
        public string ExternalId { get; set; } = null!;

        [Required]
        [Url]
        public string ProfileUrl { get; set; } = null!;

        [Required]
        public Guid ArtistId { get; set; }

    }

}