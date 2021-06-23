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
        T Get(Predicate<T> predicate, bool loadReferences = false);
        T Get(object key, bool loadReferences = false);
        IList<T> GetEntities(Predicate<T> predicate, bool loadReferences = false, Func<T, object> SortPredicate = null);
        IList<T> GetEntities(bool loadReferences = false, Func<T, object> SortPredicate = null);
    }
}
