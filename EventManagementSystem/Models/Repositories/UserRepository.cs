
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EventManagementSystem.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EventManagementSystemDbContext _eventManagementSystemDbContext;
        private readonly UserManager<User> _userManager;

        public UserRepository(EventManagementSystemDbContext eventManagementSystemDbContext, UserManager<User> userManager)
        {
            _eventManagementSystemDbContext = eventManagementSystemDbContext;
            _userManager = userManager;
        }

        public Task<IdentityResult> ChangeDisplayName(int userId, string newDisplayName)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ChangeEmail(int userId, string confirmPassword)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ChangePassword(int userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        /*public async Task<IdentityResult> Create(User user, string password)
        {
            if (user.Email is not null && user.UserName is not null)
            {
                var userWithSameEmail = await _userManager.FindByEmailAsync(user.Email);

                if (userWithSameEmail is not null)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "A user with the same email already exists." });
                }

                var userWithSameName = await _userManager.FindByNameAsync(user.UserName);

                if (userWithSameName is not null)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "A user with the same name already exists." });
                }
            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Description = "Name or email is not found." });
            }

            user.Create_at = DateTime.Now;

            var createSuccess = await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, nameof(UserRoles.User));

            if (createSuccess.Succeeded)
            {
                await _eventManagementSystemDbContext.SaveChangesAsync();
            }

            return createSuccess;
        }*/

        public async Task<IdentityResult> Edit(User user, string? newPassword = null)
        {
            var userToEdit = await _userManager.FindByIdAsync(user.Id);

            if (userToEdit is null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User to edit not found." });
            }

            userToEdit.Email = user.Email;
            userToEdit.UserName = user.Email;

            if (!string.IsNullOrEmpty(newPassword))
            {
                var pwValidator = new PasswordValidator<User>();
                var pwValidationResult = await pwValidator
                    .ValidateAsync(_userManager, userToEdit, newPassword);

                if (!pwValidationResult.Succeeded)
                {
                    return pwValidationResult;
                }
            }

            return await _userManager.UpdateAsync(userToEdit);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAllEvent(int userId, int ticketId, Period period = Period.Month)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllTicket(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByString(string strName)
        {
            throw new NotImplementedException();
        }

        public Task<Event?> GetEventByTicket(int userId, int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> GetTicketById(int userId, int ticketId)
        {
            throw new NotImplementedException();
        }
    }
}
