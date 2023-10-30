namespace StareCarucior.Domain
{
    public record Carucior{
        private Stare.iStare stare{get; init;}
        private List<Produs> listaProduse{get; init;}
        public List<Produs> ListaProdus{get => listaProduse;}
        public Carucior(string idCarucior, Stare.iStare stare)
        {
            this.stare=stare;
            this.listaProduse=listaProduse;
        }
    }
}   