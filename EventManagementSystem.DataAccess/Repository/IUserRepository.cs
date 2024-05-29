using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace EventManagementSystem.DataAccess.Repository
{
    public interface IUserRepository
    {
        public Task<User?> GetByIdAsync(int userId);
        public Task<User?> GetByNameAsync(string name);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<Ticket?> GetTicketByIdAsync(int userId, int ticketId);
        public Task<IEnumerable<Ticket>> GetAllTicketAsync(int userId);
        public Task<Event?> GetEventByTicketAsync(int userId, int ticketId);
        public Task<IEnumerable<Event>> GetAllEventAsync(int userId, int ticketId, Period period = Period.Month);
        public Task<IdentityResult> ChangeDisplayNameAsync(int userId, string newDisplayName);
        public Task<IdentityResult> ChangeEmailAsync(int userId, string confirmPassword);
        public Task<IdentityResult> ChangePasswordAsync(int userId, string newPassword);
    }
}
