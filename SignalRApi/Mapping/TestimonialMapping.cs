using AutoMapper;
using SignalR.DtoLayer.TestimionalDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimional, ResultTestimionalDto>().ReverseMap();
            CreateMap<SocialMedia, CreateTestimionalDto>().ReverseMap();
            CreateMap<SocialMedia, GetTestimionalDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateTestimionalDto>().ReverseMap();
        }
    }
}
