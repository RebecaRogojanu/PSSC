namespace StareCarucior.Domain
{
    public record Produs{
        private double cantitate {get; init;}
        private string denumire {get; init;}
        private string cod_produs {get; init;} 
        private double pret {get; init;}

        public Produs(string cod_produs, string denumire, double pret, double cantitate)
        {
            this.cod_produs = cod_produs;
            this.denumire = denumire;
            this.pret = pret;
            this.cantitate = cantitate;
        }
    }
}   