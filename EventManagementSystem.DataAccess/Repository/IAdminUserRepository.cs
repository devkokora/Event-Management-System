namespace EventManagementSystem.DataAccess.Repository
{
    public interface IAdminUserRepository
    {
        public Task<int> SuspendUser(int userId, TimeSpan timeToSuspend);
        public Task<int> BanUser(int userId);
    }
}
