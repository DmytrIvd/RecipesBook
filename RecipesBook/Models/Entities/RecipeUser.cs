namespace RecipesBook.Models.Entities
{
    public class RecipeUser
    {
        public Recipe Recipe { get; set; }
        public string RecipeId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

    }
}
