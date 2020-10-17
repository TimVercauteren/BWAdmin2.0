namespace BWAdminUi.Server.Setup
{
    public class BwInfo
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BankAccount { get; set; }
        public string VatNumber { get; set; }
        public static string Section => "Brent";
    }
}
