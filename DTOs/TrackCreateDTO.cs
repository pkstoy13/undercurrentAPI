using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class TrackCreateDTO
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int PlayCount { get; set; } = 0;

        public int LikeCount { get; set; } = 0;

        public int CommentCount { get; set; } = 0;

        [Url]
        public string? TrackUrl { get; set; }

        public bool IsTopTrack { get; set; } = false;

        [Required]
        public Guid PlatformAccountId { get; set; }
        
    }
    
}