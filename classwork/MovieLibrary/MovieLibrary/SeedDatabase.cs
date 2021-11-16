using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public static class SeedDatabase
    {
        public static void Seed ( this IMovieDatabase database)
        {
            var movies = new[]
            {
                new Movie() {
                    Title = "Jaws",
                    Rating = "PG",
                    RunLength = 210,
                    ReleaseYear = 1977,
                    Description = "Shark movie",
                },
                new Movie() {
                    Title = "Dune",
                    Rating = "PG",
                    RunLength = 300,
                    ReleaseYear = 1982,
                },
                new Movie() {
                    Title = "Jaws 2",
                    Rating = "PG-13",
                    RunLength = 190,
                    ReleaseYear = 1979,
                    Description = "Shark movie",
                },
            };

            foreach (var movie in movies)
                database.Add(movie);
        }
    }
}
