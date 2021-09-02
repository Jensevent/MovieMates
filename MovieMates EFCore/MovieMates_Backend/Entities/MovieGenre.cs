using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMates_Backend.Entities
{
    public class MovieGenre
    {
        //FK Movie
        [Required]
        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }

        //FK Genre
        [Required]
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
