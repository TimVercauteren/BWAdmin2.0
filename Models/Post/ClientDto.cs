using System;

namespace Models.Post

{
    public class ClientDto : IDto
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public Guid InfoId { get; set; }
        public PersonInfoDto Info { get; set; }
        public string ClientReference { get; set; }
    }
}
