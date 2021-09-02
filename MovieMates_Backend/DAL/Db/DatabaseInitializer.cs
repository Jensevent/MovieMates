using MovieMates_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MovieMates_Backend.DAL
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        readonly Random rdm = new Random();


        protected override void Seed(DatabaseContext context)
        {
            if (Startup.Testing)
            {
                return;
            }

            //Generate Genres
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
                new Genre{ GenreName = "Comedy"},
                new Genre{ GenreName = "Drama"},
                new Genre{ GenreName = "Animation"},
                new Genre{ GenreName = "Family"}  
            };
            Genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();



            //Generate movies
            var Movies = new List<Movie>
            {
                //new Movie { Title= "", Description="", Platform = Platforms.DisneyPlus, IMDb=7.8, ReleaseYear=new DateTime(1998,01,29), RunTime="3h 14min", MovieGenres = new List<Genre>{ Genres[11], Genres[5], Genres[0] } },
                new Movie { Title= "Back to the Future", Description="Marty McFly, a 17-year-old high school student, is accidentally sent thirty years into the past in a time-traveling DeLorean invented by his close friend, the eccentric scientist Doc Brown.", Platform = Platforms.Netflix, IMDb=8.5, ReleaseYear=new DateTime(1985,12,12), RunTime="1h 56min", MovieGenres = new List<Genre>{ Genres[3], Genres[10], Genres[2] } },
                new Movie { Title= "Animal Farm", Description="A successful farmyard revolution by the resident animals vs. the farmer goes horribly wrong as the victors create a new tyranny among themselves.", Platform = Platforms.DisneyPlus, IMDb=7.2, ReleaseYear=new DateTime(1956,03,11), RunTime="1h 12min", MovieGenres = new List<Genre>{ Genres[12], Genres[11] } },
                new Movie { Title= "Nineteen Eighty-Four", Description="In a totalitarian future society, a man, whose daily work is re-writing history, tries to rebel by falling in love.", Platform = Platforms.Netflix, IMDb=7.1, ReleaseYear=new DateTime(1984,11,15), RunTime="1h 53min", MovieGenres = new List<Genre>{ Genres[11], Genres[2] } },
                new Movie { Title= "WALL·E", Description="In the distant future, a small waste-collecting robot inadvertently embarks on a space journey that will ultimately decide the fate of mankind.", Platform = Platforms.DisneyPlus, IMDb=8.4, ReleaseYear=new DateTime(2008,07,30), RunTime="1h 38min", MovieGenres = new List<Genre>{ Genres[12], Genres[3], Genres[13] } },
                new Movie { Title= "Toy Story", Description="A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy in a boy's room.", Platform = Platforms.DisneyPlus, IMDb=8.3, ReleaseYear=new DateTime(1996,04,4), RunTime="1h 21min", MovieGenres = new List<Genre>{ Genres[12], Genres[3], Genres[10] } },
                new Movie { Title= "Cars", Description="A hot-shot race-car named Lightning McQueen gets waylaid in Radiator Springs, where he finds the true meaning of friendship and family.", Platform = Platforms.DisneyPlus, IMDb=7.1, ReleaseYear=new DateTime(2006,06,21), RunTime="1h 57min", MovieGenres = new List<Genre>{ Genres[12], Genres[10], Genres[13] } },
                new Movie { Title= "Kung Fu Panda", Description="The Dragon Warrior has to clash against the savage Tai Lung as China's fate hangs in the balance. However, the Dragon Warrior mantle is supposedly mistaken to be bestowed upon an obese panda who is a novice in martial arts.", Platform = Platforms.DisneyPlus, IMDb=7.5, ReleaseYear=new DateTime(2008,07,9), RunTime="1h 32min", MovieGenres = new List<Genre>{ Genres[12], Genres[0], Genres[3] } },
                new Movie { Title= "Ice Age", Description="Set during the Ice Age, a sabertooth tiger, a sloth, and a wooly mammoth find a lost human infant, and they try to return him to his tribe.", Platform = Platforms.Netflix, IMDb=7.5, ReleaseYear=new DateTime(2002,04,25), RunTime="1h 21min", MovieGenres = new List<Genre>{ Genres[12], Genres[3], Genres[10] } },
                new Movie { Title= "Help! I am a fish", Description="Three children accidentally get turned into fish after drinking a potion made by an eccentric scientist. When the kids end up in the sea, they must find the antidote within 48 hours or remain as fish forever.", Platform = Platforms.Netflix, IMDb=6.0, ReleaseYear=new DateTime(2001,10,4), RunTime="1h 12min", MovieGenres = new List<Genre>{ Genres[12], Genres[3], Genres[10] } },
                new Movie { Title= "Ratatouille", Description="A rat who can cook makes an unusual alliance with a young kitchen worker at a famous restaurant.", Platform = Platforms.DisneyPlus, IMDb=8.0, ReleaseYear=new DateTime(2007,08,1), RunTime="1h 51min", MovieGenres = new List<Genre>{ Genres[12], Genres[3], Genres[10] } },
                new Movie { Title= "Schrek", Description="A mean lord exiles fairytale creatures to the swamp of a grumpy ogre, who must go on a quest and rescue a princess for the lord in order to get his land back.", Platform = Platforms.DisneyPlus, IMDb=7.8, ReleaseYear=new DateTime(2001,07,12), RunTime="1h 30min", MovieGenres = new List<Genre>{ Genres[12], Genres[3], Genres[10] } },
                new Movie { Title = "Avengers: Endgame", Description = "Adrift in space with no food or water, Tony Stark sends a message to Pepper Potts as his oxygen supply starts to dwindle. Meanwhile, the remaining Avengers -- Thor, Black Widow, Captain America and Bruce Banner -- must figure out a way to bring back their vanquished allies for an epic showdown with Thanos -- the evil demigod who decimated the planet and the universe.", Platform = Platforms.DisneyPlus , IMDb = 8.4, ReleaseYear = new DateTime(2019, 4, 24), RunTime= "3h 1min", MovieGenres = new List<Genre>{ Genres[0], Genres[3],Genres[11] }},
                new Movie { Title = "V for Vendetta", Description = "In a future British tyranny, a shadowy freedom fighter, known only by the alias of 'V', plots to overthrow it with the help of a young woman.", Platform = Platforms.Netflix, IMDb = 8.2, ReleaseYear = new DateTime(2005, 03, 30), RunTime= "2h 12min", MovieGenres = new List<Genre>{ Genres[0], Genres[11],Genres[2] } },
                new Movie { Title = "Spiderman: into the spiderverse", Description = "Teen Miles Morales becomes the Spider-Man of his universe, and must join with five spider-powered individuals from other dimensions to stop a threat for all realities.", Platform = Platforms.Netflix, IMDb = 8.4, ReleaseYear = new DateTime(2018, 12, 20), RunTime= "1h 57min", MovieGenres = new List<Genre>{ Genres[12], Genres[0],Genres[3] } },
                new Movie { Title = "Lord of the rings : The Fellowship of the Ring", Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", Platform = Platforms.Netflix, IMDb = 8.8, ReleaseYear = new DateTime(2001, 12, 19), RunTime= "2h 58min", MovieGenres = new List<Genre>{ Genres[0], Genres[3],Genres[11] } },
                new Movie { Title = "Aquaman", Description = "Arthur Curry, the human-born heir to the underwater kingdom of Atlantis, goes on a quest to prevent a war between the worlds of ocean and land.", Platform = Platforms.Netflix, IMDb = 6.9, ReleaseYear = new DateTime(2018, 12, 13), RunTime= "2h 23min", MovieGenres = new List<Genre>{ Genres[0], Genres[3],Genres[1] } },
                new Movie { Title = "Emoji Movie", Description = "Gene, a multi-expressional emoji, sets out on a journey to become a normal emoji.", Platform = Platforms.Netflix, IMDb = 3.3, ReleaseYear = new DateTime(2017, 8, 10), RunTime= "1h 26min", MovieGenres = new List<Genre>{ Genres[12], Genres[3],Genres[10] } },
                new Movie { Title = "Bee movie", Description = "Barry B. Benson, a bee just graduated from college, is disillusioned at his lone career choice: making honey. On a special trip outside the hive, Barry's life is saved by Vanessa, a florist in New York City. As their relationship blossoms, he discovers humans actually eat honey, and subsequently decides to sue them.", Platform = Platforms.Netflix, IMDb = 6.1, ReleaseYear = new DateTime(2007, 12, 12), RunTime= "1h 31min", MovieGenres = new List<Genre>{ Genres[12], Genres[3],Genres[13] } },
                new Movie { Title= "Titanic", Description="A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.", Platform = Platforms.DisneyPlus, IMDb=7.8, ReleaseYear=new DateTime(1998,01,29), RunTime="3h 14min", MovieGenres = new List<Genre>{ Genres[11], Genres[5] } },
                new Movie { Title= "Legend of the Guardians: The Owls of Ga'Hoole", Description="When a young owl is abducted by an evil Owl army, he must escape with new-found friends and seek the legendary Guardians to stop the menace.", Platform = Platforms.DisneyPlus, IMDb=6.9, ReleaseYear=new DateTime(2010,9,29), RunTime="1h 37min", MovieGenres = new List<Genre>{ Genres[12], Genres[0], Genres[3] } },
                new Movie { Title= "Fight Club", Description="An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", Platform = Platforms.Netflix, IMDb=8.8, ReleaseYear=new DateTime(1999,11,4), RunTime="2h 19min", MovieGenres = new List<Genre>{ Genres[11] } }
            };
            Movies.ForEach(m => context.Movies.Add(m));
            context.SaveChanges();
            

            //Generate Groups
            var Groups = new List<Group>
            {
                new Group{Name="The Meme Team"},
                new Group{Name="The boiz"},
                new Group{Name="De verloren zaak"},
                new Group{Name="Schrute Farms"},
                new Group{Name="Sk8ter boys"}
            };
            Groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();



            //Generate Users

            //Password = Welkom12345
            string hash = "olj8FunyLolozAdvGDik0XPwjmNFhlDXSAOj9cRaJ23bsKunvZ9SemERc1TEB/K8Dwo/0rxrxg7aspLm0/47sA/jPsTrl9s2Da1uo/X+0U5qRDDBZHANcBCkuafDqrb7InOm8CkIHXFnHNUmaAXjw6UAaOTaWIP0cBIRXo6sBKB0NY3/0x8GAyvDgq96Y3yzkVZKlJwLX57PRRFhNrC1Njghfln2Ekmb3ZqoywCf6OMgsiuFhySi8c+VD9+Ce8PFN4tOLwQ7RlhaDet0uUvh5NAcXxUNjjtyMtkg+eJk3V6kG0c+dnE3nLwx4wwL1vXiIwdH0Rkb6mtoiOdGqeP2RA==";
            string salt = "btUioJRtzCNdTNZ/WLojAXZE3h97hemmqAqjXO6nghevhlQkMthQ2V9pF0B7+3RuT+9x2zOpr3MaRq/z/b/yHA==";

            var Users = new List<User>
            {
                new User{Username="Tarzan", Email="Tarzan@mail.com", PasswordHash=hash, PasswordSalt=salt },
                new User{Username="ShadowHunter", Email="ShadowHunter@mail.com", PasswordHash=hash, PasswordSalt=salt },
                new User{Username="BroccoliFighter", Email="BroccoliFighter@mail.com", PasswordHash=hash, PasswordSalt=salt},
                new User{Username="MisterToast", Email="MisterToast@TFT.com", PasswordHash=hash, PasswordSalt=salt},
                new User{Username="Jensevent", Email="jensevent@mail.com", PasswordHash=hash, PasswordSalt=salt}
            };

            Users[0].Groups.Add(Groups[0]);
            Users[0].Groups.Add(Groups[1]);
            Users[0].Groups.Add(Groups[2]);
            Users[1].Groups.Add(Groups[1]);
            Users[2].Groups.Add(Groups[0]);
            Users[3].Groups.Add(Groups[2]);
            Users[4].Groups.Add(Groups[2]);

            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();



            //Generate User Movies
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
