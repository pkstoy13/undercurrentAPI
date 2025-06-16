using AutoMapper;
using undercurrentAPI.Models;
using undercurrentAPI.DTOs;
using undercurrentAPI.DTOs.Spotify;

namespace undercurrentAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Artist
            CreateMap<Artist, ArtistReadDTO>();
            CreateMap<ArtistCreateDTO, Artist>();
            CreateMap<ArtistUpdateDTO, Artist>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            //Platform Account
            CreateMap<PlatformAccount, PlatformAccountReadDTO>();
            CreateMap<PlatformAccountCreateDTO, PlatformAccount>();
            CreateMap<PlatformAccountUpdateDTO, PlatformAccount>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            //Artist Stats
            CreateMap<ArtistStat, ArtistStatReadDTO>();
            CreateMap<ArtistStatCreateDTO, ArtistStat>();
            CreateMap<ArtistStatUpdateDTO, ArtistStat>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            //Track
            CreateMap<Track, TrackReadDTO>();
            CreateMap<TrackCreateDTO, Track>();
            CreateMap<TrackUpdateDTO, Track>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            //Discovery Score
            CreateMap<DiscoveryScore, DiscoveryScoreReadDTO>();
            CreateMap<DiscoveryScoreCreateDTO, DiscoveryScore>();
            CreateMap<DiscoveryScoreUpdateDTO, DiscoveryScore>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


        }
    }

    public class SpotifyMapper
    {
        public static (Artist artist, PlatformAccount platformAccount) MapSpotifyArtistToModels(SpotifyArtist spArtist)
        {
            var artist = new Artist
            {
                Name = spArtist.Name,
                Genre = spArtist.Genres != null && spArtist.Genres.Any() ? spArtist.Genres[0] : "Unknown",
                Country = null, // Spotify doesn’t return country directly here
                CreatedAt = DateTime.UtcNow,
            };

            var platformAccount = new PlatformAccount
            {
                Platform = "Spotify",
                ExternalId = spArtist.Id,
                ProfileUrl = spArtist.ExternalUrls != null && spArtist.ExternalUrls.ContainsKey("spotify")
                    ? spArtist.ExternalUrls["spotify"]
                    : null,
                Artist = artist
            };

            return (artist, platformAccount);
        }

        public static ArtistStat MapToArtistStat(SpotifyArtist spArtist, Guid platformAccountId)
            {
                return new ArtistStat
                {
                    SnapshotDate = DateTime.UtcNow,
                    Followers = null, // until you call full /artists/{id} endpoint
                    MonthlyListeners = null, // Spotify doesn't give this publicly
                    Likes = null,
                    Comments = null,
                    Views = null,
                    PlatformAccountId = platformAccountId
                };
            }

    }

}
