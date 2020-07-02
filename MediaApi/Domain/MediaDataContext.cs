using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaApi.Domain
{
    public class MediaDataContext : DbContext
    {
        public MediaDataContext(DbContextOptions<MediaDataContext> options): base(options)
        {
            
        }

        public DbSet<MediaItem>MediaItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaItem>().Property(p => p.Title).HasMaxLength(150);

            modelBuilder.Entity<MediaItem>().HasData(
                    new MediaItem { Id=1, Title = "Super Mario Kart", Consumed=false, Kind="game", RecommendedBy="Henry", Removed=false},
                    new MediaItem { Id=2, Title = "Game ofThrones", Consumed = true, Kind = "show", RecommendedBy = "Donna", DateConsumed=DateTime.Now.AddDays(-14), Removed = false }
                );
        }
    }
}
