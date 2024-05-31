using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIco.Interfaces;
using TestTaskIIcoServer.Exceptions;

namespace TestTaskIIco.CrudService
{
    public class UserGetterSerivce(ApplicationContext applicationContext,
        ILogger<UserGetterSerivce> logger) : IUserGetterSerivce
    {
        async public Task<User> GetUserByIdAsyncService(int id)
        {
            logger.LogInformation("GETREQUEST---> Get user by id: {id}", id);

            return await applicationContext.Users.FirstOrDefaultAsync(x => x.ClientId == id)
                ?? throw new UserByIdNotFoundException("Error occurred when trying to get user by id by get user method");
        }
    }
}