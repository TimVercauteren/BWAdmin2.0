using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Read
{
    public class WorkItemDto : IDto
    {
        public string Description { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal MarginPercentage { get; set; }

        public decimal BrutoPrijs => NettoPrice + (NettoPrice * MarginPercentage);
    }
}
