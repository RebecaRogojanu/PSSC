namespace Domain.Models {
    public record ProdusList{
        public List<Produs>listaProduse{ get; private set; }

        public ProdusList(List<Produs>listaProduse)
        {
          this.listaProduse = listaProduse;
        }
    }
}   