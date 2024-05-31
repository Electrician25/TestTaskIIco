using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIco.Interfaces;
using TestTaskIIcoServer.Exceptions;

namespace TestTaskIIco.CrudService
{
    public class UserDeleterServicie(
        ApplicationContext applicationContext,
        ILogger<UserDeleterServicie> logger) : IUserDeleterServicie
    {
        async public Task<User> DeleteUserServiceAsync(int id)
        {
            logger.LogInformation("DELETEREQUEST---> Add user by id: {id}", id);

            var currentUser = await applicationContext.Users.FirstOrDefaultAsync(X => X.ClientId == id)
                ?? throw new UserByIdNotFoundException("Error occurred when trying to get user by id by delete user method");

            applicationContext.Users.Remove(currentUser);
            applicationContext.SaveChanges();

            return currentUser;
        }
    }
}