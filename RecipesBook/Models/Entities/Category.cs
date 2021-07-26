using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecipesBook.Models.Entities
{
    public class Category : IEntity
    {

        public string Id { get; set; }
        [JsonIgnore]
        public string ID { get { return Id; } }

        public bool IsHidden { get; set; }

        public string Name { get; set; }



        public string Description { get; set; }

        public DateTime DateOfAdd { get; set; }

        public byte[] MainImage { get; set; }
        public virtual ICollection<CategoryRecipe> Recipes { get; set; }

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
