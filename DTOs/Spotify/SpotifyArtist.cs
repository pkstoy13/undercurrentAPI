namespace undercurrentAPI.DTOs.Spotify
{
    public class SpotifyArtist
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public List<string>? Genres { get; set; }
        public int? Popularity { get; set; }
        public Dictionary<string, string>? ExternalUrls { get; set; }
    }
}
