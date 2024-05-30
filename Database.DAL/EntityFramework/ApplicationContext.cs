using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;

namespace PostgreDatabase.DAL.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}