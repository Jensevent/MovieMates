using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMates_Backend.Entities
{
    public class Genre
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string GenreName { get; set; }

        public virtual ICollection<MovieGenre> Movies { get; set; }
        //public  ICollection<Movie> Movies { get; set; }
    }
}
