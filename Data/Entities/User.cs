using Data.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Data.Entities
{
    public class User : EntityBase, IDeletable
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        // Many's
        public IEnumerable<Client> Clients { get; set; }

        // FK
        public Guid PersonInfoId { get; set; }
        public PersonInfo UserInfo { get; set; }

    }
}
