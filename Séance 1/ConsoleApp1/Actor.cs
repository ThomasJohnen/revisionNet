using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{

    [Serializable]
    public class Actor : Person
    {


        private readonly int _sizeInCentimeter;
        private List<Movie> _movies;


        public int SizeInCentimeter
        {
            get { return _sizeInCentimeter; }
        }




        public Actor(string name, string firstname, DateTime birthDate, int sizeInCentimeter) : base(name, firstname, birthDate)
        {

            this._sizeInCentimeter = sizeInCentimeter;
            this._movies = new List<Movie>();
        }



        public override string Name { get { return base.Name.ToUpper(); } }

        /**
         * 
         * @return list of movies in which the actor has played
         */
        public IEnumerator<Movie> Movies()
        {
            return _movies.GetEnumerator();
        }

        /**
         * add movie to the list of movies in which the actor has played
         * @param movie
         * @return false if the movie is null or already present
         */
        public bool addMovie(Movie movie)
        {
            if ((movie == null) || _movies.Contains(movie))
                return false;

            if (!movie.containsActor(this))
                movie.AddActor(this);
            _movies.Add(movie);

            return true;
        }

        public bool containsMovie(Movie movie)
        {
            return _movies.Contains(movie);
        }

    }
}
