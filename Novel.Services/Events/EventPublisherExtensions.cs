using MediatR;
using Novel.Core.Events;
using Novel.Data;
using System.Threading.Tasks;

namespace Novel.Services.Events
{
    public static class EventPublisherExtensions
    {
        public static async Task EntityInserted<T>(this IMediator eventPublisher, T entity) where T : ParentEntity
        {
            await eventPublisher.Publish(new EntityInserted<T>(entity));
        }

        public static async Task EntityUpdated<T>(this IMediator eventPublisher, T entity) where T : ParentEntity
        {
            await eventPublisher.Publish(new EntityUpdated<T>(entity));
        }

        public static async Task EntityDeleted<T>(this IMediator eventPublisher, T entity) where T : ParentEntity
        {
            await eventPublisher.Publish(new EntityDeleted<T>(entity));
        }

    }
}
