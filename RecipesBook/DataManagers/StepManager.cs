using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;

namespace RecipesBook.DataManagers
{
    public class StepManager : AbsractDataManager<Step>
    {
        protected override void Seed()
        {
            Entities.Add(new Step() { Id = "1", Text = "Do this fisrt" });
            Entities.Add(new Step() { Id = "2", Text = "Do this secound" });
            Entities.Add(new Step() { Id = "3", Text = "Do this third" });
            Entities.Add(new Step() { Id = "4", Text = "Do this fourth" });
            Entities.Add(new Step() { Id = "5", Text = "Do this fifth" });
            Entities.Add(new Step() { Id = "6", Text = "Do this sixth" });
            Entities.Add(new Step() { Id = "7", Text = "Do this seventh" });
            Entities.Add(new Step() { Id = "8", Text = "Do this eighth" });

        }
    }
}
