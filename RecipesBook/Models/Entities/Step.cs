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
        //public int Order { get; set; }
        public string Text { get; set; }
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
