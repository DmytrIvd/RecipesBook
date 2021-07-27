using RecipesBook.DAL;
using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.DataManagers
{
    public abstract class AbsractDataManager<T> : IDataManager<T> where T : IEntity
    {
        protected ApplicationDbContext DbContext;

        public AbsractDataManager(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;

        }


        public abstract void Create(T entity);


        public abstract bool Delete(object key);

        public abstract bool Edit(object key, T editedEntity);

        public abstract T Get(Func<T, bool> predicate);
        public abstract T Get(object key);


        public abstract IList<T> GetEntities<Parameter>(Func<T, bool> predicate, Func<T, Parameter> SortPredicate);
        public abstract IList<T> GetEntities<Parameter>(Func<T, Parameter> SortPredicate);
        public abstract IList<T> GetEntities();
        public abstract IList<T> GetEntities(Func<T, bool> predicate);
        
    }
}
