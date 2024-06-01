using EventManagementSystem.Models;

namespace EventManagementSystem.DataAccess.Repository.Admin
{
    public interface IAdminEventRepository
    {
        Task<int> CreateAsync(Event newEvent);
        Task<int> EditAsync(Event editEvent);
        Task<int> DeleteAsync(int eventId);
        Task<int> GetAllEventsCountAsync();
        int GetAllEventsSearchCountAsync(string searchQuery);
        Task<IEnumerable<Event>> GetEventsSortedPagedAsync(string sortBy, int? pageNumber, int maxItem, string? searchQuery);
    }
}
