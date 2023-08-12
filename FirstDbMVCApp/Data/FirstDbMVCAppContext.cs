using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstDbMVCApp.Models;

namespace FirstDbMVCApp.Data
{
    public class FirstDbMVCAppContext : DbContext
    {
        public FirstDbMVCAppContext (DbContextOptions<FirstDbMVCAppContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;
    }
}
