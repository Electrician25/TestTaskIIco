using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIcoServer.Interfaces;

namespace TestTaskIIcoServer.CrudService
{
    public class UserFinderDublicate(ApplicationContext applicationContext) : IUserFinderDublicate
    {
        async public Task<User[]> AddNoDublicateEntitiesAsyncService(User[] users)
        {
            var resultUsers = new User[users.Length];

            foreach (var user in users)
            {
                resultUsers = await applicationContext.Users.SkipWhile(x => x.ClientId == user.ClientId).ToArrayAsync();
            }

            return resultUsers;
        }
    }
}