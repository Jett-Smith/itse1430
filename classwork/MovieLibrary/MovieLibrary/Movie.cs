using System;

namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    public class Movie
    {
        public string title;
        public string description;
        public int runLength;
        public int releaseYear = 1900;
        public double reviewRating;
        public string rating;
        public bool isClassic;

        public const int MinimumReleaseYear = 1900;

        /// <summary>Copies the movie</summary>
        /// <returns>A copy of the movie</returns>
        public Movie Copy ()
        {
            var movie = new Movie();
            movie.title = title;
            movie.description = description;
            movie.runLength = runLength;
            movie.releaseYear = releaseYear;
            movie.reviewRating = reviewRating;
            movie.rating = rating;
            movie.isClassic = isClassic;

            return movie;
        }

        public string Validate ()
        {
            //Name is required
            if(String.IsNullOrEmpty(title))
                return "Title is required";

            //runLength >= 0
            if(runLength < 0)
                return "Run Length must be at least 0";

            //releaseYear >= 1900
            if(releaseYear < MinimumReleaseYear)
                return "Release Year must be at least " + MinimumReleaseYear;

            return null;
        }
        
        private void SetDescriptionToTitle ()
        {
            description = title;
        }
    }
}
