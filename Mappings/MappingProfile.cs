using AutoMapper;
using undercurrentAPI.Models;
using undercurrentAPI.DTOs;

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
}
