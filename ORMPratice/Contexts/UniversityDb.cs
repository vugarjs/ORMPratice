using Microsoft.EntityFrameworkCore;
using ORMPratice.Config;
using ORMPratice.Entities;

namespace ORMPratice.Contexts
{
    internal class UniversityDb : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=UniversityDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityDb).Assembly); // Apply configurations from the current assembly
        }
    }
}
