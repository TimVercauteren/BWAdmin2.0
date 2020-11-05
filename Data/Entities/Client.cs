using Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Client : EntityBase, IDeletable
    {
        public int ClientReference { get; set; }
        public ApplicationUser User { get; set; }
        public PersonInfo Info { get; set; }

        public bool IsDeleted { get; set; }
        public string AccountNumber { get; set; }

        // Many's
        public IEnumerable<Offer> Offers { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }

        // FK
        public string UserId { get; set; }
        public Guid InfoId { get; set; }

    }
}
