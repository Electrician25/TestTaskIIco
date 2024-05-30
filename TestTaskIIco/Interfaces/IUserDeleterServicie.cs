using PostgreDatabase.DAL.Entities;

namespace TestTaskIIco.Interfaces
{
    public interface IUserDeleterServicie
    {
        public Task<User> DeleteUserServiceAsync(int id);
    }
}