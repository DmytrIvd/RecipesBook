using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.DataManagers
{
    public interface IDataManager<T>
    {
        void Create(T entity);
        bool Edit(object key, T editedEntity);
        bool Delete(object key);
        T Get(Func<T, bool> predicate);
        T Get(object key);
        IList<T> GetEntities<Parameter>(Func<T, bool> predicate, Func<T, Parameter> SortPredicate);
        IList<T> GetEntities<Parameter>(Func<T, Parameter> SortPredicate);
        IList<T> GetEntities();
        IList<T> GetEntities(Func<T, bool> predicate);
    }
}
