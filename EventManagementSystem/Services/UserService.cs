using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public class UserService : IUserService
    {
        public User? User { get ; set; }
        public bool IsAdmin { get ; set; }
        public bool IsLogin { get; set; }
        public bool IsInitialize { get; set; } = false;

        public void SignIn()
        {
            IsLogin = true;
        }

        public void SignOut()
        {
            User = default;
            IsAdmin = default;
            IsLogin = false;
            IsInitialize = false;
        }
    }
}
