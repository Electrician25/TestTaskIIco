using PostgreDatabase.DAL.Entities;

namespace TestTaskIIco.Interfaces
{
    public interface IUserUpdaterService
    {
        public Task<User> UpdateUserServiceAsync(int id, User newUser);
    }
}