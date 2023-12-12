namespace Domain.Models {
    public record ComandaValidata(ValidRegistrationCity ValidRegistrationCity, ValidRegistrationStreet ValidRegistrationStreet) {
        public string ComandaId { get; set; }
    }
}