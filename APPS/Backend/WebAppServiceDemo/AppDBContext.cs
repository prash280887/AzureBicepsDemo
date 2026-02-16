using Microsoft.EntityFrameworkCore;
using WebAppServiceDemo.Model.Entity;

namespace WebAppServiceDemo
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
               
        }

        public DbSet<Employees> employees { get; set; }
    
    }
}
