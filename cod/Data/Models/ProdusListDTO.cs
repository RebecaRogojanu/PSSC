namespace Data.Models {
    public class ProdusListDTO {
        public string ProdusListId { get; set; }
        public List<ProdusDTO>ListaProduse {get; set;}
        public decimal Cantitate { get; set; }   
        public string ClientId { get; set; }   
    }
}