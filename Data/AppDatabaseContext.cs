using Microsoft.EntityFrameworkCore;
using RssReader.Models;

namespace RssReader.Data;

public class AppDatabaseContext : DbContext
{
    public DbSet<ChannelModel> Channels { get; set; }
    public DbSet<ItemModel> Items { get; set; }
    public DbSet<ChannelImageModel> ChannelImages { get; set; }
    public DbSet<EnclosureModel> Enclosures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=RssReaderData.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ChannelModel>()
            .HasMany(c => c.Items)
            .WithOne()
            .HasForeignKey(i => i.ChannelId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<ChannelModel>()
            .HasOne<ChannelImageModel>()
            .WithOne()
            .HasForeignKey<ChannelImageModel>(i => i.ChannelId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<ItemModel>()
            .HasOne<EnclosureModel>(i => i.Enclosure)
            .WithOne()
            .HasForeignKey<EnclosureModel>(e => e.ItemId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}