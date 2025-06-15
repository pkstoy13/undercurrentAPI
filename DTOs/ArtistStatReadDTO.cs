using System.ComponentModel.DataAnnotations;

namespace undercurrentAPI.DTOs
{
    public class ArtistStatReadDTO
    {
        public Guid Id { get; set; }
        public DateTime SnapshotDate { get; set; }
        public int Followers { get; set; }
        public int MonthlyListeners { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
}