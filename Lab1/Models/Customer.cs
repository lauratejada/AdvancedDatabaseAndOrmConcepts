namespace Lab1.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public virtual HashSet<CustomerAddress> CustomerAddresses { get; set; }

        public Customer() {
            this.CustomerAddresses = new HashSet<CustomerAddress>();
        }
    }
}
