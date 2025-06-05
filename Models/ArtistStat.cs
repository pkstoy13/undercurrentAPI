namespace undercurrentAPI.Models
{
public class ArtistStat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime SnapshotDate { get; set; }

        public int? Followers { get; set; }
        public int? MonthlyListeners { get; set; }
        public int? Views { get; set; }
        public int? Likes { get; set; }
        public int? Comments { get; set; }

        public Guid PlatformAccountId { get; set; }
        public PlatformAccount PlatformAccount { get; set; } = null!;
    }

}