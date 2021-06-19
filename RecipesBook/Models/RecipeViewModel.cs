using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Models
{
    public class RecipeViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Ingredients { get; set; }
        public byte[] Image { get; set; }
        //?????? 
        //Ще не знаю як це буде насправді
        public object[] Steps { get; set; }

        public CategoryViewModel[] Categories { get; set; }
    }
}
