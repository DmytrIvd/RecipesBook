using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;

namespace RecipesBook.DataManagers
{
    public class CategoryManager : IDataManager<Category>
    {
        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public bool Edit(object key, Category editedEntity)
        {
            throw new NotImplementedException();
        }

        public Category Get(object key)
        {
            throw new NotImplementedException();
        }

        public Category Get(Predicate<Category> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetEntities(Predicate<Category> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<Recipe> GetEntities()
        {
            throw new NotImplementedException();
        }
    }
}
