using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The RM",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Family Comedy",
                    Price = 7.99M,
                    Rating = "PG",
                    Image = "~/images/rm.jpg"
                },
                new Movie
                {
                    Title = "Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Adventure",
                    Rating = "G",
                    Price = 8.99M,
                    Image = "~/images/heaven.jpg"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Documentary",
                    Rating = "G",
                    Price = 9.99M,
                    Image = "~/images/meet.jpg"
                },
                new Movie
                {
                    Title = "The Best Two Years",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Comedy",
                    Rating = "G",
                    Price = 3.99M,
                    Image = "~/images/twoyears.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}