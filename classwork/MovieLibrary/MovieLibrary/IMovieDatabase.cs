// ITSE 1420
// Movie Library

namespace MovieLibrary
{
    public interface IMovieDatabase
    {
        // All member are always public, cannot specify access
        // Only type member that are not implementation details are allowed
        //      Methods, properties, events
        // The implementation is not provided
        Movie Add ( Movie movie, out string error );
        void Delete ( int id );
        Movie Get ( int id );
        Movie[] GetAll ();
        string Update ( int id, Movie movie );
    }
}