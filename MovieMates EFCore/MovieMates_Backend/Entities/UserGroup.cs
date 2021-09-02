using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMates_Backend.Entities
{
    public class UserGroup
    {
        //FK User
        [Required]
        public Guid UserID { get; set; }
        public virtual User User { get; set; }

        //FK Movie
        [Required]
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }
    }
}
