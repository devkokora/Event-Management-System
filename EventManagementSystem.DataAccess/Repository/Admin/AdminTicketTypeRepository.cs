using EventManagementSystem.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.DataAccess.Repository.Admin
{
    public class AdminTicketTypeRepository : IAdminTicketTypeRepository
    {
        private readonly EventManagementSystemDbContext _eventManagementSystemDbContext;

        public AdminTicketTypeRepository(EventManagementSystemDbContext eventManagementSystemDbContext)
        {
            _eventManagementSystemDbContext = eventManagementSystemDbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var ticketTypeToDelete = await _eventManagementSystemDbContext.TicketTypes
                .Include(tt => tt.Tickets)
                .FirstOrDefaultAsync(t => t.Id == id)
                ?? throw new ArgumentException("Tickket type id to deleted not found.");

            try
            {
                if (ticketTypeToDelete.Tickets is not null)
                {
                    _eventManagementSystemDbContext.RemoveRange(ticketTypeToDelete.Tickets);
                }

                _eventManagementSystemDbContext.Remove(ticketTypeToDelete);
                return await _eventManagementSystemDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Can't delete ticket type, {ex.Message}");
            }
        }

        public async Task<int> DeleteAllAsync(IEnumerable<int> ticketTypeIds)
        {
            var allTicketTypeToDeletes = _eventManagementSystemDbContext.TicketTypes
                .Where(tt => 
                ticketTypeIds.Any(ti => ti == tt.Id)).ToList();

            if (allTicketTypeToDeletes is not null &&
                ticketTypeIds.Count() == allTicketTypeToDeletes.Count)
            {
                foreach (var ticketType in allTicketTypeToDeletes)
                {
                    try
                    {
                        if (ticketType.Tickets is not null)
                        {
                            _eventManagementSystemDbContext.RemoveRange(ticketType.Tickets);
                        }
                        _eventManagementSystemDbContext.Remove(ticketType);                        
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Can't delete ticket type {ticketType.Id} {ticketType.Name}, {ex.Message}");
                    }
                }
                return await _eventManagementSystemDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Not all ticket type IDs to be deleted are correct. Try deleting one at a time.");
            }
        }
    }
}
