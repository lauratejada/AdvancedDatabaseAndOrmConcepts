namespace Lab1.Models
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }

        public CustomerAddress() { }
    }
}
