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
            //var tes = users.Distinct().Count();

            //var g = await applicationContext.Users.Where(x
            //    => x.ClientId != users.Distinct().Count()).ToArrayAsync();

            //return await applicationContext.Users.Where(x
            //    => x.ClientId == users.Distinct().Count()).ToArrayAsync();

            var appl = applicationContext.Users.ToArray();
            int i = 0;
            int j = 0;
            foreach (var user in users)
            {
                if (user.ClientId != appl[i].ClientId)
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