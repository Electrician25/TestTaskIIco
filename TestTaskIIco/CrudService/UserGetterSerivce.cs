using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIco.Interfaces;
using TestTaskIIcoServer.Exceptions;

namespace TestTaskIIco.CrudService
{
    public class UserGetterSerivce(ApplicationContext applicationContext) : IUserGetterSerivce
    {
        async public Task<User> GetUserByIdAsyncService(int id)
        {
            return await applicationContext.Users.FirstOrDefaultAsync(x => x.ClientId == id)
                ?? throw new UserByIdNotFoundException("");
        }
    }
}