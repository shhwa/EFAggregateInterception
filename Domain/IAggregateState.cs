namespace Domain;

public interface IAggregateState
{
    IAggregateRoot? Root { get; }
}