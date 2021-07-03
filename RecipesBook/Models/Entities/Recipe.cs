using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipesBook.Models.Entities
{
    public class Recipe : IEntity
    {
        public string Id { get; set; }
        [JsonIgnore]
        public string ID { get { return Id; } }

         public string Name { get; set; }


         public string Description { get; set; }

        [DisplayName("Date of adding the recipe")]
        public DateTime DateOfAdd { get; set; }

         public string[] Ingredients { get; set; }

        public byte[] MainImage { get; set; }

       public Step[] Steps { get; set; }

       public Category[] Categories { get; set; }

        public User Author { get; set; }

        public User[] UsersThatLiked { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Recipe recipe &&
                   Id == recipe.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
