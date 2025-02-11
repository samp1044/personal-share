package shared;

public interface AggregateRoot<T extends ValueObject> {
    public T getId();
}
