using RecipesBook.DAL;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;

namespace RecipesBook.DataManagers
{
    public class AuthManager : AbsractDataManager<User>
    {
        public AuthManager(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public override bool Edit(object key, User editedEntity)
        {
            throw new NotImplementedException();
        }

        public override User Get(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override User Get(object key)
        {
            throw new NotImplementedException();
        }

        public override IList<User> GetEntities<Parameter>(Func<User, bool> predicate, Func<User, Parameter> SortPredicate)
        {
            throw new NotImplementedException();
        }

        public override IList<User> GetEntities<Parameter>(Func<User, Parameter> SortPredicate)
        {
            throw new NotImplementedException();
        }

        public override IList<User> GetEntities()
        {
            throw new NotImplementedException();
        }

        public override IList<User> GetEntities(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
