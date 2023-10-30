namespace StareCarucior.Domain{
    public record Contact
    {
        public string telefon { get; init; }
        public string email { get; init; }
        public Contact(string telefon,string email)
        {
            this.telefon=telefon;
            this.email=email;
        }
    }
}