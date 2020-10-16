using System.Collections.Generic;
using AutoMapper;
using Data.Entities;
using Models.Read;

namespace BWAdmin2._0.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, Models.Post.ClientDto>().ReverseMap();
            CreateMap<Client, ClientDetailDto>();

            CreateMap<Invoice, InvoiceDto>().ReverseMap();

            CreateMap<Offer, OfferDto>().ReverseMap();

            CreateMap<WorkItem, WorkItemDto>().ReverseMap();

            CreateMap<PersonInfo, Models.Post.PersonInfoDto>().ReverseMap();
        }
    }
}
