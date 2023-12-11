using static Domain.Models.Stare;

namespace Domain.Models {
    public record Carucior{
        public IStare stare { get; private init; } 
        public List<Produs> listaProduse { get; private init; }

        public Carucior(List<Produs> listaProduse)
        {
            this.listaProduse = listaProduse;
        }
        public Carucior(List<Produs> listaProduse, IStare stare)
        {
            this.stare=stare;
            this.listaProduse=listaProduse;
        }
    }
}   