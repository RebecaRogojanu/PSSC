namespace StareCarucior.Domain
{
    public record Produs{
        private string idProdus{get; init;}
        private double cantitate {get; set;}
        public double Cantitate{get=>cantitate;}
        private string denumire {get; set;}
        private string cod_produs {get; set;} 
        private double pret {get; set;}
        public double Pret{get=>pret;}

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