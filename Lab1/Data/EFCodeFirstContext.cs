using Lab1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lab1.Data
{
    class EFCodeFirstContext:DbContext
    {
        public EFCodeFirstContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<CustomerAddress> CustomersAddresses { get; set; } = null!;
    }
}
