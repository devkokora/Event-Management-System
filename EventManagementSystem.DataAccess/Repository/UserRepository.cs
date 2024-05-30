using EventManagementSystem.DataAccess.Data;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EventManagementSystem.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EventManagementSystemDbContext _eventManagementSystemDbContext;

        public UserRepository(EventManagementSystemDbContext eventManagementSystemDbContext, UserManager<User> userManager)
        {
            _eventManagementSystemDbContext = eventManagementSystemDbContext;
        }

        public Task<IdentityResult> ChangeDisplayNameAsync(int userId, string newDisplayName)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ChangeEmailAsync(int userId, string confirmPassword)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ChangePasswordAsync(int userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAllEventAsync(int userId, int ticketId, Period period = Period.Month)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllTicketAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Event?> GetEventByTicketAsync(int userId, int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> GetTicketByIdAsync(int userId, int ticketId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            var existingUser = await _eventManagementSystemDbContext.Users.FindAsync(user.Id);
            if (existingUser is not null)
            {
                existingUser.Tickets = user.Tickets;
                _eventManagementSystemDbContext.Users.Update(existingUser);
                return await _eventManagementSystemDbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }
    }
}
