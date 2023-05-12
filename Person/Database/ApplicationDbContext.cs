using Microsoft.EntityFrameworkCore;
using Person.Models.Persons;

namespace Person.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base (options) {
        }
        
        public DbSet<Models.Persons.Person> People { get; set; }
    }
}
