namespace Data.Entities
{
    public class PersonInfo : EntityBase
    {
        public string Name { get; set; }
        public string StraatNaam { get; set; }
        public string HuisNummer { get; set; }
        public string BusNummer { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public string BtwNummer { get; set; }

        public string UserId { get; set; }
    }
}