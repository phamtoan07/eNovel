﻿using MediatR;
using Novel.Data;

namespace Novel.Core.Events
{
    /// <summary>
    /// A container for entities that are updated.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityUpdated<T> : INotification where T : ParentEntity
    {
        public EntityUpdated(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; private set; }
    }
}
