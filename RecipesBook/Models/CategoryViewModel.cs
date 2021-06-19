namespace RecipesBook.Models
{
    public class CategoryViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public byte[] Image { get; set; }
        public RecipeViewModel[] Recipes { get; set; }

    }
}
