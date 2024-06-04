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

        public bool IsInitialized
        {
            get
            {
                string key = "InitailizeCache";
                return _memoryCache.Get(key).ToString() == "true";
            }
            set
            {
                var key = "InitailizeCache";
                if (!string.IsNullOrEmpty(key))
                {
                    _memoryCache.Set(key, value ? "true" : "false");
                    if (value)
                    {
                        _taskCompletionSource.TrySetResult(true);
                    }
                }
            }
        }

        public Task Initialization => _taskCompletionSource.Task;

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
            string key = "InitailizeCache";
            var encodedCache = _memoryCache.Get(key);

            if (encodedCache == null)
            {
                var options = new MemoryCacheEntryOptions();
                _memoryCache.Set(key, value);
            }
        }
    }
}
