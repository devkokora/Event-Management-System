using EventManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.DataAccess.Repository
{
    public interface ITicketTypeRepository
    {
        Task<int> UpdateTicketTypeAsync(TicketType ticketType);
    }
}
