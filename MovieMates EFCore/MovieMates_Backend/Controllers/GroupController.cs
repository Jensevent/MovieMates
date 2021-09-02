using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieMates_Backend.Containers;
using MovieMates_Backend.DAL;
using MovieMates_Backend.DAL.Db;
using MovieMates_Backend.Entities;
using MovieMates_Backend.Tools;

namespace MovieMates_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        GroupContainer gc;
        IDValidator idValidator = new IDValidator();

        private readonly NewContext context;

        public GroupController(NewContext context)
        {
            gc = new GroupContainer(new GroupDAL(context));
            this.context = context;
        }


        [HttpGet]
        [Route("all")]
        public ActionResult GetAllGroups()
        {
            ICollection<Group> groups = gc.GetAllGroups();

            if (groups.Count == 0)
            {
                NotFound("No users exists.");
            }

            foreach (Group group in groups)
            {
                foreach (UserGroup userGroup in group.Members)
                {
                    userGroup.Group = null;
                }
            }


            return Ok(groups);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetGroup(string id)
        {
             if (!idValidator.ValidateGroupID(gc, id))
             {
                 return NotFound(idValidator.errorMessage);
             }

            Group group = gc.GetGroup(Convert.ToInt32(id));
            foreach (UserGroup userGroup in group.Members)
            {
                userGroup.Group = null;
                //user.Groups.Clear();
            }


            return Ok(group);
        }

        [HttpGet]
        [Route("{id}/members")]
        public ActionResult GetGroupMembers(string id)
        {
            if (!idValidator.ValidateGroupID(gc, id))
            {
                return NotFound(idValidator.errorMessage);
            }


            ICollection<User> users = gc.GetGroupMembers(Convert.ToInt32(id));

            foreach(User user in users)
            {
                user.Groups.Clear();
            }

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}/movies")]
        public ActionResult GetGroupMovies(string id)
        {
            if (!idValidator.ValidateGroupID(gc, id))
            {
                return NotFound(idValidator.errorMessage);
            }

            ICollection<Movie> movies = gc.GetGroupMovies(Convert.ToInt32(id));
            if(movies != null)
            {
                return Ok(movies);
            }
            return BadRequest("The users of this group have no movies!");

        }


        [HttpPost]
        [Route("create/{name}")]
        public ActionResult CreateGroup(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest("Please fill out an groupname");
            }
  
            return Ok(gc.CreateGroup(name));
        }



        [HttpPatch]
        [Route("{groupid}/change/{name}")]
        public ActionResult ChangeGroupName(string groupid, string name)
        {
            if (!idValidator.ValidateGroupID(gc,groupid))
            {
                return BadRequest(idValidator.errorMessage);
            }

            return Ok("Name has been changed!");
        }







        [HttpPatch]
        [Route("{groupid}/add/{userid}")]
        public ActionResult AddUserToGroup(string groupid, string userid)
        {
            if (!idValidator.ValidateJoinGroupID(gc, groupid) || !idValidator.ValidateUserID(new UserContainer(new UserDAL(context)), userid))
            {
                return NotFound(idValidator.errorMessage);
            }

            if (!gc.AddUserToGroup(groupid, new Guid(userid)))
            {
                return BadRequest("This user is already in this group!");
            }

            return Ok("User has been added to group!");
        }
    }
}
