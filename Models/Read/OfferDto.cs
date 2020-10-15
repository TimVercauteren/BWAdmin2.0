using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Read
{
    public class OfferDto : IDto
    {
        public string OfferNumber { get; set; }
        public DateTime ExperationDate { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public bool IsDeleted { get; set; }
        public decimal VatPercentage { get; set; }
        public decimal PrePaid { get; set; }
        public IEnumerable<WorkItemDto> WorkItems { get; set; }
        public Guid ClientId { get; set; }
        public Guid InvoiceId { get; set; }

        public decimal CalculateTotalPrice()
        {
            var price = 0m;
            this.WorkItems.ToList().ForEach(x => price += x.BrutoPrijs);

            return price;
        }
    }
}
