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
        async public Task<User[]> AddNoDublicateEntitiesAsyncService(User[] newUsers)
        {
            logger.LogInformation("POSTREQUEST---> Add users count: {users.Length}", newUsers.Length);

            var noDublicateUsers = new List<User>();

            foreach (var user in newUsers)
            {
                var currentUser = await applicationContext.Users.FirstOrDefaultAsync(x => x.ClientId == user.ClientId);
                if (currentUser == null)
                {
                    noDublicateUsers.Add(user);
                    await applicationContext.Users.AddAsync(user);
                    applicationContext.SaveChanges();
                }
            }

            if (noDublicateUsers.Count == 0)
            {
                logger.LogInformation("All entities is dublicate");
            }

            return noDublicateUsers.ToArray();
        }
    }
}