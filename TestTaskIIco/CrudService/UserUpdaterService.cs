using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIco.Interfaces;
using TestTaskIIcoServer.Exceptions;

namespace TestTaskIIco.CrudService
{
    public class UserUpdaterService(
        ApplicationContext applicationContext,
        ILogger<UserUpdaterService> logger) : IUserUpdaterService
    {
        async public Task<User> UpdateUserServiceAsync(int id, User newUser)
        {
            logger.LogInformation("UPDATEREQUEST---> Get user by id: {id}", id);

            var currentUser = await applicationContext.Users.FirstOrDefaultAsync(x => x.ClientId == id)
                ?? throw new UserByIdNotFoundException("Error occurred when trying to get user by id by update user method");

            applicationContext.Remove(currentUser);
            await applicationContext.AddAsync(newUser);
            applicationContext.SaveChanges();

            return newUser;
        }
    }
}