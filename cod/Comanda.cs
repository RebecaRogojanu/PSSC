using StareCarucior.Domain;

public record Comanda
{
    private string idComanda{get;init;}
    private Carucior carucior{get;set;}
    private Client client{get;set;}

    public Comanda(Carucior carcucior,Client client)
    {
        this.carucior=carcucior;
        this.client=client;
    }
}