namespace Ordering.Domain.Abstractions
{
    public interface IAggregate<T> : IAggregate, IEntity<T>
    {

    }

    public interface IAggregate : IDomainEvent, IEntity
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }
        public void AddDomainEvent(IDomainEvent domainEvent);
        public IDomainEvent[] ClearDomainEvents();
    }
}
