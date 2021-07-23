﻿using RecipesBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesBook.DataManagers
{
    public abstract class AbsractDataManager<T> : IDataManager<T> where T : IEntity
    {
        protected IList<T> Entities;

        public AbsractDataManager()
        {
            Entities = new List<T>();
            Seed();

        }
        /// <summary>
        /// Will be called in constructor, set up fake data here!
        /// </summary>
        protected abstract void Seed();

        public virtual void Create(T entity)
        {
            Entities.Add(entity);
        }

        public virtual bool Delete(object key)
        {
            var entity = Entities.SingleOrDefault(e => e.ID == key.ToString());
            if (entity != null)
            {
                return Entities.Remove(entity);
            }
            return false;
        }

        public virtual bool Edit(object key, T editedEntity)
        {
            var entity = Entities.SingleOrDefault(e => e.ID == key.ToString());

            if (entity != null)
            {
                var index = Entities.IndexOf(entity);
                Entities[index] = editedEntity;
                return true;
            }
            return false;
        }

        public virtual T Get(Func<T, bool> predicate, bool loadReferences = false)
        {
            return Entities.SingleOrDefault(predicate);
        }

        public virtual T Get(object key, bool loadReferences = false)
        {
            return Entities.SingleOrDefault(e => e.ID == key.ToString());
        }

        public virtual IList<T> GetEntities<Parameter>(Func<T, bool> predicate, bool loadReferences = false, Func<T, Parameter> SortPredicate = null)
        {
            if (predicate != null)
            {
                var entities = Entities.Where(predicate);
                if (SortPredicate != null)
                {
                    entities.OrderByDescending(e => SortPredicate.Invoke(e));
                }
                return entities.ToList();
            }
            return null;
        }

        public virtual IList<T> GetEntities<Parameter>(bool loadReferences = false, Func<T, Parameter> SortPredicate = null)
        {
            if (SortPredicate != null)
            {
                return Entities.OrderByDescending(e => SortPredicate.Invoke(e)).ToList();
            }
            return Entities;
        }


    }
}
