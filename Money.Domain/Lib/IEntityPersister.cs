using System;
using System.Collections.Generic;
using Money.Model.Lib;

namespace Money.Domain.Lib
{
    public interface IEntityPersister
    {
        /// <param name="onUpdate">Callback in which to update collections. First parameter is the database entity, second parameter is the new (detached) entity</param>
        int Save<TEntity>(TEntity entity, Func<TEntity, TEntity> getDbEntity = null, Action<TEntity, TEntity> onUpdate = null) where TEntity : class, IEntity;
        void Update<TEntity>(TEntity existingItem, TEntity newItem, Action<TEntity, TEntity> onUpdate = null) where TEntity : class;
        void UpdateCollection<TEntity>(int parentId, ICollection<TEntity> existingItems, IEnumerable<TEntity> newItems, Action<TEntity, TEntity> onUpdateChild = null, Action<TEntity> onBeforeDeleteItem = null) where TEntity : class, IEntity, IHasOwner, new();
        void UpdateCollection<TEntity>(int parentId, ICollection<TEntity> existingItems, IEnumerable<TEntity> newItems, Action<TEntity, int> setParentId, Action<TEntity, TEntity> onUpdateChild = null, Action<TEntity> onBeforeDeleteItem = null) where TEntity : class, IEntity, new();
    }
}
