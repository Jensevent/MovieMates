using Microsoft.Extensions.Configuration;
using MovieMates_Backend.DAL.Db;
using MovieMates_Backend.Entities;
using MovieMates_Backend.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovieMates_Backend.DAL
{
    public class GenreDAL : IGenreDAL
    {
        NewContext db;

        public GenreDAL(NewContext context)
        {
            db = context;
        }

        public bool GenreIDExists(int genreID)
        {
            if (db.Genres.Where(g => g.ID == genreID).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        public ICollection<Genre> GetAllGenres()
        {
            List<Genre> genres = db.Genres.ToList();
            if (genres != null)
            {
                //foreach (Genre genre in genres)
                //{
                //    genre.Movies.Clear();
                //}

            }
            return genres;
        }

        public Genre GetGenre(int genreID)
        {
            return db.Genres.Where(g => g.ID == genreID).FirstOrDefault();
        }


    }
}
