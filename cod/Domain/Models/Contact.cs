namespace Domain.Models {
    public record Contact
    {
        public string telefon { get; private init; }
        public string email { get; private init; }
        public Contact(string telefon,string email)
        {
            this.telefon=telefon;
            this.email=email;
        }
    }
}