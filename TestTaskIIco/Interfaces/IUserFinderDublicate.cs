using PostgreDatabase.DAL.Entities;

namespace TestTaskIIcoServer.Interfaces
{
    public interface IUserFinderDublicate
    {
        public Task<User[]> AddNoDublicateEntitiesAsyncService(User[] users);
    }
}