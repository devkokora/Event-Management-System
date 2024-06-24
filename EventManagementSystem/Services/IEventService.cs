using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public interface IEventService
    {
        IEnumerable<Event> Events { get; }
        void SetEvents();
    }
}
