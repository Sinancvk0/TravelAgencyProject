using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Dal
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context>options):base(options)
        {
            
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
