using EventManagementSystem.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.DataAccess.Repository
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
    }
}
