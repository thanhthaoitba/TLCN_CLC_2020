using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Models
{
    public class APIDbContext: DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options)
       : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(s => s.movieId);
            modelBuilder.Entity<Actor>().HasKey(s => s.ActorId);
            modelBuilder.Entity<Blog>().HasKey(s => s.BlogId);
            modelBuilder.Entity<Genre>().HasKey(s => s.TypeId);
            modelBuilder.Entity<User>().HasKey(s => s.userId);
            modelBuilder.Entity<Prize>().HasKey(s => s.PrizeId);
            modelBuilder.Entity<Productor>().HasKey(s => s.ProductorId);
            modelBuilder.Entity<Directors>().HasKey(s => s.DirectorsId);


      modelBuilder.Entity<MovieActor>().HasKey(sc => new { sc.MovieId, sc.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne<Movie>(sc => sc.Movie)
                .WithMany(s => s.MovieActors)
                .HasForeignKey(sc => sc.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne<Actor>(sc => sc.Actor)
                .WithMany(s => s.MovieActors)
                .HasForeignKey(sc => sc.ActorId);


            modelBuilder.Entity<TypeMovie>().HasKey(sc => new { sc.MovieId, sc.TypeId });
            modelBuilder.Entity<TypeMovie>()
                .HasOne<Movie>(sc => sc.Movie)
                .WithMany(s => s.TypeMovies)
                .HasForeignKey(sc => sc.MovieId);

            modelBuilder.Entity<TypeMovie>()
                .HasOne<Genre>(sc => sc.Genre)
                .WithMany(s => s.TypeMovies)
                .HasForeignKey(sc => sc.TypeId);


            modelBuilder.Entity<UserCommentMovie>().HasKey(sc => new { sc.MovieId, sc.UserId });
            modelBuilder.Entity<UserCommentMovie>()
                .HasOne<Movie>(sc => sc.Movie)
                .WithMany(s => s.UserCommentMovies)
                .HasForeignKey(sc => sc.MovieId);

            modelBuilder.Entity<UserCommentMovie>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserCommentMovies)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserFavoriteMovie>().HasKey(sc => new { sc.MovieId, sc.UserId });
            modelBuilder.Entity<UserFavoriteMovie>()
                .HasOne<Movie>(sc => sc.Movie)
                .WithMany(s => s.UserFavoriteMovies)
                .HasForeignKey(sc => sc.MovieId);

            modelBuilder.Entity<UserFavoriteMovie>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserFavoriteMovies)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserBlog>().HasKey(sc => new { sc.BlogId, sc.UserId });
            modelBuilder.Entity<UserBlog>()
                .HasOne<Blog>(sc => sc.Blog)
                .WithMany(s => s.UserBlogs)
                .HasForeignKey(sc => sc.BlogId);

            modelBuilder.Entity<UserBlog>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserBlogs)
                .HasForeignKey(sc => sc.UserId);

        }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    public DbSet<TypeMovie> TypeMovies { get; set; }
    public DbSet<UserBlog> UserBlogs { get; set; }
    public DbSet<Prize> Prizes { get; set; }
    public DbSet<Directors> Directors { get; set; }
    public DbSet<Productor> Productors { get; set; }
    public DbSet<UserCommentMovie> UserCommentMovies { get; set; }
    public DbSet<UserFavoriteMovie> UserFavoriteMovies { get; set; }

  }
}
