using System;
using System.Collections.Generic;
using System.Linq;
using Money.Model.Lib;
using Money.Model.Persist;

namespace Money.Domain.Lib
{
    public class EntityPersister : IEntityPersister
    {
        IMoneyContext context;

        public EntityPersister(IMoneyContext context)
        {
            this.context = context;
        }

        public int Save<TEntity>(TEntity entity, Func<TEntity, TEntity> getDbEntity = null, Action<TEntity, TEntity> onUpdate = null) where TEntity : class, IEntity
        {
            if (entity.IsNew())
            {
                Create();
            }
            else
            {
                Update();
            }

            return entity.Id;

            void Create()
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }

            void Update()
            {
                var dbEntity = getDbEntity != null ? getDbEntity(entity) : context.Set<TEntity>().SingleOrDefault(x => x.Id == entity.Id);

                if (dbEntity == null)
                {
                    entity.MakeNew();
                    Create();
                }
                else
                {
                    this.Update(dbEntity, entity, onUpdate);
                    context.SaveChanges();
                }
            }
        }

        public void Update<TEntity>(TEntity existingItem, TEntity newItem, Action<TEntity, TEntity> onUpdate = null) where TEntity : class
        {
            //TODO: create the target item if it does not already exist?

            context.ShallowCopy(newItem, existingItem);
            onUpdate?.Invoke(existingItem, newItem);
        }

        public void UpdateCollection<TEntity>(int parentId, ICollection<TEntity> existingItems, IEnumerable<TEntity> newItems, Action<TEntity, TEntity> onUpdateChild = null, Action<TEntity> onBeforeDeleteItem = null) where TEntity : class, IEntity, IHasOwner, new()
        {
            UpdateCollection(parentId, existingItems, newItems, (item, id) => item.OwnerId = id, onUpdateChild, onBeforeDeleteItem);
        }

        public void UpdateCollection<TEntity>(int parentId, ICollection<TEntity> existingItems, IEnumerable<TEntity> newItems, Action<TEntity, int> setParentId, Action<TEntity, TEntity> onUpdateChild = null, Action<TEntity> onBeforeDeleteItem = null) where TEntity : class, IEntity, new()
        {
            var deleted = existingItems.Where(k => newItems == null || !newItems.Any(x => x.Id == k.Id)).ToList();
            foreach (var item in deleted)
            {
                onBeforeDeleteItem?.Invoke(item);
                context.Set<TEntity>().Remove(item);
            }

            if (newItems != null)
            {
                // Items which should already exist but cannot be found should be treated as new. They were probably removed by another user.
                var missing = newItems.Where(n => !n.IsNew() && !existingItems.Any(e => e.Id == n.Id)).ToList();
                missing.ForEach(k => k.MakeNew());

                foreach (var item in newItems)
                {
                    // Mapping from edit models back to domain models might not have set FK properties so we must manually do this here
                    setParentId(item, parentId);

                    if (item.IsNew())
                    {
                        existingItems.Add(item);
                    }
                    else
                    {
                        var existingItem = existingItems.Single(x => x.Id == item.Id);
                        Update(existingItem, item, onUpdateChild);
                    }
                }
            }
        }
    }
}
