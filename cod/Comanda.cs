using StareCarucior.Domain;

public record Comanda
{
    private string idComanda{get;init;}
    private Carucior carucior{get;set;}
    private Client client{get;set;}

    private double total{get;set;}

    public Comanda(Carucior carcucior,Client client)
    {
        this.carucior=carcucior;
        this.client=client;
    }
    public void calcTotal()
    {
        double total_=0;
        foreach(var item in carucior.ListaProdus)
        {
            total_+=item.Cantitate * item.Pret;
        }
         this.total=total_;
    }
}