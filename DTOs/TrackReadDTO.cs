using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class TrackReadDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public int PlayCount { get; set; }

        public int LikeCount { get; set; }

        public int CommentCount { get; set; }

        public string? TrackUrl { get; set; }

        public bool IsTopTrack { get; set; }

        public Guid PlatformAccountId { get; set; }
        
    }
    
}