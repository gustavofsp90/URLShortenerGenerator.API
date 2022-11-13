using Microsoft.EntityFrameworkCore;
using GeradorURL.Model;

namespace GeradorURL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }

        public DbSet<Url> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Url>().ToTable("Url");
            SQLitePCL.Batteries.Init();
            
        }



    }
}
