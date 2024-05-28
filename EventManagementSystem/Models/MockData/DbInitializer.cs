using System.Composition;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using EventManagementSystem.Services;

namespace EventManagementSystem.Models.MockData;

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
                    (var title, var shortDescription) = titleAndShortList[i];
                    var description = SampleEventsData.GetRandomDescription();
                    (var startDate, var endDate) = SampleEventsData.GetRandomStartEndDate();
                    var venueName = SampleEventsData.GetRandomVenueName();
                    (var lat, var lng) = SampleEventsData.GetRandomLatLng();
                    var countryName = SampleEventsData.GetRandomCountry();
                    var address = SampleEventsData.GenerateRandomAddress(countryName);
                    var imageUrl = imageUrls[i];
                    var transports = SampleEventsData.GetRandomTransport();

                    Event newEvent = new()
                    {
                        Title = title,
                        ShortDescription = shortDescription,
                        Description = description,
                        Create_at = DateTime.Now,
                        StartDate = startDate,
                        EndDate = endDate,
                        VenueName = venueName,
                        Latitude = lat,
                        Longitude = lng,
                        Country = countryName,
                        Address = address,
                        Image = imageUrl,
                        Transports = transports,
                        Category = Enum.Parse<Category>(categoty),
                        UserId = "e05558fb-2578-4d6a-8728-88704c057ebd"                        
                    };

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
