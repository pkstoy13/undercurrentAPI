using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class TrackUpdateDTO
    {
        
        public string Title { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public int PlayCount { get; set; }

        public int LikeCount { get; set; }

        public int CommentCount { get; set; }

        [Url]
        public string? TrackUrl { get; set; }

        public bool IsTopTrack { get; set; }
        
    }
    
}