using EventManagementSystem.DataAccess.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.DataAccess.Repository;

public class TicketTypeRepository : ITicketTypeRepository
{
    private readonly EventManagementSystemDbContext _eventManagementSystemDbContext;

    public TicketTypeRepository(EventManagementSystemDbContext eventManagementSystemDbContext)
    {
        _eventManagementSystemDbContext = eventManagementSystemDbContext;
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByTickeyTypeIdAsync(int ticketTypeId)
    {
        return await _eventManagementSystemDbContext.Tickets
            .AsNoTracking()
            .Where(t => t.TicketTypeId == ticketTypeId)
            .Include(t => t.User)
            .ToListAsync();
    }

    public async Task<int> UpdateTicketTypeAsync(TicketType ticketType)
    {
        var ticketTypeToUpdate = await _eventManagementSystemDbContext.TicketTypes
            .FindAsync(ticketType.Id);
        if (ticketTypeToUpdate is not null)
        {
            ticketTypeToUpdate.Detail = ticketType.Detail;
            ticketTypeToUpdate.MaxCapital = ticketType.MaxCapital;
            ticketTypeToUpdate.Price = ticketType.Price;
            ticketTypeToUpdate.TotalTicketsSold = ticketType.TotalTicketsSold;

            _eventManagementSystemDbContext.TicketTypes.Update(ticketTypeToUpdate);
            return await _eventManagementSystemDbContext.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Ticket type not found.");
        }
    }

    public async Task<TicketType?> GetTicketTypeByIdAsync(int ticketTypeId)
    {
        return await _eventManagementSystemDbContext.TicketTypes
            .AsNoTracking()
            .Include(tt => tt.Tickets)
            .Include(tt => tt.Event)
            .FirstOrDefaultAsync(tt => tt.Id == ticketTypeId);
    }
}
