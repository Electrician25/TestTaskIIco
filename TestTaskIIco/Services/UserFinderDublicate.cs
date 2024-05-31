using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIco.Interfaces;

namespace TestTaskIIcoServer.CrudService
{
    public class UserFinderDublicate(
        ApplicationContext applicationContext,
        ILogger<UserFinderDublicate> logger) : IUserFinderDublicate
    {
        async public Task<User[]> AddNoDublicateEntitiesAsyncService(User[] users)
        {
            logger.LogInformation("POSTREQUEST---> Add users count: {users.Length}", users.Length);

            var result = new List<User>();
            var currentUsers = await applicationContext.Users.ToArrayAsync();
            int i = 0;
            int j = 0;

            foreach (var user in users)
            {
                if (user.ClientId != currentUsers[i].ClientId)
                {
                    result.Add(user);
                    j++;
                }
                i++;
            }

            result.TrimExcess();

            return result.ToArray();
        }
    }
}