using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipesBook.DataManagers
{
    public class CategoryManager : AbsractDataManager<Category>
    {
        //public override Category Get(Predicate<Category> predicate)
        //{
        //   return this.Entities.SingleOrDefault(e=>predicate.Invoke(e));
        //}

        //public override IList<Category> GetEntities(Predicate<Category> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public override IList<Category> GetEntities()
        //{
        //    throw new NotImplementedException();
        //}

        protected override void Seed()
        {
            

        }
    }
}
