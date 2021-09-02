using Microsoft.EntityFrameworkCore;
using MovieMates_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMates_Backend.DAL.Db
{
    public class NewContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public NewContext(DbContextOptions<NewContext> options) : base(options)
        {
            
        }
      

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }


        //Link tables
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Movie <--> Genre
            modelBuilder
                .Entity<MovieGenre>().HasKey(um => new { um.MovieID, um.GenreID });

            modelBuilder.Entity<MovieGenre>()
                .HasOne<Movie>(um => um.Movie)
                .WithMany(um => um.Genres)
                .HasForeignKey(um => um.MovieID);

            modelBuilder.Entity<MovieGenre>()
                .HasOne<Genre>(um => um.Genre)
                .WithMany(um => um.Movies)
                .HasForeignKey(um => um.GenreID);


            // Movie <--> User
            modelBuilder
                .Entity<UserMovie>().HasKey(um => new { um.MovieID, um.UserID });

            modelBuilder.Entity<UserMovie>()
                .HasOne<User>(um => um.User)
                .WithMany(um => um.Movies)
                .HasForeignKey(um => um.UserID);

            modelBuilder.Entity<UserMovie>()
                .HasOne<Movie>(um => um.Movie)
                .WithMany(um => um.Users)
                .HasForeignKey(um => um.MovieID);


            //Group <--> User
            modelBuilder
                .Entity<UserGroup>().HasKey(um => new { um.GroupID, um.UserID });

            modelBuilder.Entity<UserGroup>()
                .HasOne<User>(um => um.User)
                .WithMany(um => um.Groups)
                .HasForeignKey(um => um.UserID);

            modelBuilder.Entity<UserGroup>()
                .HasOne<Group>(um => um.Group)
                .WithMany(um => um.Members)
                .HasForeignKey(um => um.GroupID);


            //Group JoinID Unique
            modelBuilder.Entity<Group>()
                .HasIndex(g => g.JoinID)
                .IsUnique();
        }
    }
}
