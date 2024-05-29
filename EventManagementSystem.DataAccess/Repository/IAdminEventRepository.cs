using EventManagementSystem.Models;

namespace EventManagementSystem.DataAccess.Repository
{
    public interface IAdminEventRepository
    {
        public Task<int> CreateAsync(Event newEvent);
        public Task<int> EditAsync(Event editEvent);
        public Task<int> DeleteAsync(int eventId);
    }
}
