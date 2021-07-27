using RecipesBook.DAL;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace RecipesBook.DataManagers
{
    public class StepManager : AbsractDataManager<Step>
    {
        public StepManager(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override void Create(Step entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public override bool Edit(object key, Step editedEntity)
        {
            throw new NotImplementedException();
        }

        public override Step Get(Func<Step, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override Step Get(object key)
        {
            throw new NotImplementedException();
        }

        public override IList<Step> GetEntities<Parameter>(Func<Step, bool> predicate, Func<Step, Parameter> SortPredicate)
        {
            throw new NotImplementedException();
        }

        public override IList<Step> GetEntities<Parameter>(Func<Step, Parameter> SortPredicate)
        {
            throw new NotImplementedException();
        }

        public override IList<Step> GetEntities()
        {
            throw new NotImplementedException();
        }

        public override IList<Step> GetEntities(Func<Step, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
