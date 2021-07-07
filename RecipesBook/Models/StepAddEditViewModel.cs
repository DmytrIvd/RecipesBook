using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.Models
{
    public class StepAddEditViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Enter some text of the step pleasee")]
        public string Text { get; set; }


        public byte[] RealImg { get; set; }
        public string SelectedImg { get; set; }
    }
}
