using Advertisment.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Advertisment.Data
{

    public class DataContext: DbContext
    {
        public DbSet<Adver> advers { get; set; }
        public DbSet<Advertiser> advertisers { get; set; }
        public DbSet<Route> routes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DataBaseAdvertisment");
        }

    }
}
