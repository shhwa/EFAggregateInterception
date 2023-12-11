namespace Domain;

public interface IAggregateRoot
{
    IAggregateState GetState();
}
