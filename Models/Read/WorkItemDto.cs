using System;

namespace Models.Read
{
    public class WorkItemDto : IDto
    {
        public string Description { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal MarginPercentage { get; set; }
        public Guid OfferId { get; set; }
        public Guid InvoiceId { get; set; }


        public decimal BrutoPrijs => NettoPrice + (NettoPrice * MarginPercentage);
    }
}
