using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class ArtistUpdateDTO
    {
        
        [StringLength(100)]
        public string? Name { get; set; }
        
        [StringLength(50)]
        public string? Genre { get; set; }
        
        [StringLength(50)]
        public string? Country { get; set; }
    }
}
