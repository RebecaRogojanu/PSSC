using System.Data;
using System.Security.AccessControl;
using StareCarucior.Domain;

namespace StareCarucior
{
    class Program{
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            List<Stare.Gol> golCarucior = new List<Stare.Gol>();
            List<Stare.Validat> validCarucior = new List<Stare.Validat>();
            List<Stare.Nevalidat> nevalidCarucior = new List<Stare.Nevalidat>();
            List<Stare.Platit> platitCarucior = new List<Stare.Platit>();
            while(true)
            {
                Console.WriteLine("Meniu");
                Console.WriteLine("\n1.Creare carucior nou");
                Console.WriteLine("\n2.Creare carucior nou si adaugare produse in el");
                Console.WriteLine("\n3.Adaugare produse in carucior existent gol");
                Console.WriteLine("\n4.Validare comanda");
                Console.WriteLine("\n5.Plata comanda");
                Console.WriteLine("\n6.Afisare carucioare si starea acestora");
                Console.WriteLine("\n0.Iesire");
                Console.WriteLine("\nOptiunea dorita: ");
                int opt=int.Parse(Console.ReadLine());
                switch(opt)
                {
                    case 1: {
                        Random random = new Random();
                        string randomId=random.Next().ToString();
                        Carucior carucior=new Carucior(randomId);

                        randomId=random.Next().ToString();
                        Console.WriteLine("Introduceti numele: ");
                        string nume=Console.ReadLine();
                        Console.WriteLine("Introduceti orasul: ");
                        string oras=Console.ReadLine();
                        Console.WriteLine("Introduceti strada: ");
                        string strada=Console.ReadLine();
                        Adresa adresa=new Adresa(strada,oras);
                        Client client=new Client(randomId,nume,adresa);
                        
                        UnvalidatedCos unvalidatedCos=new UnvalidatedCos(carucior,client);
                        Stare.Gol golState = new Stare.Gol(new List<UnvalidatedCos> { unvalidatedCos });
                        golCarucior.Add(golState);
                        break;
                    }
                    case 2: {
                        Random random = new Random();
                        string randomId=random.Next().ToString();

                        Console.WriteLine("Introduceti numarul de produse: ");
                        int nr=int.Parse(Console.ReadLine());
                        List<Produs>listaProduse=new List<Produs>();
                        for(int i=0; i<nr; i++)
                        {
                            Console.WriteLine("Introduceti codul produsului: ");
                            string cod=Console.ReadLine();
                            Console.WriteLine("Introduceti denumirea produsului: ");
                            string denumire=Console.ReadLine();
                            Console.WriteLine("Introduceti pretul produsului: ");
                            double pret=double.Parse(Console.ReadLine());
                            Console.WriteLine("Introduceti cantitatea produsului: ");
                            double cantitate=double.Parse(Console.ReadLine());
                            Produs produs=new Produs(cod,denumire,pret,cantitate);
                            listaProduse.Add(produs);
                        }

                        Carucior carucior=new Carucior(randomId,listaProduse);
                        randomId=random.Next().ToString();
                        Console.WriteLine("Introduceti numele: ");
                        string nume=Console.ReadLine();
                        Console.WriteLine("Introduceti orasul: ");
                        string oras=Console.ReadLine();
                        Console.WriteLine("Introduceti strada: ");
                        string strada=Console.ReadLine();
                        Adresa adresa=new Adresa(strada,oras);
                        Client client=new Client(randomId,nume,adresa);
                        
                        UnvalidatedCos unvalidatedCos=new UnvalidatedCos(carucior,client);
                        Stare.Nevalidat nevalidat=new Stare.Nevalidat(new List<UnvalidatedCos>{unvalidatedCos},"asteptare confirmare");
                        nevalidCarucior.Add(nevalidat);
                        break;
                    }
                    case 3: {
                        Console.WriteLine("Lista carucioare goale: ");
                        int index=0;
                        foreach (var golState in golCarucior)
                        {
                            index++;
                            foreach (var unvalidatedCos in golState.listaCos)
                            {     
                                Console.WriteLine("Caruciorul cu numaru: "+index);           
                                Console.WriteLine("\nId cos: " + unvalidatedCos.carucior.IdCarucior);
                                Console.WriteLine("\nId client: " + unvalidatedCos.client.IdClient);
                                Console.WriteLine("\nNume client: " + unvalidatedCos.client.Nume);
                                Console.WriteLine("----------------------------------------------");
                            }
                        }
                        Console.WriteLine("\nSelectati un carucior: ");
                        int optiune=int.Parse(Console.ReadLine());
                        index=0;
                            foreach (var golState in golCarucior)
                            {
                                foreach (var unvalidatedCos in golState.listaCos)
                                {    
                                    index++;
                                    if(index==optiune)
                                    {
                                    Console.WriteLine("Introduceti numarul de produse: ");
                                    int nr=int.Parse(Console.ReadLine());
                                    List<Produs>listaProduse=new List<Produs>();
                                    for(int i=0; i<nr; i++)
                                    {
                                    Console.WriteLine("Introduceti codul produsului: ");
                                    string cod=Console.ReadLine();
                                    Console.WriteLine("Introduceti denumirea produsului: ");
                                    string denumire=Console.ReadLine();
                                    Console.WriteLine("Introduceti pretul produsului: ");
                                    double pret=double.Parse(Console.ReadLine());
                                    Console.WriteLine("Introduceti cantitatea produsului: ");
                                    double cantitate=double.Parse(Console.ReadLine());
                                    Produs produs=new Produs(cod,denumire,pret,cantitate);
                                    listaProduse.Add(produs);
                                    }
                                    unvalidatedCos.carucior.ListaProduse=listaProduse;
                                    Stare.Nevalidat nevalidatState = new Stare.Nevalidat(golState.listaCos, "produsele au fost adaugate");
                                    nevalidCarucior.Add(nevalidatState);
                                    }
                                    else
                                    {
                                    Console.WriteLine("\nNu exista caruciorul cu indexul dorit");
                                    }   
                                }
                            }                   
                        break;
                    }
                    case 4: {
                        break;
                    }
                     case 5: {
                        break;
                    }
                    case 6: {
                        Console.WriteLine("Lista carucioare goale: ");
                        foreach (var golState in golCarucior)
                        {
                            foreach (var unvalidatedCos in golState.listaCos)
                            {                
                                Console.WriteLine("\nId cos: " + unvalidatedCos.carucior.IdCarucior);
                                Console.WriteLine("\nId client: " + unvalidatedCos.client.IdClient);
                                Console.WriteLine("\nNume client: " + unvalidatedCos.client.Nume);
                                Console.WriteLine("----------------------------------------------");
                            }
                        }
                        Console.WriteLine("Lista carucioare nevalide: ");
                        foreach (var nevalidState in nevalidCarucior)
                        {
                            foreach (var unvalidatedCos in nevalidState.listaCos)
                            {                
                                Console.WriteLine("\nId cos: " + unvalidatedCos.carucior.IdCarucior);
                                Console.WriteLine("\nId client: " + unvalidatedCos.client.IdClient);
                                Console.WriteLine("\nNume client: " + unvalidatedCos.client.Nume);
                                Console.WriteLine("----------------------------------------------");
                            }
                        }
                        break;
                    }
                    case 0: {
                       Environment.Exit(0);
                       break;
                    }
                    default: Console.WriteLine("\nOptiune invalida!"); {
                    break;
                    }
                }
            }
        }
    }
}
