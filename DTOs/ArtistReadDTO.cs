namespace undercurrentAPI.DTOs
{
    public class ArtistReadDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Genre { get; set; }
        public string? Country { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
