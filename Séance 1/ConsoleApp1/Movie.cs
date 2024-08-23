using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class Movie
    {
        private String _title;
        private int _releaseYear;
        private IList<Actor> _actors;
        private Director _director;

        public Movie(String title, int releaseYear)
        {
            _actors = new List<Actor>();
            this._title = title;
            this._releaseYear = releaseYear;
        }

        public Director? Director {
            get { return _director; } 
            set { if (value == null)
                    return;
                  this.Director = value;
                  Director?.AddMovie(this);
            } 
        }

        public String Title { 
            get { return _title; }
            set { this._title = value; }
        }
        
        public int ReleaseYear {
            get { return _releaseYear; }
            set { this._releaseYear = value; }

        }



        public bool AddActor(Actor actor)
        {
            if (_actors.Contains(actor))
                return false;

            _actors.Add(actor);
            if (!actor.containsMovie(this))
                actor.addMovie(this);

            return true;
        }

        public bool containsActor(Actor actor)
        {
            return _actors.Contains(actor);
        }

        
    public override String ToString()
        {
            return "Movie [title=" + _title + ", releaseYear=" + _releaseYear + "]";
        }
    }
}
