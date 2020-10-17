using AutoMapper;
using Data.Entities;
using Models.Read;

namespace BWAdminUi.Server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<global::Data.Entities.Client, global::Models.Post.ClientDto>().ReverseMap();
            CreateMap<global::Data.Entities.Client, ClientDetailDto>();

            CreateMap<Invoice, InvoiceDto>().ReverseMap();

            CreateMap<Offer, OfferDto>().ReverseMap();

            CreateMap<WorkItem, WorkItemDto>().ReverseMap();

            CreateMap<PersonInfo, global::Models.Post.PersonInfoDto>().ReverseMap();
        }
    }
}
