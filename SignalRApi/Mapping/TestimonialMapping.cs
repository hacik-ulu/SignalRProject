using AutoMapper;
using SignalR.DtoLayer.TestimionalDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<SocialMedia, CreateTestimonialDto>().ReverseMap();
            CreateMap<SocialMedia, GetTestimonialDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateTestimonialDto>().ReverseMap();
        }
    }
}
