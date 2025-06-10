using AutoMapper;
using undercurrentAPI.Models;
using undercurrentAPI.DTOs;

namespace undercurrentAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Artist, ArtistReadDTO>();
            CreateMap<ArtistCreateDTO, Artist>();
            CreateMap<ArtistUpdateDTO, Artist>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
