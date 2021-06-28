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
        T Get(Func<T, bool> predicate, bool loadReferences = false);
        T Get(object key, bool loadReferences = false);
        IList<T> GetEntities<Parameter>(Func<T, bool> predicate, bool loadReferences = false, Func<T, Parameter> SortPredicate = null);
        IList<T> GetEntities<Parameter>(bool loadReferences = false, Func<T, Parameter> SortPredicate = null);
    }
}
