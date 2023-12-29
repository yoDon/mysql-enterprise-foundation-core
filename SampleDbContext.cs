using Microsoft.EntityFrameworkCore;

namespace SampleMySqlEfCore
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext()
        {
        }

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}
