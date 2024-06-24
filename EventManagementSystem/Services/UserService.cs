using EventManagementSystem.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace EventManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly TaskCompletionSource<bool> _taskCompletionSource = new();
        private readonly IMemoryCache _memoryCache;
        private const string Key = "InitailizeCache";
        public Task Initialization => _taskCompletionSource.Task;
        public bool IsInitialized
        {
            get
            {
                return _memoryCache.Get(Key)?.ToString() == "true";
            }
            set
            {
                _memoryCache.Set(Key, value ? "true" : "false");
                if (value)
                {
                    _taskCompletionSource.TrySetResult(true);
                }
            }
        }

        public UserService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            SetCache("false");
        }

        public void Initailize()
        {
            IsInitialized = true;
        }

        public void Clear()
        {
            IsInitialized = false;
        }

        public void SetCache(string? value)
        {
            var encodedCache = _memoryCache.Get(Key);

            if (encodedCache == null)
            {
                var options = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromMinutes(5)
                };
                _memoryCache.Set(Key, value, options);
            }
        }
    }
}
