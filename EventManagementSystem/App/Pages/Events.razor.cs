using EventManagementSystem.DataAccess.Repository;
using EventManagementSystem.Models;
using EventManagementSystem.Services;
using Microsoft.AspNetCore.Components;

namespace EventManagementSystem.App.Pages
{
    public partial class Events
    {
        [Inject]
        private IEventRepository EventRepository { get; set; } = default!;

        [Inject]
        private IUserService UserService { get; set; } = default!;

        public List<Event> OtherEvents { get; private set; } = [];
        public List<Event> UpComingEvents { get; private set; } = [];

        private int CurrentGroup_Up { get; set; } = 1;
        private int CurrentGroup_All { get; set; } = 1;

        private int TotalUpComingPages { get; set; } = default;
        private int TotalOtherPages { get; set; } = default;

        private string SearchText = "";

        [Parameter]
        public string? CategoryName { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            while (!UserService.IsInitialize)
            { 
                await Task.Delay(31); // Handle concurency better than random value Task.Delay on NavMenu.cs
            }

            CategoryName ??= string.Empty;
            OtherEvents = [.. await EventRepository.GetAllByTypeAsync(CategoryName)];

            if (OtherEvents is not null)
            {
                UpComingEvents = [.. OtherEvents.OrderBy(e => e.StartDate).Take(12)];

                OtherEvents = OtherEvents.Where(other => !UpComingEvents.Contains(other)).ToList();

                TotalOtherPages = (int)Math.Ceiling((double)OtherEvents.Count() / 4);
                TotalUpComingPages = (int)Math.Ceiling((double)UpComingEvents.Count() / 4);

                CalcWidthProcress(UpComingEvents);
            }
        }

        private int GetGroup(int index)
        {
            return index / (3 + 1) + 1;
        }

        private void ShowGroup(int group, string filter = "all")
        {
            if (filter == "upcomming")
                CurrentGroup_Up = group;
            else
                CurrentGroup_All = group;
        }

        private int CalcUpcommingDate(DateOnly dateOnly)
        {
            var days = (dateOnly.ToDateTime(new TimeOnly(0)) - DateTime.Now).Days;
            return days;
        }

        private List<int> processDays = [];
        private void CalcWidthProcress(List<Event> events)
        {
            int maxDay = 0;
            foreach (var ev in events)
            {
                var day = (ev.StartDate.ToDateTime(new TimeOnly(0)) - DateTime.Now).Days;
                if (maxDay < day)
                    maxDay = day;
                processDays.Add(day);
            }

            for (int i = 0; i < processDays.Count; i++)
            {
                processDays[i] = (int)((float)processDays[i] / maxDay * 60);
            }
        }

        private void Search()
        {
            OtherEvents.Clear();
            if (EventRepository is not null)
            {
                if (SearchText.Length >= 2)
                {
                    OtherEvents = [.. EventRepository.SearchEventByType(SearchText, CategoryName)];
                    OtherEvents = [.. OtherEvents.Where(other => !UpComingEvents.Any(ue => ue.Id == other.Id))];
                    TotalOtherPages = (int)Math.Ceiling((double)OtherEvents.Count() / 4);
                }
                else
                {
                    OtherEvents = [.. EventRepository.GetAllByType(CategoryName)];
                    OtherEvents = [.. OtherEvents.Where(other => !UpComingEvents.Any(ue => ue.Id == other.Id))];
                    TotalOtherPages = (int)Math.Ceiling((double)OtherEvents.Count() / 4);
                }
            }
        }
    }
}
