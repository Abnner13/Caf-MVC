using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcCoffeContext : DbContext
    {
        public DbSet<Coffe> Coffe { get; set; }
        public MvcCoffeContext(DbContextOptions<MvcCoffeContext> options) : base(options){}
    }
}
