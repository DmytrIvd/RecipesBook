using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;

namespace RecipesBook.DataManagers
{
    public class StepManager : IDataManager<Step>
    {
        public void Create(Step entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public bool Edit(object key, Step editedEntity)
        {
            throw new NotImplementedException();
        }

        public Step Get(Predicate<Step> predicate)
        {
            throw new NotImplementedException();
        }

        public Step Get(object key)
        {
            throw new NotImplementedException();
        }

        public IList<Step> GetEntities(Predicate<Step> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<Recipe> GetEntities()
        {
            throw new NotImplementedException();
        }
    }
}
