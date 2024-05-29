using EventManagementSystem.Models;

namespace EventManagementSystem.DataAccess.Repository
{
    public interface IEventRepository
    {
        Task<Event?> GetByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<int> UpdateTicketTypeAsync(Event updateEvent); // Use on test.
        Task<IEnumerable<Event>> GetAllByTypeAsync(string? typeName);
        Task<TicketType?> GetTicketTypeByIdAsync(int ticketTypeId);
        Task<IEnumerable<TicketType>> GetAllTicketTypeAsync(int eventId);
        Task<Ticket?> GetTicketByIdAsync(int eventId, int ticketTypeId, int ticketId);
        Task<IEnumerable<Ticket>> GetAllTicketAsync(int eventId, int ticketTypeId);
        Task<string?> EventInformationAsync(int eventId);
    }
}
