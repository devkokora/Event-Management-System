namespace EventManagementSystem.Models.Repositories
{
    public interface IEventRepository
    {
        public Task<Event?> GetById(int eventId);
        public Task<IEnumerable<Event>> GetAll();
        public Task<IEnumerable<Event>> GetAllByType(string typeName);
        public Task<TicketType?> GetTicketTypeById(int eventId, int ticketTypeId);
        public Task<IEnumerable<TicketType>> GetAllTicketType(int eventId);
        public Task<Ticket?> GetTicketById(int eventId, int ticketTypeId, int ticketId);
        public Task<IEnumerable<Ticket>> GetAllTicket(int eventId, int ticketTypeId);
        public Task<string?> EventInformation(int eventId);
    }
}
