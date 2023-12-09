namespace Data.Models {
    public class ComandaDTO {
        public string comandaId { get; set; }
        public string caruciorId { get; set; }
        public string clientId { get; set; }
        public string status { get; set; }
        public decimal total { get; set; }
    }
}