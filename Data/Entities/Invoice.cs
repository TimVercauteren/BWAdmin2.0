using Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Invoice : EntityBase, IDocument
    {
        public int Year { get; set; }
        public int NumberOfInvoiceInYear { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid OfferId { get; set; }
        public Offer Offer { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public IEnumerable<WorkItem> ExtraWorkItem { get; set; }
        public string FileName { get; set; }
    }
}
