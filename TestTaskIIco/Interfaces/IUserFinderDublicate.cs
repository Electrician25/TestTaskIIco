using PostgreDatabase.DAL.Entities;

namespace TestTaskIIco.Interfaces
{
    public interface IUserFinderDublicate
    {
        public Task<User[]> AddNoDublicateEntitiesAsyncService(User[] users);
    }
}