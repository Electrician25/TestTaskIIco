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
            logger.LogInformation("POSTREQUEST---> Add user: {newUser.ToString()}", newUser.ToString());

            await applicationContext.Users.AddAsync(newUser);
            applicationContext.SaveChanges();

            return newUser;
        }
    }
}