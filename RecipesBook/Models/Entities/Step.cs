using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecipesBook.Models.Entities
{
    public class Step : IEntity
    {
        public string Id { get; set; }

        [JsonIgnore]
        public string ID { get { return Id; } }
        [Required(ErrorMessage = "Add some text please")]
        [MaxLength(200, ErrorMessage = "To much for one step")]
        [MinLength(10, ErrorMessage = "Enter some more information about this step!")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Select image please")]
        public byte[] Img { get; set; }
        public virtual Recipe Recipe { get; set; }
        public override bool Equals(object obj)
        {
            return obj is Step step &&
                   Id == step.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
