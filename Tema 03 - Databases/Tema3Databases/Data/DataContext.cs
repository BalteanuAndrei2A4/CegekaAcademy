
using Tema3Databases.Models;

namespace Tema3Databases.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options ) { }

        public DbSet<CarOffer>  CarOffers { get; set; } 
    }
}
