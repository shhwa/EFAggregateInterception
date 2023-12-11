using Domain;

namespace Infrastructure;

public interface IUserRepository
{
    public void Add(User user);

    public User GetFirst();
}

public class UserRepository : IUserRepository
{
    private readonly UserContext userContext;

    public UserRepository(UserContext userContext)
    {
        this.userContext = userContext;
    }

    public void Add(User user)
    {
        userContext.Add((User.State)user.GetState());
    }

    public User GetFirst()
    {
        return new User(userContext.Users.First());
    }
}
