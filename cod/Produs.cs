namespace StareCarucior.Domain
{
    public record Produs{
        private double cantitate {get; init;}
        private string denumire {get; init;}
        private string cod_produs {get; init;} 
        private double pret{get;init;}

        public Produs(double cantitate,string denumire)
        {
            this.cantitate=cantitate;
            this.denumire=denumire;
        }
    }
}   