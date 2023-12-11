namespace Domain.Models {
public record Comanda {
        public string idComanda { get; private init; }  
        public Carucior carucior { get; private set; }
        public Client client { get; private set; }
        public double total { get; private set; }

        public Comanda(Carucior carucior,Client client)
        {
            this.carucior=carucior;
            this.client=client;
        }
        public void calcTotal()
        {
            double total_=0;
            foreach(var item in carucior.listaProduse)
            {
                total_+=item.cantitate * item.pret;
            }
            this.total=total_;
        }
    }
}