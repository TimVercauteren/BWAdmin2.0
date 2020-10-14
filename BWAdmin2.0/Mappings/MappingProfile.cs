using AutoMapper;
using Data.Entities;

namespace BWAdmin2._0.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, Models.Post.ClientDto>().ReverseMap();
            CreateMap<PersonInfo, Models.Post.PersonInfoDto>().ReverseMap();
        }
    }
}
