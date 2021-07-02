using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipesBook.Models.Entities
{
    public class User : IEntity
    {
        public string Email { get; set; }
        //public byte[] Avatar { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Recipe[] LikedRecipes { get; set; }

        [JsonIgnore]
        public string ID { get { return Email; } }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Email == user.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email);
        }
    }
}
