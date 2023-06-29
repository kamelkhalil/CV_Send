using CV_Send.Model;
using Microsoft.EntityFrameworkCore;

namespace CV_Send.Data
{
    public class AppDataBaseContext : DbContext
    {
        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> option):base(option)
        {

        }
        public DbSet<Programmer> Programer { get; set; }
    }
}
