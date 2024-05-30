using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIco.Interfaces;
using TestTaskIIcoServer.Exceptions;

namespace TestTaskIIco.CrudService
{
    public class UserUpdaterService(ApplicationContext applicationContext) : IUserUpdaterService
    {
        async public Task<User> UpdateUserServiceAsync(int id, User newUser)
        {
            var currentUser = await applicationContext.Users.FirstOrDefaultAsync(x => x.ClientId == id)
                ?? throw new UserByIdNotFoundException("");

            applicationContext.Remove(currentUser);
            await applicationContext.AddAsync(newUser);
            applicationContext.SaveChanges();

            return newUser;
        }
    }
}