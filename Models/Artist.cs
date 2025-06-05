namespace undercurrentAPI.Models
{
public class Artist
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? Genre { get; set; }
    public string? Country { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<PlatformAccount> PlatformAccounts { get; set; } = new List<PlatformAccount>();
    public ICollection<DiscoveryScore> DiscoveryScores { get; set; } = new List<DiscoveryScore>();
}

}