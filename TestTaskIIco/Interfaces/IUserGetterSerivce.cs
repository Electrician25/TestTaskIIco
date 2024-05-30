using PostgreDatabase.DAL.Entities;

namespace TestTaskIIco.Interfaces
{
    public interface IUserGetterSerivce
    {
        public Task<User> GetUserByIdAsyncService(int id);
    }
}