using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class DiscoveryScoreReadDTO
    {
        public Guid Id { get; set; }

        public DateTime ScoreDate { get; set; }

        public double EngagementScore { get; set; }

        public double GrowthScore { get; set; }

        public double UndergroundScore { get; set; }

        public Guid ArtistId { get; set; }
        
    }
}