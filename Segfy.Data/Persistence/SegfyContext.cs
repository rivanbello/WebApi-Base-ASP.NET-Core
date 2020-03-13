using Microsoft.EntityFrameworkCore;
using Segfy.Youtube.Models;

namespace Segfy.Data.Persistence
{
    public class SegfyContext : DbContext
    {
        public SegfyContext(DbContextOptions options) : base(options) { }

        public DbSet<YoutubeModel> Youtube { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SegfyContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
