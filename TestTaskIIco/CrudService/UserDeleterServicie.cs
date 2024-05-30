using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIco.Interfaces;
using TestTaskIIcoServer.Exceptions;

namespace TestTaskIIco.CrudService
{
    public class UserDeleterServicie(ApplicationContext applicationContext) : IUserDeleterServicie
    {
        async public Task<User> DeleteUserServiceAsync(int id)
        {
            var currentUser = await applicationContext.Users.FirstOrDefaultAsync(X => X.ClientId == id)
                ?? throw new UserByIdNotFoundException("");

            applicationContext.Users.Remove(currentUser);
            applicationContext.SaveChanges();

            return currentUser;
        }
    }
}