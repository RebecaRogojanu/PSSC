namespace Domain.Models {
    public record Client{
        public string idClient { get; private init; }
        public string nume { get; private set; }
        public Adresa adresa { get; private set; }
        public Contact contact { get; private set; }

        public Client(string idClient, string nume, Adresa adresa, Contact contact)
        {
            this.idClient = idClient;
            this.nume = nume;
            this.adresa = adresa;
            this.contact = contact;
        }
    }
}