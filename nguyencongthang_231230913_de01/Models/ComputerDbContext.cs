using Microsoft.EntityFrameworkCore;
namespace nguyencongthang_231230913_de01.Models
{
    public class ComputerDbContext : DbContext
    {
        public ComputerDbContext(DbContextOptions<ComputerDbContext> options) : base(options) { }
        public DbSet<nctComputer> nctComputers { get; set; }
    }
}
