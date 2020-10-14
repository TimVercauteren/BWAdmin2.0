using System;

namespace Models.Post

{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public int ClientReference { get; set; }
        public string AccountNumber { get; set; }
        public PersonInfoDto Info { get; set; }
    }
}
