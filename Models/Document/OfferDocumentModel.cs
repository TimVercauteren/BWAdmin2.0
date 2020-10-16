using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Models.Post;
using Models.Read;

namespace Models.Document
{
    public class OfferDocumentModel
    {
        public string OfferNumber { get; set; }
        public string Date { get; set; }
        public string ExpirationDate { get; set; }
        public string FileName { get; set; }
        public decimal VatPercentage { get; set; }
        public decimal PrePaid { get; set; }
        public ClientDto ClientInfo { get; set; }
        public IEnumerable<WorkItemDto> WorkItems { get; set; }
        public PersonInfoDto UserInfo { get; set; }
        public PricingDto Pricing { get; set; }
    }

    public static class OfferteModelsForTesting
    {
        public static OfferDocumentModel TestModel()
        {
            return new OfferDocumentModel
            {
                Pricing = new PricingDto()
                {
                    BrutoPrice = 2000m,
                    VatPrice = 120m,
                    VatPercentageString = "BTW 6%",
                    TotalPrice = 2120m,
                    TotalPriceMinusPrepaid = 1100m,
                    PrepaidPrice = 1100m
                },
                UserInfo = new PersonInfoDto()
                {
                    BtwNummer = "BE 0636.881.313",
                    StraatNaam = "Durmen",
                    HuisNummer = "119",
                    TelefoonNummer = "0494834979",
                    BankNummer = "BE58 7360 1926 5779",
                    BusNummer = "",
                    Email = "brentwiels@outlook.com",
                    Gemeente = "Zele",
                    Postcode = "9240"
                },
                ClientInfo = new ClientDto()
                {
                    AccountNumber = "BE1001547052548",
                    ClientReference = "1",
                    Info = new PersonInfoDto()
                    {
                        BtwNummer = "BE00000-BTW",
                        BusNummer = "W4",
                        Email = "ACMainil@gmail.com",
                        Gemeente = "Zele",
                        HuisNummer = "1",
                        Name = "Anne-Celine Mainil",
                        Postcode = "9240",
                        StraatNaam = "Minister E. Rubbenslaan",
                        TelefoonNummer = "0498836512"
                    },
                },
                Date = DateTime.Today.Date.ToShortDateString(),
                ExpirationDate = DateTime.Today.AddDays(14).ToShortDateString(),
                FileName = "testOfferte",
                PrePaid = 1000,
                OfferNumber = "2020-1",
                VatPercentage = 0.06m,
                WorkItems = new List<WorkItemDto>
                {
                    new WorkItemDto()
                    {
                        Description = "Test werklijn 1, zoveel gezever enzo",
                        MarginPercentage = 0.15m,
                        NettoPrice = 300m
                    },
                    new WorkItemDto()
                    {
                        Description = "Test werklijn 2, zoveel gezever enzo",
                        MarginPercentage = 0.15m,
                        NettoPrice = 740m
                    },
                    new WorkItemDto()
                    {
                        Description = "Test werklijn 3, zoveel gezever enzo",
                        MarginPercentage = 0.10m,
                        NettoPrice = 100m
                    },
                    new WorkItemDto()
                    {
                        Description = "Test werklijn 4, zoveel gezever enzo",
                        MarginPercentage = 0.05m,
                        NettoPrice = 200m
                    },
                    new WorkItemDto()
                    {
                        Description = "Test werklijn 5, zoveel gezever enzo",
                        MarginPercentage = 0.15m,
                        NettoPrice = 10m
                    }
                }
            };
        }
    }
}
