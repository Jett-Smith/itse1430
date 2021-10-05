using System;

namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    public class Movie
    {
        //Constructors (Demo Only)
        //Default constructor
        //public Movie ()
        //{ }
        //
        //public Movie ( string title ) : this(0, title)
        //{
        //    //Initialize(title);
        //    //Title = title;
        //}
        //
        //public Movie ( int id, string title )
        //{
        //    Id = id;
        //    //Initialize(title);
        //    Title = title;
        //}
        //
        //Shared init but dangerous to use
        //private void Initialize ( string title )
        //{
        //    Title = title;
        //}
        public int Id { get; private set; }

        /// <summary>Gets or sets the titile</summary>
        public string Title
        {
            //null-coalesce ::= E ?? E (returns the first non-null value)
            //null conditional ::= E?.M (returns M?) changes the type of the expression
            get 
            {
                
                
                return _title ?? "";
                //return (_title != null) ? _title : ""; 
            }
            set 
            {
                _title = value?.Trim();
                //_title = (value != null) ? value.Trim() : null;

                //Movie m;
                //int id = m?.Id ?? 0; //int?
            }
        }
        /// <summary>Gets or sets the description</summary>
        public string Description
        {
            get { return (_description != null) ? _description : ""; }
            set { _description = (value != null) ? value.Trim() : null; }
        }

        //Full property syntax
        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //Auto property
        /// <summary>Gets or sets the run length</summary>
        public int RunLength { get; set; }
        /// <summary>Gets or sets the release year</summary>
        public int ReleaseYear { get; set; } = MinimumReleaseYear;
        /// <summary>Gets or sets the review rating</summary>
        public double ReviewRating { get; set; }
        /// <summary>Gets or sets the rating</summary>
        public string Rating
        {
            get { return (_rating != null) ? _rating : ""; }
            set { _rating = (value != null) ? value.Trim() : null; }
        }
        /// <summary>Gets or sets whether the movie is a classic or not</summary>
        public bool IsClassic { get; set; }

        private string _title;
        private string _description;
        //private int _runLength;
        //private int _releaseYear = MinimumReleaseYear;
        //private double _reviewRating;
        private string _rating;
        //private bool _isClassic;

        public const int MinimumReleaseYear = 1900;

        /// <summary>Copies the movie</summary>
        /// <returns>A copy of the movie</returns>
        public Movie Copy ()
        {
            var movie = new Movie();
            movie.Title = Title;
            movie.Description = Description;
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.ReviewRating = ReviewRating;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;

            return movie;
        }

        /// <summary>Gets the age of the movie</summary>
        /// <returns>The age of the movie in years</returns>
        public int AgeInYears
        {
            get { return DateTime.Now.Year - ReleaseYear; }
        }

        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < 1922; }
        }

        /// <summary>Validates the movie</summary>
        /// <returns>A error if there is one</returns>
        public string Validate ()
        {
            //Name is required
            if(String.IsNullOrEmpty(Title))
                return "Title is required";

            //runLength >= 0
            if(RunLength < 0)
                return "Run Length must be at least 0";

            //releaseYear >= 1900
            if(ReleaseYear < MinimumReleaseYear)
                return "Release Year must be at least " + MinimumReleaseYear;

            return null;
        }
        
        private void SetDescriptionToTitle ()
        {
            Description = Title;
        }
    }
}
