using EventManagementSystem.Models;

namespace EventManagementSystem.Areas.Admin.Models.Repositories
{
    public class AdminEventRepository : IAdminEventRepository
    {
        public Task<int> Create(Event newEvent)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Edit(Event editEvent)
        {
            throw new NotImplementedException();
        }
    }
}
