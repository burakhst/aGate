using Microsoft.EntityFrameworkCore;

namespace aGate.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7C6PLDK\\SQLEXPRESS; database=agateDb; integrated security=true;TrustServerCertificate=True;");
        }
        public DbSet<Client> clients { get; set; } 

    }
}
