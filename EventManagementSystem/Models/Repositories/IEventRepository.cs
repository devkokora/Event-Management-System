namespace EventManagementSystem.Models.Repositories
{
    public interface IEventRepository
    {
        Task<Event?> GetByIdAsync(int eventId);
        Task<IEnumerable<Event>> GetAllAsync();
        Task<IEnumerable<Event>> GetAllByTypeAsync(string? typeName);
        Task<TicketType?> GetTicketTypeByIdAsync(int eventId, int ticketTypeId);
        Task<IEnumerable<TicketType>> GetAllTicketTypeAsync(int eventId);
        Task<Ticket?> GetTicketByIdAsync(int eventId, int ticketTypeId, int ticketId);
        Task<IEnumerable<Ticket>> GetAllTicketAsync(int eventId, int ticketTypeId);
        Task<string?> EventInformationAsync(int eventId);
    }
}
