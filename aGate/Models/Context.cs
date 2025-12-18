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

        public DbSet<Campaing> campaings { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<CampaingStaff> CampaingStaffs { get; set; }
        public DbSet<StaffNote> StaffNotes { get; set; }
        public DbSet<Advert> Adverts { get; set; }

    }
}
