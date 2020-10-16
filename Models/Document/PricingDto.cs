using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Document
{
    public class PricingDto
    {
        public string VatPercentageString { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal VatPrice { get; set; }
        public decimal BrutoPrice { get; set; }
        public decimal TotalPriceMinusPrepaid { get; set; }
        public decimal PrepaidPrice { get; set; }
    }
}
