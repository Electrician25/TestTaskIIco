using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;

namespace Tests
{
    public class FakeDatabase
    {
        public async Task<ApplicationContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ApplicationContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Users.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Users.AddRange(
                        new User()
                        {
                            ClientId = 1,
                            SystemId = new Guid(),
                            UserName = "Alex"
                        },
                        new User()
                        {
                            ClientId = 2,
                            SystemId = new Guid(),
                            UserName = "William"
                        },
                        new User()
                        {
                            ClientId = 3,
                            SystemId = new Guid(),
                            UserName = "Oleg"
                        },
                        new User()
                        {
                            ClientId = 4,
                            SystemId = new Guid(),
                            UserName = "Monika"
                        }
                    );
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
    }
}