namespace StareCarucior.Domain
{
    public record Carucior{
        private string idCarucior{get;init;}
        public string IdCarucior{get => idCarucior;}
        private List<Produs>listaProduse{get;set;}
        public List<Produs>ListaProduse{set => listaProduse = value;}

        public Carucior(string idCarucior)
        {
            this.idCarucior=idCarucior;
        }
        public Carucior(string idCarucior,List<Produs>listaProduse)
        {
            this.idCarucior=idCarucior;
            this.listaProduse=listaProduse;
        }
    }
}   