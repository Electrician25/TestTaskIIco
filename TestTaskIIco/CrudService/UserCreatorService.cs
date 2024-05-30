using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIco.Interfaces;

namespace TestTaskIIco.CrudService
{
    public class UserCreatorService(
        ApplicationContext applicationContext, ILogger<UserCreatorService> logger) : IUserCreatorService
    {
        async public Task<User> CreateUserAsyncService(User newUser)
        {
            await applicationContext.Users.AddAsync(newUser);
            applicationContext.SaveChanges();

            logger.LogInformation("REQUEST---> Add user: {newuser}", newUser.ToString());

            return newUser;
        }
    }
}