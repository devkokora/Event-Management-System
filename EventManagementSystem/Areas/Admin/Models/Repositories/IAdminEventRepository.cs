using EventManagementSystem.Models;

namespace EventManagementSystem.Areas.Admin.Models.Repositories
{
    public interface IAdminEventRepository
    {
        public Task<int> CreateAsync(Event newEvent);
        public Task<int> EditAsync(Event editEvent);
        public Task<int> DeleteAsync(int eventId);
    }
}
