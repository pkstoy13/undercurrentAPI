using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class DiscoveryScoreUpdateDTO
    {
        [Required]
        public DateTime ScoreDate { get; set; }

        [Range(0, 100)]
        public double EngagementScore { get; set; }

        [Range(0, 100)]
        public double GrowthScore { get; set; }

        [Range(0, 100)]
        public double UndergroundScore { get; set; }
        
    }
}