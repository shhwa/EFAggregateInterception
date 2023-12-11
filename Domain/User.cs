namespace Domain;

public class User : IAggregateRoot
{
    private readonly int id;

    private string name;

    public User(string name)
    {
        this.name = name;
    }

    public User(State userState)
    {
        id = userState.Id;
        name = userState.Name ?? "";
        userState.Root = this;
    }

    public string Name => name;

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public IAggregateState GetState()
    {
        return new State
        {
            Id = id,
            Name = name,
            Root = this,
        };
    }

    public class State : IAggregateState
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public IAggregateRoot? Root { get; set; }
    }
}
