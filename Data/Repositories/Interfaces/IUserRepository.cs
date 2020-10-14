﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> GetDefaultUserId();
    }
}
