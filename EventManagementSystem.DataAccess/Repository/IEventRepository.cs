using EventManagementSystem.Models;
using Microsoft.Extensions.Logging;

namespace EventManagementSystem.DataAccess.Repository
{
    public interface IEventRepository
    {
        Task<Event?> GetByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<int> UpdateTicketTypeAsync(Event updateEvent); // Use on test.
        Task<int> UpdateVisitorCountAsync(int eventId);
        Task<IEnumerable<Event>> GetAllByTypeAsync(string? typeName);
        Task<TicketType?> GetTicketTypeByIdAsync(int ticketTypeId);
        Task<Ticket?> GetTicketByIdAsync(int eventId, int ticketTypeId, int ticketId);
        Task<IEnumerable<Ticket>> GetAllTicketAsync(int eventId, int ticketTypeId);
        IEnumerable<Event> SearchEventByType(string searchQuery, string? typeName, List<Event>? tempEvents);
        IEnumerable<Event> GetAllByType(string? typeName);
    }
}
