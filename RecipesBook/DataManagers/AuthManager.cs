using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;

namespace RecipesBook.DataManagers
{
    public class AuthManager : IDataManager<User>
    {
        private readonly IDataManager<Recipe> _recipeService;

        public AuthManager(IDataManager<Recipe> recipeDataManager)
        {
            _recipeService = recipeDataManager;
        }
        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public bool Edit(object key, User editedEntity)
        {
            throw new NotImplementedException();
        }

        public User Get(object key)
        {
            throw new NotImplementedException();
        }

        public User Get(Predicate<User> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetEntities(Predicate<User> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<Recipe> GetEntities()
        {
            throw new NotImplementedException();
        }
    }
}
