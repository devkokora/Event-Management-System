
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EventManagementSystem.Models.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventManagementSystemDbContext _eventManagementSystemDbContext;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public EventRepository(EventManagementSystemDbContext eventManagementSystemDbContext)
        {
            _eventManagementSystemDbContext = eventManagementSystemDbContext;
        }

        public async Task<Event?> GetByIdAsync(int eventId)
        {
            return await _eventManagementSystemDbContext.Events.FindAsync(eventId);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _eventManagementSystemDbContext.Events
                .OrderBy(e => e.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetAllByTypeAsync(string? typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                return await GetAllAsync();

            return await _eventManagementSystemDbContext.Events
                .Where(e => nameof(e.Category).Equals(typeName, StringComparison.CurrentCultureIgnoreCase))
                .AsNoTracking()
                .ToListAsync();
        }


        public Task<IEnumerable<Ticket>> GetAllTicketAsync(int eventId, int ticketTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TicketType>> GetAllTicketTypeAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> GetTicketByIdAsync(int eventId, int ticketTypeId, int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<TicketType?> GetTicketTypeByIdAsync(int eventId, int ticketTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<string?> EventInformationAsync(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
