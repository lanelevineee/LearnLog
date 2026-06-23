namespace HMS.Shared.Domain;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; } = default!;

    protected Entity() { }
    protected Entity(TId id) => Id = id;
}

public abstract class AggregateRoot<TId> : Entity<TId>
{
    protected AggregateRoot() : base() { }
    protected AggregateRoot(TId id) : base(id) { }
}
