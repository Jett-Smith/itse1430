// ITSE 1420
// Movie Library

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Memory
{
    public class MemoryMovieDatabase : IMovieDatabase
    {
        //Dynamically resizing array
        private List<Movie> _items = new List<Movie>();
        private int _nextId = 1;

        //Error handling
        public Movie Add ( Movie movie, out string error )
        {
            //Movie must be valid
            if (!ObjectValidator.TryValidate(movie, out error))
                return null;

            //Movie title must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                error = "Movie must be unique";
                return null;
            }

            //Clone
            var newMovie = movie.Clone();

            //Set unique ID
            newMovie.Id = _nextId++;

            _items.Add(newMovie);

            movie.Id = newMovie.Id;
            return movie;
        }

        private Movie FindByTitle ( string title )
        {
            return _items.FirstOrDefault(x => String.Compare(title, x.Title, true) == 0);

            //foreach (var movie in _items)
            //    if (String.Compare(title, movie.Title, true) == 0)
            //        return movie;

            //return null;
        }

        private Movie FindById ( int id )
        {
            //Where (Func<Movie, bool>) -> IEnumerable<T>
            //return _items.Where(x => x.Id == id).FirstOrDefault();

            //return _items.FirstOrDefault(x => x.Id == id);
            //LINQ syntax
            return (from movie in _items
                    where movie.Id == id
                    select movie).FirstOrDefault();

            //foreach (var movie in _items)
            //    if (movie.Id == id)
            //        return movie;

            //return null;
        }

        private void Copy ( Movie target, Movie source )
        {
            target.Title = source.Title;
            target.Description = source.Description;
            target.Rating = source.Rating;
            target.RunLength = source.RunLength;
            target.ReleaseYear = source.ReleaseYear;
            target.IsClassic = source.IsClassic;
        }

        //Update
        public string Update ( int id, Movie movie )
        {
            //Movie must be valid
            if (!ObjectValidator.TryValidate(movie, out var error))
                return error;

            //Movie must exist
            var existing = FindById(id);
            if (existing == null)
            {
                return "Movie not found";
            }

            //Movie title must be unique
            var dup = FindByTitle(movie.Title);
            if (dup != null && dup.Id != id)
            {
                return "Movie must be unique";
            }

            Copy(existing, movie);
            return null;
        }

        //Delete
        public void Delete ( int id )
        {
            //TODO: Validate id
            var movie = FindById(id);
            if (movie != null)
                _items.Remove(movie);
        }

        //Get
        public Movie Get ( int id )
        {
            var movie = FindById(id);

            return movie?.Clone();
        }

        private class IdAndTitle
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
        private IdAndTitle Convert ( Movie movie )
        {
            return new IdAndTitle {
                Id = movie.Id,
                Title = movie.Title
            };
        }

        //private Movie Clone ( Movie movie )
        //{
        //    return movie.Clone();
        //}
        
        //Get All
        public IEnumerable<Movie> GetAll ()
        {
            //NEVER DO THIS - should not return a ref type directly
            //return _items;

            //int counter = 0;
            //Use iterator syntax

            //Select transforms S to T
            //IEnumerable<IdAndTitle> items = _items.Select<Movie, IdAndTitle>(Convert);
            //IEnumerable<IdAndTitle> items = _items.Select(Convert);
            //return _items.Select(Clone);

            // lambdas
            //      (T a, R b) => {...}      -> S
            // multiple parameters      (a, b) => {...}          -> S
            // single parameters        a => {...}               -> S
            // no parameters            () => {...}              -> S

            //return _items.Select(x => x.Clone());
            //LINQ syntax equivalent
            return from x in _items
                   select x.Clone();

            //foreach (var item in _items)
            //{
            //    yield return item.Clone();
            //}


            //var items = new Movie[_items.Count];

            //var index = 0;
            //foreach (var item in _items)
            //{
            //    items[index++] = item.Clone();
            //}

            //return items;
        }

        public void IsOnlyAvialableInMemoryMovieDatabase () 
        { }
    }
}
