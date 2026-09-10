using Microsoft.EntityFrameworkCore;
using ORMPratice.Entities;

namespace ORMPratice.Contexts
{
    internal class UniversityDb : DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
