namespace Domain.Models {
    public record Carucior{
        public Stare.iStare stare { get; private init; }
        public List<Produs> listaProduse { get; private init; }
        public Carucior(string idCarucior, Stare.iStare stare)
        {
            this.stare=stare;
            this.listaProduse=listaProduse;
        }
    }
}   