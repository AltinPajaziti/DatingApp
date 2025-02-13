using API.Dtos;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUsser, MemberDto>()
                .ForMember(
                    d => d.Age,
                    o => o.MapFrom(s => s.DateOfBirth.CalculateAge()))
                .ForMember(
                d=>d.PhotoUrl , o=>o.MapFrom(s =>s.Photos.FirstOrDefault(x=>x.Ismain)!.Url) );
            CreateMap<Photo , PhotoDto>();
        }
    }
}
