using Microsoft.EntityFrameworkCore;
using undercurrentAPI.Models;
namespace undercurrentAPI.Data
{
public class ArtistDbContext : DbContext
{
    public ArtistDbContext(DbContextOptions<ArtistDbContext> options)
        : base(options) { }

    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<PlatformAccount> PlatformAccounts => Set<PlatformAccount>();
    public DbSet<ArtistStat> ArtistStats => Set<ArtistStat>();
    public DbSet<Track> Tracks => Set<Track>();
    public DbSet<DiscoveryScore> DiscoveryScores => Set<DiscoveryScore>();
}

}