using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMates_Backend.Entities
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        public string Username { get; set; }

        //[JsonIgnore]
        [Required]
        public string PasswordHash { get; set; }
        
        //[JsonIgnore]
        [Required]
        public string PasswordSalt { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        [JsonIgnore]
        public virtual ICollection<UserMovie> Movies { get; set; }

        public virtual ICollection<UserGroup> Groups { get; set; }

        //[Timestamp]
        //public byte[] version { get; set; }
    }
}
