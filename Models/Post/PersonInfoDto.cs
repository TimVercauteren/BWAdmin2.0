using System;

namespace Models.Post
{
    public class PersonInfoDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StraatNaam { get; set; }
        public string HuisNummer { get; set; }
        public string BusNummer { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public string BtwNummer { get; set; }
        public string BankNummer { get; set; }
    }
}
