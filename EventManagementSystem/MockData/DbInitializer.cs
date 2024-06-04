using System.Diagnostics;
using EventManagementSystem.DataAccess.Data;
using EventManagementSystem.Models;

namespace EventManagementSystem.MockData;

public class DbInitializer
{   
    public static void Seed(EventManagementSystemDbContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        if (!context.Events.Any())
        {
            string[] categories = ["Sport", "Conferences", "Expo", "Concert", "Festival", "Art", "Community", "Holiday"];

            foreach (var categoty in categories)
            {
                var titleAndShortList = SampleEventsData.GetTitleAndShortDescription(categoty);
                var imageUrls = SampleEventsData.GetAllImgsUrlBytype(categoty);
                for (int i = 0; i < 20; i++)
                {
                    Event newEvent = new();

                    (var title, var shortDescription) = titleAndShortList[i];
                    var description = SampleEventsData.GetRandomDescription();
                    (var startDate, var endDate) = SampleEventsData.GetRandomStartEndDate();
                    var venueName = SampleEventsData.GetRandomVenueName();
                    (var lat, var lng) = SampleEventsData.GetRandomLatLng();
                    var countryName = SampleEventsData.GetRandomCountry();
                    var address = SampleEventsData.GenerateRandomAddress(countryName);
                    var imageUrl = imageUrls[i];
                    var transports = SampleEventsData.GetRandomTransport();
                    var ticketTypes = SampleEventsData.GetTicketType(newEvent);
                    var pageVisitorCount = SampleEventsData.GetPageVisitorCount();

                    if (ticketTypes?.Count == 0)
                    {
                        ticketTypes.Add(new TicketType()
                        {
                            Tickets = [],
                            Name = "Free",
                            Detail = $"Free Ticket on {title}",
                            Event = newEvent,
                            MaxCapital = 10000,
                            Price = 0
                        });
                    }

                    newEvent.Title = title;
                    newEvent.ShortDescription = shortDescription;
                    newEvent.Description = description;
                    newEvent.Create_at = DateTime.Now;
                    newEvent.StartDate = startDate;
                    newEvent.EndDate = endDate;
                    newEvent.VenueName = venueName;
                    newEvent.Latitude = lat;
                    newEvent.Longitude = lng;
                    newEvent.Country = countryName;
                    newEvent.Address = address;
                    newEvent.Image = imageUrl;
                    newEvent.Transports = transports;
                    newEvent.TicketTypes = ticketTypes;
                    newEvent.PageVisitorCount = pageVisitorCount;
                    newEvent.Category = Enum.Parse<Category>(categoty);
                    newEvent.UserId = "d7b13edd-b503-4391-89a9-38634c3a086c";                     
                    
                    context.Events.Add(newEvent);
                    context.SaveChanges();
                }
            }
        }
        stopwatch.Stop();
        Console.WriteLine();
        Console.WriteLine("Done in: " + stopwatch.ElapsedMilliseconds);
        Console.WriteLine();
    }
}
