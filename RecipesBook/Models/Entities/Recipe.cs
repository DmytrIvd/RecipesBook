using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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

        public DateTime DateOfAdd { get; set; }

        public string[] Ingredients
        {
            get { return this.StringIngredients.Split('}'); }
            set
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var i in value)
                {
                    stringBuilder.Append(i);
                    stringBuilder.Append('}');
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                this.StringIngredients = stringBuilder.ToString();
            }
        }
        public string StringIngredients { get; set; }
        public byte[] MainImage { get; set; }

        public virtual ICollection<Step> Steps { get; set; }

        public virtual ICollection<CategoryRecipe> Categories { get; set; }

        public User Author { get; set; }

        public virtual ICollection<RecipeUser> UsersThatLiked { get; set; }

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
