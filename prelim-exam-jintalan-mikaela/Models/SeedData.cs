using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using prelim_exam_jintalan_mikaela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prelim_exam_jintalan_mikaela.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var DB = new MovieContext(serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>());
            if (DB.Movies.Any())
            {
                //if contains any data --- then we return --- we do not seed
                return;
            }
            DB.Movies.AddRange(
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-2-12"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                Rating = "PG",

            },

            new Movie
            {
                Title = "Ghostbusters ",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Comedy",
                Price = 8.99M,
                Rating = "GP"
            },

            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = "Comedy",
                Price = 9.99M,
                Rating = "GP"
            },

            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-4-15"),
                Genre = "Western",
                Price = 3.99M,
                Rating = "R"
            }
        );
            DB.SaveChanges();
        }
    }
}