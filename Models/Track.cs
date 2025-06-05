namespace undercurrentAPI.Models
{
public class Track
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public int? PlayCount { get; set; }
        public int? LikeCount { get; set; }
        public int? CommentCount { get; set; }
        public string? TrackUrl { get; set; }
        public bool IsTopTrack { get; set; }

        public Guid PlatformAccountId { get; set; }
        public PlatformAccount PlatformAccount { get; set; } = null!;
    }
}
