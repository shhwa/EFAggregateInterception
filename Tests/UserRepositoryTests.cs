using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class UserRepositoryTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var _contextOptions = new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase("test1")
            .Options;

        using (var context = new UserContext(_contextOptions))
        {
            IUserRepository repository = new UserRepository(context);
            repository.Add(new User("billy bloggs"));
            context.SaveChanges();
        }

        using (var context = new UserContext(_contextOptions))
        {
            IUserRepository repository = new UserRepository(context);
            var user = repository.GetFirst();
            user.ChangeName("cilly cloggs");
            context.SaveChanges();
        }

        using (var context = new UserContext(_contextOptions))
        {
            IUserRepository repository = new UserRepository(context);
            var user = repository.GetFirst();

            Assert.That(user.Name, Is.EqualTo("cilly cloggs"));
        }
    }
}