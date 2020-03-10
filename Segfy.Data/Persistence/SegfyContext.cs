using Microsoft.EntityFrameworkCore;
using Segfy.Business.Models;

namespace Segfy.Data.Persistence
{
    public class SegfyContext : DbContext
    {
        public SegfyContext(DbContextOptions options) : base(options) { }

        public DbSet<Youtube> Youtube { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SegfyContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
