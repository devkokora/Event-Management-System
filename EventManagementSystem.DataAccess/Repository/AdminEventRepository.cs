using EventManagementSystem.DataAccess.Data;
using EventManagementSystem.Models;

namespace EventManagementSystem.DataAccess.Repository
{
    public class AdminEventRepository : IAdminEventRepository
    {
        private readonly EventManagementSystemDbContext _eventManagementSystemDbContext;

        public AdminEventRepository(EventManagementSystemDbContext eventManagementSystemDbContext)
        {
            _eventManagementSystemDbContext = eventManagementSystemDbContext;
        }

        public async Task<int> CreateAsync(Event newEvent)
        {
            await _eventManagementSystemDbContext.Events.AddAsync(newEvent);
            return await _eventManagementSystemDbContext.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditAsync(Event editEvent)
        {
            throw new NotImplementedException();
        }
    }
}
