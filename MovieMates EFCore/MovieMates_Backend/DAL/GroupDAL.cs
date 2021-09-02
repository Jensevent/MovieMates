using Microsoft.Extensions.Configuration;
using MovieMates_Backend.Entities;
using MovieMates_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Data;
using MovieMates_Backend.DAL.Db;

namespace MovieMates_Backend.DAL
{
    public class GroupDAL : IGroupDAL
    {
        NewContext db;

        public GroupDAL(NewContext context)
        {
            db = context;
        }

        public bool AddUserToGroup(string joinGroupID, Guid userID)
        {
            Group group = db.Groups.Where(g => g.JoinID == joinGroupID).FirstOrDefault();
            User user = db.Users.Where(u => u.ID == userID).FirstOrDefault();

            

            if (db.UserGroups.Where(ug => ug.GroupID == group.ID && ug.UserID == user.ID).SingleOrDefault() == null)
            {
                return false;
            }
            UserGroup userGroup = new UserGroup { User = user, UserID = user.ID, Group = group, GroupID = group.ID };

            db.UserGroups.Add(userGroup);
            db.SaveChanges();      
            return true;
        }

        public Group CreateGroup(string name)
        {
            Group group = new Group { Name = name };
            db.Groups.Add(group);
            db.SaveChanges();
            return group;
        }

        public ICollection<Group> GetAllGroups()
        {
            return db.Groups.ToList();
        }

        public Group GetGroup(int groupID)
        {
            return db.Groups.Where(g => g.ID == groupID).FirstOrDefault();
        }

        public ICollection<User> GetGroupMembers(int groupID)
        {
            Group group = db.Groups.Where(g => g.ID == groupID).FirstOrDefault();
            List<User> users = new List<User>();
            
            foreach(UserGroup userGroup in db.UserGroups)
            {
                if(userGroup.Group == group)
                {
                    users.Add(userGroup.User);
                }
            }

            return users;
        }

        public ICollection<Movie> GetGroupMovies(int groupID)
        {
            Group group = db.Groups.Where(g => g.ID == groupID).FirstOrDefault();
            

            List<Movie> movies = new List<Movie>();
            foreach (UserGroup userGroup in group.Members)
            {
                User user = userGroup.User;

                foreach(UserMovie userMovie in user.Movies)
                {
                    Movie movie = userMovie.Movie;

                    if (movies.Contains(movie) || userMovie.Watched == true)
                    {
                        int x = movie.Amount;
                        movie.Amount = x + 1;

                        continue;
                    }
                    else
                    {
                        foreach(MovieGenre movieGenre in movie.Genres)
                        {
                            movieGenre.Movie = null;
                            //genre.Movies.Clear();
                        }
                        movie.Amount = 1;
                        movies.Add(movie);
                    }
                }   
            }
            
            foreach(Movie movie in movies)
            {
                movie.Users.Clear();
            }

            var newlist = movies.OrderByDescending(m => m.Amount).ToList();
            return newlist;
        }

        public bool GroupIDExists(int groupID)
        {
            if (db.Groups.Where(g => g.ID == groupID).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        public bool JoinGroupIDExists(string groupID)
        {
            if (db.Groups.Where(g => g.JoinID == groupID).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
