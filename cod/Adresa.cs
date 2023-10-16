namespace StareCarucior.Domain{
    public record Adresa
    {
        public string strada { get; set; }
        public string oras { get; set; }
        public Adresa(string strada,string oras)
        {
            this.strada=strada;
            this.oras=oras;
        }
    }
}