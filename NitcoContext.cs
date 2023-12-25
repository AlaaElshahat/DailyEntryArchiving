using DailyEntryArchiving.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyEntryArchiving
{
    public class NitcoContext:DbContext
    {
        public NitcoContext(DbContextOptions<NitcoContext>options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
        }
        public DbSet<AccountChart>AccountCharts { get; set; }
        public DbSet<DailyDetailsEntry> DailyDetailsEntries { get; set;}
        public DbSet<DailyEntry> DailyEntries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DailyEntry>()
            //.HasMany(e=>e.DetailsEntries).WithOne(d=>d.DailyEntry).OnDelete(DeleteBehavior.Cascade)
            
            // .fore
            // modelBuilder.Entity<AccountChart>().HasChangeTrackingStrategy

            base.OnModelCreating(modelBuilder);
        }
       
    }
}
