using AutoMapper;
using BWAdminUi.Server.Data;
using BWAdminUi.Server.Repositories.Abstracts;
using BWAdminUi.Server.Repositories.Interfaces;
using Data.Entities;

namespace BWAdminUi.Server.Repositories
{
    public class InfoRepository : Repository<PersonInfo>, IInfoRepository
    {
        public InfoRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
