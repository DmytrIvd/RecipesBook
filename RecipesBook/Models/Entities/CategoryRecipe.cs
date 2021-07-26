namespace RecipesBook.Models.Entities
{
    public class CategoryRecipe
    {
        public virtual Recipe Recipe { get; set; }
        public string RecipeId { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }
    }
}
