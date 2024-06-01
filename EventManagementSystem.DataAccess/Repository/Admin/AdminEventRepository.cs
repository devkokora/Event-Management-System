using EventManagementSystem.DataAccess.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.DataAccess.Repository.Admin
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

        public async Task<int> DeleteAsync(int eventId)
        {
            var eventToDelete = await _eventManagementSystemDbContext.Events.FindAsync(eventId);

            if (eventToDelete is not null)
            {
                var ticketTypeInEvent = await _eventManagementSystemDbContext.TicketTypes
                    .AnyAsync(tt => tt.EventId == eventToDelete.Id);

                if (ticketTypeInEvent)
                {
                    throw new Exception("Ticket type is exist, Delete Ticket type before deleting the Event.");
                }

                _eventManagementSystemDbContext.Events.Remove(eventToDelete);
                return await _eventManagementSystemDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Event id to deleted not found.");
            }
        }

        public Task<int> EditAsync(Event editEvent)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetAllEventsCountAsync()
        {
            return await _eventManagementSystemDbContext.Events.CountAsync();
        }

        public int GetAllEventsSearchCountAsync(string searchQuery)
        {
            var lowerSearchQuery = searchQuery.ToLower();
            return _eventManagementSystemDbContext.Events
                .ToList()
                .Where(e => e.Title.ToLower().Contains(lowerSearchQuery) ||
                    e.ShortDescription.ToLower().Contains(lowerSearchQuery) ||
                    e.Description.ToLower().Contains(lowerSearchQuery) ||
                    e.Category.ToString().ToLower().Contains(lowerSearchQuery) ||
                    e.Country.ToLower().Contains(lowerSearchQuery) ||
                    e.Address.ToLower().Contains(lowerSearchQuery))
                .ToList().Count;
        }

        public async Task<IEnumerable<Event>> GetEventsSortedPagedAsync(string sortBy, int? pageNumber, int maxItem, string? searchQuery)
        {
            var events = from e in _eventManagementSystemDbContext.Events select e;

            events = sortBy switch
            {
                "name" => events.OrderBy(e => e.Title),
                "name_desc" => events.OrderByDescending(e => e.Title),
                "category" => events.OrderBy(e => e.Category),
                "category_desc" => events.OrderByDescending(e => e.Category),
                "country" => events.OrderBy(e => e.Country),
                "country_desc" => events.OrderByDescending(e => e.Country),
                "date" => events.OrderBy(e => e.StartDate),
                "date_desc" => events.OrderByDescending(e => e.StartDate),
                "id_desc" => events.OrderByDescending(e => e.Id),
                _ => events.OrderBy(e => e.Id)
            };

            pageNumber ??= 1;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                var eventsList = await events.AsNoTracking().ToListAsync();
                var lowerSearchQuery = searchQuery.ToLower();

                eventsList = eventsList.Where(e => e.Title.ToLower().Contains(lowerSearchQuery) ||
                    e.ShortDescription.ToLower().Contains(lowerSearchQuery) ||
                    e.Description.ToLower().Contains(lowerSearchQuery) ||
                    e.Category.ToString().ToLower().Contains(lowerSearchQuery) ||
                    e.Country.ToLower().Contains(lowerSearchQuery) ||
                    e.Address.ToLower().Contains(lowerSearchQuery))
                    .ToList();

                return eventsList.Skip((pageNumber.Value - 1) * maxItem).Take(maxItem).ToList();
            }
            else
            {
                events = events.Skip((pageNumber.Value - 1) * maxItem).Take(maxItem);
                return await events.AsNoTracking().ToListAsync();
            }
        }
    }
}
