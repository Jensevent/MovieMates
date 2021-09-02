using Microsoft.Extensions.Configuration;
using MovieMates_Backend.DAL.Db;
using MovieMates_Backend.Entities;
using MovieMates_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieMates_Backend.DAL
{
    public class MovieDAL : IMovieDAL
    {
        NewContext db;

        public MovieDAL(NewContext context)
        {
            db = context;
        }

        public bool AddMovie(Movie movie)
        {
            if (db.Movies.Where(m => m.Title == movie.Title).FirstOrDefault() != null)
            {
                return false;
            }


            db.Movies.Add(movie);
            db.SaveChanges();
            return true;
        }

        public bool MovieIDExists(int movieID)
        {
            if (db.Movies.Where(m => m.ID == movieID).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        ICollection<Movie> IMovieDAL.GetAllMovies()
        {
            return db.Movies.ToList();
        }

        Movie IMovieDAL.GetMovie(int movieID)
        {
            return db.Movies.Where(m => m.ID == movieID).FirstOrDefault();
        }

        ICollection<Movie> IMovieDAL.GetMoviesByGenre(Genre genre)
        {
            ICollection<Movie> movies = db.Movies.Where(m => m.Genres.Count != 0 && m.Genres.Any(g => g.GenreID == genre.ID)).ToList();

            //foreach (Movie movie in movies)
            //{
            //    //foreach(MovieGenre movieGenre in movie.Genres)
            //    //{
            //    //    movieGenre.Movie = null;
            //    //    //thisGenre.Movies.Clear();
            //    //}
            //}
            return movies;
        }
    }
}
