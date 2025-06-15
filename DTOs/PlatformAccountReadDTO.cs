namespace undercurrentAPI.DTOs
{
    public class PlatformAccountReadDTO
    {
        public Guid Id { get; set; }
        public string Platform { get; set; } = null!;
        public string ExternalId { get; set; } = null!;
        public string ProfileUrl { get; set; } = null!;
        public Guid ArtistId { get; set; }
        
    }
    
}