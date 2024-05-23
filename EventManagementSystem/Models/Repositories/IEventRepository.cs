namespace EventManagementSystem.Models.Repositories
{
    public interface IEventRepository
    {
        public Task<Event> GetById(int eventId);
        public Task<List<Event>> GetAll();
        public Task<List<Event>> GetAllByType(string typeName);
        public Task<TicketType> GetTicketTypeById(int eventId, int ticketTypeId);
        public Task<List<TicketType>> GetAllTicketType(int eventId);
        public Task<Ticket> GetTicketById(int eventId, int ticketTypeId, int ticketId);
        public Task<List<Ticket>> GetAllTicket(int eventId, int ticketTypeId);
        public Task<string> EventInformation(int eventId);
        public Task<int> Create(Event newEvent);
        public Task<int> Edit(Event editEvent);
        public Task<int> Delete(int eventId);
    }
}
