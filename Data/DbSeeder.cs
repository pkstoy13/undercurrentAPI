using undercurrentAPI.Models;

namespace undercurrentAPI.Data
{
public static class DbSeeder
    {
        public static void Seed(ArtistDbContext context)
        {
            if (context.Artists.Any()) return; // prevent duplicate seeding

            var artists = new List<Artist>
            {
                new Artist
                {
                    Name = "Echo Drift",
                    Genre = "Indie Rock",
                    Country = "US",
                    CreatedAt = DateTime.UtcNow
                },
                new Artist
                {
                    Name = "Neon Pulse",
                    Genre = "Synthwave",
                    Country = "UK",
                    CreatedAt = DateTime.UtcNow
                }
            };

            context.Artists.AddRange(artists);
            context.SaveChanges();
        }
    }
}
