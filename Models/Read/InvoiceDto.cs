using System;
using System.Collections.Generic;

namespace Models.Read
{
    public class InvoiceDto : IDto
    {
        public int Year { get; set; }
        public int NumberOfInvoiceInYear { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid OfferId { get; set; }
        public Guid ClientId { get; set; }
        public IEnumerable<WorkItemDto> ExtraWorkItem { get; set; }
        public string FileName { get; set; }
    }
}
