using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Memory
{
    internal class ArrayMovieDatabase
    {
        //Arrays are always open in C#
        //Array size is specified at the point of creation
        private Movie[] _items = new Movie[100];

        public ArrayMovieDatabase ()
        {
            //TODO: Seed
            //Object initializer - creating and initializing new object
            //movie = new Movie() {
            //    Title = "Jaws 2",
            //    Rating = "PG-13",
            //    RunLength = 190,
            //    ReleaseYear = 1979,
            //    Description = "Shark movie",
            //    Id = 3,
            //};
            //item[2] = movie;

            _items[0] = new Movie() {
                Title = "Jaws",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1979,
                Description = "Shark movie",
                Id = 1,
            };

            _items[1] = new Movie() {
                Title = "Dune",
                Rating = "PG",
                RunLength = 300,
                ReleaseYear = 1982,
                Id = 2,
            };

            _items[2] = new Movie() {
                Title = "Jaws 2",
                Rating = "PG-13",
                RunLength = 190,
                ReleaseYear = 1979,
                Description = "Shark movie",
                Id = 3,
            };
        }

        //TODO: Add
        public void Add (Movie movie)
        {

        }

        //TODO: Update
        public void Updata (Movie movie)
        {

        }

        //TODO: Delete
        public void Delete (Movie movie )
        {

        }

        //TODO: Get
        public Movie Get ()
        {
            return null;
        }

        //TODO: Get All
        public Movie[] GetAll ()
        {
            //NEVER DO THIS - should not return a ref type directly
            //return _items;
            //Array.Copy() - will copy array but not ref movie

            //Need to filter out null movies
            var count = 0;
            foreach (var item in _items)
            {
                if (item != null)
                    ++count;
            }

            //Must clone both array and movies to return new copies
            var items = new Movie[count];
            //Don't need the for loop
            //for (int index = 0; index < items.Length; index++)
            //{

            //    items[index] = Copy(_items[index]);
            //}

            //Each iteration the next element is copied to the item variable
            //2 limitations
            //  No index (use a simple index variable)
            //  Item is read only
            //  Array cannot change for the life of the loop (keep a seperate list)
            var index = 0;
            foreach (var item in _items)
            {
                if (item != null)
                    items[index++] = item.Clone();
            }
            return items;
        }
    }
}
