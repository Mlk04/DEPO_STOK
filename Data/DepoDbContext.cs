using DEPO_STOK.Models;
using Microsoft.EntityFrameworkCore;
namespace DEPO_STOK.Data
{
    public class DepoDbContext:DbContext
    {
        public DepoDbContext(DbContextOptions<DepoDbContext> options) : base(options) { }
        public DbSet<Products> Products { get; set; }
    }
}
