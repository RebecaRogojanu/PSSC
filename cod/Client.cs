namespace StareCarucior.Domain
{
    public record Client{
        private string idClient {get; init;}
        public string IdClient{get => idClient;}
        private string nume {get;set;}
        public string Nume{get => nume;}
        private Adresa adresa{get; set;}
        private Contact contact{get; set;}

        public Client(string idClient, string nume, Adresa adresa, Contact contact)
        {
            this.idClient = idClient;
            this.nume = nume;
            this.adresa = adresa;
            this.contact = contact;
        }
    }
}