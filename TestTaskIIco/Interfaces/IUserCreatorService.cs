using PostgreDatabase.DAL.Entities;

namespace TestTaskIIco.Interfaces
{
    public interface IUserCreatorService
    {
        public Task<User> CreateUserAsyncService(User newUser);
    }
}