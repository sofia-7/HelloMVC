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
                    Title = "Love Death And Robots ",
                    ReleaseDate = DateTime.Parse("2019-2-12"),
                    Genre = "Fantasy",
                    Price = 990M
                },
                new Movie
                {
                    Title = "Dead Poets Society ",
                    ReleaseDate = DateTime.Parse("1995-9-10"),
                    Genre = "Drama",
                    Price = 860M
                },
                new Movie
                {
                    Title = "Batman ",
                    ReleaseDate = DateTime.Parse("2023-7-8"),
                    Genre = "Fantasy",
                    Price = 1150M
                },
                new Movie
                {
                    Title = "Midsommar ",
                    ReleaseDate = DateTime.Parse("2019-6-6"),
                    Genre = "Horror",
                    Price = 790M
                }
            );
            context.SaveChanges();
        }
    }
}