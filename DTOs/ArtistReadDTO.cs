namespace undercurrentAPI.DTOs
{
    public class ArtistReadDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Genre { get; set; }
        public required string Country { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
