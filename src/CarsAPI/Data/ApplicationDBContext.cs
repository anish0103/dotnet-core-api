using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Car> CarsList { get; set; }
    }
}
