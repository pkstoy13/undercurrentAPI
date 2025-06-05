namespace undercurrentAPI.Models
{
public class PlatformAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Platform { get; set; } = string.Empty;
        public string ExternalId { get; set; } = string.Empty;
        public string? ProfileUrl { get; set; }

        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;

        public ICollection<ArtistStat> Stats { get; set; } = new List<ArtistStat>();
        public ICollection<Track> Tracks { get; set; } = new List<Track>();
    }
}
