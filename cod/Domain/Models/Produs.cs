namespace Domain.Models {
    public record Produs{
        public string idProdus { get; private init; }
        public double cantitate { get; private set; }
        public string denumire { get; private set; } 
        public string cod_produs { get; private set; } 
        public double pret { get; private set; }

        public Produs(string idProdus, string cod_produs, string denumire, double pret, double cantitate)
        {
            this.idProdus = idProdus;
            this.cod_produs = cod_produs;
            this.denumire = denumire;
            this.pret = pret;
            this.cantitate = cantitate;
        }
    }
}   