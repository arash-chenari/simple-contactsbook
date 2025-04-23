using Microsoft.EntityFrameworkCore;

namespace ContactBook.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=ContactsBook;User Id=sa;Password=P@ssw0rd23;TrustServerCertificate=True;");
        }

        public DbSet<Contact> Contacts { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
