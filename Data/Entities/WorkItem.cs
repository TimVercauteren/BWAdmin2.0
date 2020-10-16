using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class WorkItem : EntityBase
    {
        public string Description { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal MarginPercentage { get; set; }

        [NotMapped]
        public decimal BrutoPrijs => NettoPrice + (NettoPrice * MarginPercentage);

        public Guid OfferId { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
