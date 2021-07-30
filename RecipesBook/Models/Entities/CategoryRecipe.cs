using System;

namespace RecipesBook.Models.Entities
{
    public class CategoryRecipe
    {
        public virtual Recipe Recipe { get; set; }
        public string RecipeId { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CategoryRecipe recipe &&
                   RecipeId == recipe.RecipeId &&
                   CategoryId == recipe.CategoryId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RecipeId, CategoryId);
        }
    }
}
