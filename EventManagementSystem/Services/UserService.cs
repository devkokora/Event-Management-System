using EventManagementSystem.DataAccess.Data;
using Microsoft.AspNetCore.Http;

namespace EventManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly TaskCompletionSource<bool> taskCompletionSource = new();
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Task Initialization => taskCompletionSource.Task;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Initailize()
        {
            _httpContextAccessor.HttpContext?.Session.SetString("IsInitialize", "true");
            taskCompletionSource.SetResult(true);
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext?.Session.Clear();
        }
    }
}
