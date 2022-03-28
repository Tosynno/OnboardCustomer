using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<tbl_Onboarding> tbl_Onboardings { get; set; }
        public DbSet<tbl_Banks> tbl_banks { get; set; }
        public DbSet<tbl_lga> tbl_lgas { get; set; }
        public DbSet<tbl_State> tbl_States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<tbl_lga>()
          .HasOne(p => p.tblStates)
          .WithMany(b => b.tbllgas).HasForeignKey(v => v.StateId);
        }
    }
}
