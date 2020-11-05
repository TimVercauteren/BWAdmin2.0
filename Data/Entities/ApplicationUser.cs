using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Client> Clients { get; set; }

        public PersonInfo UserInfo { get; set; }

    }
}
