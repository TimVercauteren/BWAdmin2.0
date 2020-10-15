using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class InfoRepository : Repository<PersonInfo>, IInfoRepository
    {
        public InfoRepository(BwAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
