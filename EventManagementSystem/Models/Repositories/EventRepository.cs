
namespace EventManagementSystem.Models.Repositories
{
    public class EventRepository : IEventRepository
    {
        public Task<string?> EventInformation(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAllByType(string typeName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllTicket(int eventId, int ticketTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TicketType>> GetAllTicketType(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Event?> GetById(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> GetTicketById(int eventId, int ticketTypeId, int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<TicketType?> GetTicketTypeById(int eventId, int ticketTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
