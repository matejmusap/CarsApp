using Microsoft.EntityFrameworkCore;
using CarsApp.Models;

namespace CarsApp.Data
{
    public class CarsAppContext : DbContext
    {
        public CarsAppContext (DbContextOptions<CarsAppContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Car { get; set; }
    }
}
