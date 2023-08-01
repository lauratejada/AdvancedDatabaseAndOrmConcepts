namespace Lab1.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public virtual HashSet<CustomerAddress> CustomerAddresses { get; set; }

        public Address() 
        {
            this.CustomerAddresses = new HashSet<CustomerAddress>();
        }
    }
}
