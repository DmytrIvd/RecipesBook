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
        T Get(Predicate<T> predicate);
        T Get(object key);
        IList<T> GetEntities(Predicate<T> predicate);
        IList<Recipe> GetEntities();
    }
}
