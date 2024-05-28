namespace EventManagementSystem.Models.Initializers
{
    public class DbInitializer
    {
        public static void Seed(EventManagementSystemDbContext context)
        {

            if (!context.Events.Any())
            {
            }
        }
    }
}
