using EventManagementSystem.Models;

namespace EventManagementSystem.Areas.Admin.Models.Repositories
{
    public interface IAdminEventRepository
    {
        public Task<int> Create(Event newEvent);
        public Task<int> Edit(Event editEvent);
        public Task<int> Delete(int eventId);
    }
}
