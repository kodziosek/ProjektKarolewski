namespace ProjektKarolewski.Models
{
    public class CreateServiceDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int ContractId { get; set; }
    }
}
