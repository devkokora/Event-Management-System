using Microsoft.AspNetCore.Identity;

namespace EventManagementSystem.Models.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> GetById(int userId);
        public Task<User?> GetByString(string strName);
        public Task<IEnumerable<User>> GetAll();
        public Task<Ticket?> GetTicketById(int userId, int ticketId);
        public Task<IEnumerable<Ticket>> GetAllTicket(int userId);
        public Task<Event?> GetEventByTicket(int userId, int ticketId);
        public Task<IEnumerable<Event>> GetAllEvent(int userId, int ticketId, Period period = Period.Now);
        //public Task<IdentityResult> Create(User user, string password);
        public Task<IdentityResult> ChangeDisplayName(int userId, string newDisplayName);
        public Task<IdentityResult> ChangeEmail(int userId, string confirmPassword);
        public Task<IdentityResult> ChangePassword(int userId, string newPassword);
    }
}
