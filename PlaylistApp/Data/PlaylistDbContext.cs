using Microsoft.EntityFrameworkCore;
using PlaylistApp.Models;
using System;

namespace PlaylistApp.Data
{
    public class PlaylistDbContext : DbContext
    {
        public PlaylistDbContext(DbContextOptions<PlaylistDbContext> options) : base(options) { }

        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Playlist> Playlists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1001, Name = "Artist 1" },
                new Artist { Id = 1002, Name = "Artist 2" },
                new Artist { Id = 1003, Name = "Artist 3" }
            );
            modelBuilder.Entity<Album>().HasData(
                new Album { Id = 2001, Title = "Album 1", Year = 2020 },
                new Album { Id = 2002, Title = "Album 2", Year = 2018 },
                new Album { Id = 2003, Title = "Album 3", Year = 2015 }
            );
            modelBuilder.Entity<Song>().HasData(
            new Song { Id = 3001, Title = "Song 1", LengthInSeconds = 180, AlbumID = 2001, PlaylistID = 1 },
            new Song { Id = 3002, Title = "Song 2", LengthInSeconds = 240, AlbumID = 2002, PlaylistID = 1 },
            new Song { Id = 3003, Title = "Song 3", LengthInSeconds = 200, AlbumID = 2001, PlaylistID = 2 }
            );
        }
    }
}
