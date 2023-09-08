using Lab04.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab04.Data
{
    public class CRContext : DbContext
    {
        public CRContext(DbContextOptions options) : base(options) { }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
    }
}
