using System;
using System.Collections.Generic;
using System.Text;
using Models.Post;

namespace Models.Read
{
    public class ClientDetailDto : IDto
    {
        public int ClientReference { get; set; }
        public string AccountNumber { get; set; }
        public PersonInfoDto Info { get; set; }
        public IEnumerable<OfferDto> Offers { get; set; }
        public IEnumerable<InvoiceDto> Invoices { get; set; }

    }
}
