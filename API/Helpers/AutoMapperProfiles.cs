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
            CreateMap<MemberUpdateDto, AppUsser>();
            CreateMap<RegisterDto, AppUsser>();
            CreateMap<string , DateOnly>().ConstructUsing(s => DateOnly.Parse(s));
            CreateMap<Messages, MessageDto>()
            .ForMember(d => d.SenderPhotoUrl,
                o => o.MapFrom(s => s.Sender.Photos.FirstOrDefault(x => x.Ismain)!.Url))
            .ForMember(d => d.RecipientPhotoUrl,
                o => o.MapFrom(s => s.Recipient.Photos.FirstOrDefault(x => x.Ismain)!.Url));
        }
    }
}
