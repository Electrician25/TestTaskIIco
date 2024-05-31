using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PostgreDatabase.DAL.Entities;
using PostgreDatabase.DAL.EntityFramework;
using TestTaskIIco.CrudService;
using TestTaskIIcoServer.CrudService;
using TestTaskIIcoServer.Exceptions;

namespace Tests
{
    public class TestsForServices()
    {
        [Fact]
        async public void WhenCreatingNewUser_AndUserDateIsCorrect_ThenReturnTrue()
        {
            // Arrange.
            var mockLogger = new Mock<ILogger<UserCreatorService>>();
            var dbContext = await GetDatabaseContext();
            var newUser = new User() { ClientId = 135, SystemId = new Guid(), UserName = "Fernant" };
            var creatorServiceMock = new UserCreatorService(dbContext, mockLogger.Object);

            // Act.
            var createUser = creatorServiceMock.CreateUserAsyncService(newUser);

            // Assert
            Assert.NotNull(createUser);
            Assert.Equal(createUser.Result.UserName, "Fernant");
            Assert.Equal(createUser.Result.ClientId, 135);
        }

        [Fact]
        async public void WhenGettingUser_AndUserFound_ThenReturnTrue()
        {
            // Arrange.
            var userId = 3;
            var mockLogger = new Mock<ILogger<UserGetterSerivce>>();
            var dbContext = await GetDatabaseContext();
            var finderServiceMock = new UserGetterSerivce(dbContext, mockLogger.Object);

            // Act.
            var findUser = finderServiceMock.GetUserByIdAsyncService(userId);

            // Assert
            Assert.NotNull(findUser);
            Assert.Equal(findUser.Result.UserName, "Oleg");
        }

        [Fact]
        async public void WhenGettingUser_AndUserIsNotFound_ThrowUserNotFoundException()
        {
            // Arrange.
            var userId = 8;
            var mockLogger = new Mock<ILogger<UserGetterSerivce>>();
            var dbContext = await GetDatabaseContext();
            var finderServiceMock = new UserGetterSerivce(dbContext, mockLogger.Object);

            // Act.
            var findUser = finderServiceMock.GetUserByIdAsyncService(userId);

            // Assert
            await Assert.ThrowsAsync<UserByIdNotFoundException>(() => findUser);
        }

        [Fact]
        async public void WhenDeleteUser_AndUserFound_ThenUserShouldBeDelete()
        {
            //Arrange.
            var userId = 3;
            var mockLogger = new Mock<ILogger<UserDeleterServicie>>();
            var dbContext = await GetDatabaseContext();
            var deleterServiceMock = new UserDeleterServicie(dbContext, mockLogger.Object);

            //Act.
            var deleteUser = deleterServiceMock.DeleteUserServiceAsync(userId);
            //var user = dbContext.Users.FirstOrDefaultAsync(x => x.ClientId == userId);

            //Assert.
            Assert.NotNull(deleteUser.Result);
            Assert.Null(dbContext.Users.FirstOrDefaultAsync(x => x.ClientId == userId).Result);
        }

        [Fact]
        async public void WhenDeletingUser_AndUserIsNotFound_ThrowUserNotFoundException()
        {
            //Arrange.
            var userId = 3435;
            var mockLogger = new Mock<ILogger<UserDeleterServicie>>();
            var dbContext = await GetDatabaseContext();
            var deleterServiceMock = new UserDeleterServicie(dbContext, mockLogger.Object);

            //Act.
            var deleteUser = deleterServiceMock.DeleteUserServiceAsync(userId);
            //var user = dbContext.Users.FirstOrDefaultAsync(x => x.ClientId == userId);

            //Assert.
            await Assert.ThrowsAsync<UserByIdNotFoundException>(() => deleteUser);
        }

        [Fact]
        async public void WhenUpdateUser_AndUserFound_ThenUserUpdate()
        {
            //Arrange.
            var newUser = new User() { ClientId = 12, SystemId = new Guid(), UserName = "NewName" };
            var userId = 2;
            var mockLogger = new Mock<ILogger<UserUpdaterService>>();
            var dbContext = await GetDatabaseContext();
            var updaterServiceMock = new UserUpdaterService(dbContext, mockLogger.Object);

            //Act.
            var updateUser = updaterServiceMock.UpdateUserServiceAsync(userId, newUser);

            //Assert.
            Assert.NotNull(dbContext.Users.FirstOrDefaultAsync(x => x.ClientId == 12).Result);
            Assert.NotNull(dbContext.Users.FirstOrDefaultAsync(x => x.UserName == "NewName").Result);
            Assert.Null(dbContext.Users.FirstOrDefaultAsync(x => x.ClientId == 2).Result);
        }

        async public void WhenUpdateUser_AndUserIsNotFound_ThrowUserNotFoundException()
        {
            //Arrange.
            var newUser = new User() { ClientId = 12, SystemId = new Guid(), UserName = "NewName" };
            var userId = 7;
            var mockLogger = new Mock<ILogger<UserUpdaterService>>();
            var dbContext = await GetDatabaseContext();
            var updaterServiceMock = new UserUpdaterService(dbContext, mockLogger.Object);

            //Act.
            var updateUser = updaterServiceMock.UpdateUserServiceAsync(userId, newUser);

            //Assert.
            await Assert.ThrowsAsync<UserByIdNotFoundException>(() => updateUser);
        }

        [Fact]
        async public void WhenAddingUsers_AndUsersHaveClones_ThenReturnFalse()
        {
            // Arrange.
            var users = new User[]
            {
                new ()
                {
                    ClientId = 1,
                    SystemId = new Guid(),
                    UserName = "Alex"
                },
                new ()
                {
                    ClientId = 2,
                    SystemId = new Guid(),
                    UserName = "William"
                },

                new ()
                {
                    ClientId = 7,
                    SystemId = new Guid(),
                    UserName = "Dora"
                },
            };

            var mockLogger = new Mock<ILogger<UserFinderDublicate>>();
            var dbContext = await GetDatabaseContext();
            var findDublicateUserServiceMock = new UserFinderDublicate(dbContext, mockLogger.Object);

            // Act.
            var findDublicate = findDublicateUserServiceMock.AddNoDublicateEntitiesAsyncService(users);

            // Assert.
            Assert.Equal(findDublicate.Result.Length, 1);
        }


        public async Task<ApplicationContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ApplicationContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Users.CountAsync() <= 0)
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
            return databaseContext;
        }
    }
}