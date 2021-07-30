using System;

namespace RecipesBook.Models.Entities
{
    public class RecipeUser
    {
        public Recipe Recipe { get; set; }
        public string RecipeId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is RecipeUser user &&
                   RecipeId == user.RecipeId &&
                   UserId == user.UserId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RecipeId, UserId);
        }
    }
}
