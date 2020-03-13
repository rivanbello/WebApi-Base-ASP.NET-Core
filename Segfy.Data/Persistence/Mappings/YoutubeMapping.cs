using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Segfy.Youtube.Models;

namespace Segfy.Data.Persistence.Mappings
{
    public class YoutubeMapping : IEntityTypeConfiguration<YoutubeModel>
    {
        public void Configure(EntityTypeBuilder<YoutubeModel> builder)
        {
            builder.ToTable("Yoututbe");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.ThumbnailUrl)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.IsChannel)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(c => c.ChannelName)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.PublishedAt)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime");

        }
    }
}
