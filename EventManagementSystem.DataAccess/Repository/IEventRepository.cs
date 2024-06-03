using EventManagementSystem.Models;
using Microsoft.Extensions.Logging;

namespace EventManagementSystem.DataAccess.Repository
{
    public interface IEventRepository
    {
        Task<Event?> GetByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<IEnumerable<Event>> GetAllByTypeAsync(string? typeName);
        Task<int> UpdateTicketTypeAsync(Event updateEvent); // Use on test.
        Task<int> UpdateVisitorCountAsync(int eventId);
        IEnumerable<Event> SearchEventByType(string searchQuery, string? typeName, List<Event>? tempEvents);
        IEnumerable<Event> GetAllByType(string? typeName);
    }
}
