using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Models.Entities
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Ingredients { get; set; }
        public byte[] MainImage { get; set; }
       
        public Step[] Steps { get; set; }

        public Category[] Categories { get; set; }

        public User[] UserThatLiked { get; set; }

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
