using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    [Serializable]
    public class Director : Person
    {

        private IList<Movie> _directedMovies;

        public Director(String name, String firstname, DateTime birthDate) : base(name, firstname, birthDate)
        {
     
            _directedMovies = new List<Movie>();
        }

        public bool AddMovie(Movie movie)
        {

            if (_directedMovies.Contains(movie))
                return false;

            if (movie.Director == null)
                movie.Director = this;

            _directedMovies.Add(movie);

            return true;

        }

        public IEnumerator<Movie> Movies()
        {
            return _directedMovies.GetEnumerator();
        }

    }
}
