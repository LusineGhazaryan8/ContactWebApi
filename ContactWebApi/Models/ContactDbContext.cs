using Microsoft.EntityFrameworkCore;

namespace ContactWebApi.Models
{
    public class ContactDbContext:DbContext
    {
       public DbSet<Contact> Contacts { get; set; }
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }

    }
}
