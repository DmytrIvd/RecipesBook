using System;

namespace RecipesBook.Models.Entities
{
    public class Category : IEntity
    {

        public string Id { get; set; }

        public string ID => Id;

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DateOfAdd { get; set; }

        public byte[] MainImage { get; set; }
        public Recipe[] Recipes { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   Id == category.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
