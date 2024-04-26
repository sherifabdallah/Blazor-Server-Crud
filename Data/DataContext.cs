using Microsoft.EntityFrameworkCore;
using BlazorServerCrudDotNet8.Models;

namespace BlazorServerCrudDotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Build your Models here using efcore model builder
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Publisher = "CD Projekt", Title = "Cyberpunk 2077", ReleaseYear = 2020 },
                new VideoGame { Id = 2, Publisher = "FromSoftware", Title = "Elden Ring", ReleaseYear = 2022 },
                new VideoGame { Id = 3, Publisher = "Nintendo", Title = "The Legend of Zelda: Ocarina of Time", ReleaseYear = 2022 }
            );
        }

        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
