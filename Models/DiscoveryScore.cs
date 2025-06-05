namespace undercurrentAPI.Models
{
public class DiscoveryScore
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime ScoreDate { get; set; }

        public double? EngagementScore { get; set; }
        public double? GrowthScore { get; set; }
        public double? UndergroundScore { get; set; }

        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;
    }

}
