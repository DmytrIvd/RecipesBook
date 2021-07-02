﻿using System;
using System.Text.Json.Serialization;

namespace RecipesBook.Models.Entities
{
    public class Step : IEntity
    {
        public string Id { get; set; }

        [JsonIgnore]
        public string ID { get { return Id; } }

        public string Text { get; set; }
        public byte[] Img { get; set; }
        public Recipe Recipe { get; set; }
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
