using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Entities
{
    public class Offer : EntityBase, IDocument, IDeletable
    {
        public string OfferNumber { get; set; }
        public DateTime ExperationDate { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public bool IsDeleted { get; set; }
        public decimal VatPercentage { get; set; }
        public decimal PrePaid { get; set; }


        // Manys
        public IEnumerable<WorkItem> WorkItems { get; set; }

        // FK
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public decimal CalculateTotalPrice()
        {
            decimal price = 0m;
            this.WorkItems.ToList().ForEach(x => price += x.BrutoPrijs);

                return price;
        }
    }
}
