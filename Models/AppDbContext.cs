using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppMvc.Net.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // ...
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach(var entityTypes in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityTypes.GetTableName();
                if(tableName.StartsWith("AspNet"))
                {
                    entityTypes.SetTableName(tableName.Substring(6));
                }
            }
        }

        public DbSet<Contact.Contact> Contacts { get; set; }
    }
}
