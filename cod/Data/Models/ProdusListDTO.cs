namespace Data.Models {
    public class ProdusListDTO {
        public string ProdusListId { get; set; }
        public List<string>ListaProduse {get; set;}
        public decimal Cantitate { get; set; }   
        public string ClientId { get; set; }   
    }
}