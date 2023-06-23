using Microsoft.EntityFrameworkCore;
using MVCNEW.Models.Domain;

namespace MVCNEW.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Bike> Bikes { get; set; }
    }
}
