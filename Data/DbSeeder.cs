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
                    CreatedAt = DateTime.UtcNow,
                    PlatformAccounts = new List<PlatformAccount>
                    {
                        new PlatformAccount
                        {
                            Platform = "Spotify",
                            ExternalId = "spotify-echo-drift",
                            ProfileUrl = "https://spotify.com/echodrift",
                            Stats = new List<ArtistStat>
                            {
                                new ArtistStat
                                {
                                    SnapshotDate = DateTime.UtcNow,
                                    Followers = 2000,
                                    MonthlyListeners = 15000,
                                    Views = 100000,
                                    Likes = 3500,
                                    Comments = 250
                                }
                            },
                            Tracks = new List<Track>
                            {
                                new Track
                                {
                                    Title = "Midnight Run",
                                    ReleaseDate = DateTime.UtcNow.AddMonths(-3),
                                    PlayCount = 50000,
                                    LikeCount = 1200,
                                    CommentCount = 300,
                                    TrackUrl = "https://spotify.com/track/midnight-run",
                                    IsTopTrack = true
                                },
                                new Track
                                {
                                    Title = "Silent Echo",
                                    ReleaseDate = DateTime.UtcNow.AddMonths(-1),
                                    PlayCount = 25000,
                                    LikeCount = 800,
                                    CommentCount = 150,
                                    TrackUrl = "https://spotify.com/track/silent-echo",
                                    IsTopTrack = false
                                }
                            }
                        }
                    },
                    DiscoveryScores = new List<DiscoveryScore>
                    {
                        new DiscoveryScore
                        {
                            ScoreDate = DateTime.UtcNow,
                            EngagementScore = 78.5,
                            GrowthScore = 65.2,
                            UndergroundScore = 89.3
                        }
                    }
                },
                new Artist
                {
                    Name = "Neon Pulse",
                    Genre = "Synthwave",
                    Country = "UK",
                    CreatedAt = DateTime.UtcNow,
                    PlatformAccounts = new List<PlatformAccount>
                    {
                        new PlatformAccount
                        {
                            Platform = "YouTube",
                            ExternalId = "yt-neon-pulse",
                            ProfileUrl = "https://youtube.com/neonpulse",
                            Stats = new List<ArtistStat>
                            {
                                new ArtistStat
                                {
                                    SnapshotDate = DateTime.UtcNow,
                                    Followers = 10000,
                                    MonthlyListeners = 20000,
                                    Views = 300000,
                                    Likes = 5000,
                                    Comments = 600
                                }
                            },
                            Tracks = new List<Track>
                            {
                                new Track
                                {
                                    Title = "Neon Lights",
                                    ReleaseDate = DateTime.UtcNow.AddMonths(-6),
                                    PlayCount = 100000,
                                    LikeCount = 2500,
                                    CommentCount = 500,
                                    TrackUrl = "https://youtube.com/track/neon-lights",
                                    IsTopTrack = true
                                }
                            }
                        }
                    },
                    DiscoveryScores = new List<DiscoveryScore>
                    {
                        new DiscoveryScore
                        {
                            ScoreDate = DateTime.UtcNow,
                            EngagementScore = 84.1,
                            GrowthScore = 72.8,
                            UndergroundScore = 91.7
                        }
                    }
                }
            };

            context.Artists.AddRange(artists);
            context.SaveChanges();
        }
    }
}
