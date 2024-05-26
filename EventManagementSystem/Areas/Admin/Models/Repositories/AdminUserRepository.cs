
namespace EventManagementSystem.Areas.Admin.Models.Repositories
{
    public class AdminUserRepository : IAdminUserRepository
    {
        public Task<int> BanUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> SuspendUser(int userId, TimeSpan timeToSuspend)
        {
            throw new NotImplementedException();
        }
    }
}
