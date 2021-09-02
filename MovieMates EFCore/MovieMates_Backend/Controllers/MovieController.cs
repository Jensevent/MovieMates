using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieMates_Backend.Containers;
using MovieMates_Backend.DAL;
using MovieMates_Backend.DAL.Db;
using MovieMates_Backend.Entities;
using MovieMates_Backend.Hubs;
using MovieMates_Backend.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieMates_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        //private readonly ILogger<MovieController> _logger;
        //private readonly IConfiguration config;
        MovieContainer mc;
        IDValidator idValidator = new IDValidator();

        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly NewContext context;
       
        public MovieController(NewContext context, IHubContext<NotificationHub> notificationHub)
        {
            mc = new MovieContainer(new MovieDAL(context));
            _notificationHub = notificationHub;
            this.context = context;
        }



        [HttpGet]
        [Route("all")]
        public ActionResult GetMovies()
        {
            ICollection<Movie> movies = mc.GetAllMovies();

            if (movies.Count == 0)
            {
                return NotFound("No movies found");
            }

            foreach (Movie movie in movies)
            {
                //if(movie.Genres != null)
                //{
                //    foreach (MovieGenre movieGenre in movie.Genres)
                //    {
                //    movieGenre.Movie = null;
                //    //genre.Movies.Clear();
                //    }
                //}
                

                //if (movie.Users != null)
                //{
                //    movie.Users.Clear();
                //}
                
            }

            

            return Ok(movies);
        }


        [HttpGet]
        [Route("filter/{genreid}")]
        public ActionResult GetMoviesByGenre(string genreid)
        {
            GenreContainer genreContainer = new GenreContainer(new GenreDAL(context));

            if (!idValidator.ValidateGenreID(genreContainer, genreid))
            {
                return BadRequest(idValidator.errorMessage);
            }

            ICollection<Movie> movies = mc.GetMoviesByGenre(genreContainer.GetGenre(Convert.ToInt32(genreid)));

            if (movies.Count == 0)
            {
                return NotFound("No movies found with this genre");
            }

            //foreach (Movie movie in movies)
            //{
            //    foreach (MovieGenre movieGenre in movie.Genres)
            //    {
            //        movieGenre.Movie = null;
            //        //genre.Movies.Clear();
            //    }
            //    movie.Users.Clear();
            //}


            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult FindMovie(string id)
        {
            if (!idValidator.ValidateMovieID(mc, id))
            {
                return BadRequest(idValidator.errorMessage);
            }

            Movie movie = mc.GetMovie(Convert.ToInt32(id));

            movie.Users.Clear();
            foreach (MovieGenre movieGenre in movie.Genres)
            {
                movieGenre.Movie = null;
                //genre.Movies.Clear();
            }

            return Ok(mc.GetMovie(Convert.ToInt32(id)));
        }


        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddMovie([FromBody] Movie movie)
        {
            if (mc.AddMovie(movie))
            {
                Message msg = new Message { msgHeader = "New Movie added", msgContext = "The movie " + movie.Title + " has been added to " + (Platforms)movie.Platform + "!" };

                await _notificationHub.Clients.All.SendAsync("sendToUser", msg.msgHeader, msg.msgContext);
                return Ok("Movie has been Added!");
            }
            else
            {
                return BadRequest("This movie is already in the database!");
            }
        }
    }
}
