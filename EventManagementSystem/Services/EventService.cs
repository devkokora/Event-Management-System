using EventManagementSystem.App.Pages;
using EventManagementSystem.DataAccess.Repository;
using EventManagementSystem.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace EventManagementSystem.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMemoryCache _memoryCache;
        private static readonly string CacheKey = "EventsCacheKey";
        public IEnumerable<Event> Events { get; private set; }

        public EventService(IEventRepository eventRepository, IMemoryCache memoryCache)
        {
            _eventRepository = eventRepository;
            _memoryCache = memoryCache;
            InitEvents();
        }

        public void InitEvents()
        {
            if (!_memoryCache.TryGetValue(CacheKey, out IEnumerable<Event> events))
            {
                events = _eventRepository.GetAll();
                _memoryCache.Set(CacheKey, events, TimeSpan.FromDays(1));
            }
            Events = events;
        }

        public void SetEvents()
        {
            var events = _eventRepository.GetAll();
            _memoryCache.Set(CacheKey, events, TimeSpan.FromDays(1));
            Events = events;
        }
    }
}
