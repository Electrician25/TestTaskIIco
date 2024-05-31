using Microsoft.AspNetCore.Mvc;
using PostgreDatabase.DAL.Entities;
using TestTaskIIco.Interfaces;

namespace TestTaskIIco.Controllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class UserController(
        IUserCreatorService userCreatorService,
        IUserDeleterServicie userDeleterServicie,
        IUserGetterSerivce userGetterSerivce,
        IUserUpdaterService userUpdaterService,
        IUserFinderDublicate userFinderDublicate) : ControllerBase
    {
        [HttpPost("Create")]
        async public Task<User> CreateUserAsync(User newUser)
        {
            return await userCreatorService.CreateUserAsyncService(newUser);
        }

        [HttpGet("Get/{id}")]
        async public Task<User> GetUserByIdAsync(int id)
        {
            return await userGetterSerivce.GetUserByIdAsyncService(id);
        }

        [HttpPut("Update/{id}")]
        async public Task<User> UpdateUserAsync(int id, User newUser)
        {
            return await userUpdaterService.UpdateUserServiceAsync(id, newUser);
        }

        [HttpDelete("Delete/{id}")]
        async public Task<User> DeleteUserAsync(int id)
        {
            return await userDeleterServicie.DeleteUserServiceAsync(id);
        }

        [HttpPost("AddNoDublicateUsers")]
        async public Task<User[]> AddNoDublicateEntitiesAsync(User[] users)
        {
            return await userFinderDublicate.AddNoDublicateEntitiesAsyncService(users);
        }
    }
}