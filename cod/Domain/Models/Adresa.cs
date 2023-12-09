namespace Domain.Models{
    public record Adresa
    {
        public string strada { get; private init; }
        public string oras { get; private init; }
        public Adresa(string strada, string oras)
        {
            this.strada=strada;
            this.oras=oras;
        }
    }
}