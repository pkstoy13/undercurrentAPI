using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class PlatformAccountUpdateDTO
    {
        [StringLength(100)]
        public string? Platform { get; set; }

        [StringLength(100)]
        public string? ExternalId { get; set; }

        [Url]
        public string? ProfileUrl { get; set; }

    }

}