namespace StareCarucior.Domain{
    public record Adresa
    {
        public string strada { get; init; }
        public string oras { get; init; }
        public Adresa(string strada,string oras)
        {
            this.strada=strada;
            this.oras=oras;
        }
    }
}