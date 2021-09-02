using MovieMates_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMates_Backend.DAL.Db
{
    public static class NewInitializer
    {
        public static void Initialize(NewContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any() && context.Genres.Any() && context.Users.Any() && context.Groups.Any() && context.UserGroups.Any() && context.UserMovies.Any() && context.MovieGenres.Any())
            {
                return;   // DB has been seeded
            }

            var Genres = new List<Genre>
            {
                new Genre{ GenreName = "Action"},
                new Genre{ GenreName = "Fantasy"},
                new Genre{ GenreName = "Sci-Fi"},
                new Genre{ GenreName = "Adventure"},
                new Genre{ GenreName = "Romcom"},
                new Genre{ GenreName = "Romance"},
                new Genre{ GenreName = "Historical"},
                new Genre{ GenreName = "Horror"},
                new Genre{ GenreName = "Mystery"},
                new Genre{ GenreName = "Crime"},
                new Genre{ GenreName = "Comedy"}
            };
            Genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();


            var Movies = new List<Movie>
            {
                new Movie { Title = "Avengers: Endgame", Description = "Lorem Ipsum", Platform = Platforms.DisneyPlus , IMDb = 8.4, ReleaseYear = new DateTime(2019, 4, 24), RunTime= "3.01" },
                new Movie { Title = "V for Vendetta", Description = "Lorem Ipsum", Platform = Platforms.Netflix, IMDb = 8.7, ReleaseYear = new DateTime(2005, 12, 5), RunTime= "2.15" },
                new Movie { Title = "Spiderman: into the spiderverse", Description = "Lorem Ipsum", Platform = Platforms.Netflix, IMDb = 8.9, ReleaseYear = new DateTime(2018, 8, 8), RunTime= "2.36" },
                new Movie { Title = "Lord of the rings : The Fellowship of the Ring", Description = "Lorem Ipsum", Platform = Platforms.DisneyPlus, IMDb = 9.8, ReleaseYear = new DateTime(2000, 5, 14), RunTime= "3.21" },
                new Movie { Title = "Aquaman", Description = "Lorem Ipsum", Platform = Platforms.Netflix, IMDb = 8.2, ReleaseYear = new DateTime(2018, 12, 13), RunTime= "2.22" },
                new Movie { Title = "Emoji Movie", Description = "Lorem Ipsum", Platform = Platforms.Netflix, IMDb = 0.2, ReleaseYear = new DateTime(2017, 8, 10), RunTime= "1.31" },
                new Movie { Title = "Bee movie", Description = "Lorem Ipsum", Platform = Platforms.Netflix, IMDb = 10.0, ReleaseYear = new DateTime(2007, 12, 12), RunTime= "1.35" }
            };
            Random rdm = new Random();



            //var MovieGenres = new List<MovieGenre>();

            for (int i = 0; i < Movies.Count; i++)
            {
                var ID = rdm.Next(0, Genres.Count);


                MovieGenre movieGenre = new MovieGenre { Movie = Movies[i], MovieID = Movies[i].ID, Genre = Genres[ID], GenreID = Genres[ID].ID };
                Movies[i].Genres.Add(movieGenre);
                Genres[ID].Movies.Add(movieGenre);


                ID = rdm.Next(0, Genres.Count);
                movieGenre = new MovieGenre { Movie = Movies[i], MovieID = Movies[i].ID, Genre = Genres[ID], GenreID = Genres[ID].ID };
                Movies[i].Genres.Add(movieGenre);
                Genres[ID].Movies.Add(movieGenre);

            }
            //MovieGenres.ForEach(g => context.MovieGenres.Add(g));
            context.SaveChanges();



            var Groups = new List<Group>
            {
                new Group{Name="De koole kids klub"},
                new Group{Name="De OG Gangsters"},
                new Group{Name="De Republikeien"}
            };
            Groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();






            var Users = new List<User>
            {
                new User{Username="Tarzan", Email="TarzanLovesJane@Jungle.com", PasswordHash="Lorem Ipsum", PasswordSalt="Lorem Ipsum" },
                new User{Username="ShadowHunter", Email="ShadowHunter@discord.com", PasswordHash="Lorem Ipsum", PasswordSalt="Lorem Ipsum"},
                new User{Username="Baren", Email="Baren@Worlds.com", PasswordHash="Lorem Ipsum", PasswordSalt="Lorem Ipsum"},
                new User{Username="Twitch", Email="Twitch@TFT.com", PasswordHash="Lorem Ipsum", PasswordSalt="Lorem Ipsum"},
                new User{Username="Ari", Email="Ari@TFT.com", PasswordHash="Lorem Ipsum", PasswordSalt="Lorem Ipsum"},
                new User{Username="Janna", Email="Janna@TFT.com", PasswordHash="Lorem Ipsum", PasswordSalt="Lorem Ipsum"},
                new User{Username="Xin", Email="Xin@TFT.com", PasswordHash="Lorem Ipsum", PasswordSalt="Lorem Ipsum"},
                new User{Username="Spy", Email="Spy@TFT.com", PasswordHash="Lorem Ipsum", PasswordSalt="Lorem Ipsum"}
            };
            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();



            var UserGroups = new List<UserGroup>
            {
                new UserGroup{User = Users[1], UserID = Users[1].ID, Group = Groups[0], GroupID = Groups[0].ID},
                new UserGroup{User = Users[1], UserID = Users[1].ID, Group = Groups[1], GroupID = Groups[1].ID},
                new UserGroup{User = Users[1], UserID = Users[1].ID, Group = Groups[2], GroupID = Groups[2].ID},
                new UserGroup{User = Users[2], UserID = Users[2].ID, Group = Groups[1], GroupID = Groups[1].ID},
                new UserGroup{User = Users[3], UserID = Users[3].ID, Group = Groups[0], GroupID = Groups[0].ID},
                new UserGroup{User = Users[4], UserID = Users[4].ID, Group = Groups[2], GroupID = Groups[2].ID},
                new UserGroup{User = Users[5], UserID = Users[5].ID, Group = Groups[2], GroupID = Groups[2].ID}
            };
            UserGroups.ForEach(ug => context.UserGroups.Add(ug));
            context.SaveChanges();



            





            var UserMovies = new List<UserMovie>
            {
                new UserMovie{MovieID=Movies[0].ID, UserID=Users[0].ID, UserRating=7.1, Watched = false},
                new UserMovie{MovieID=Movies[1].ID, UserID=Users[1].ID },
                new UserMovie{MovieID=Movies[2].ID, UserID=Users[2].ID },
                new UserMovie{MovieID=Movies[3].ID, UserID=Users[3].ID, UserRating=6.8, Watched = false},
                new UserMovie{MovieID=Movies[4].ID, UserID=Users[4].ID, UserRating=3.6, Watched = false},
            };
            UserMovies.ForEach(s => context.UserMovies.Add(s));
            context.SaveChanges();

        }

    }
}
