using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EventManagementSystem.App;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using EventManagementSystem.Initializers;
using EventManagementSystem.ModelBinders;
using EventManagementSystem.Services;
using EventManagementSystem.MockData;
using CloudinaryDotNet;
using dotenv.net;
using EventManagementSystem.DataAccess.Data;
using EventManagementSystem.DataAccess.Repository;
using EventManagementSystem.DataAccess.Repository.Admin;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DateOnlyModelBinderProvider()); // Custom ModelBinder
    /*options.Filters.Add<SaveRefererFilter>();*/ // Custom Filter *Failed*.
});

builder.Services.AddRazorPages(); // for identity ui
builder.Services.AddRazorComponents().AddInteractiveServerComponents(); // Add blazor server

/* ====Provide ClaimsPrincipal and Handle concurrent connection to Database issues in Blazor==== */
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddMemoryCache();
/* ====Provide ClaimsPrincipal and Handle concurrent connection to Database issues in Blazor==== */

builder.Services.AddHttpClient();
builder.Services.AddScoped<RoleInitializer>();
builder.Services.AddScoped<IAdminEventRepository, AdminEventRepository>();
builder.Services.AddScoped<IAdminTicketTypeRepository, AdminTicketTypeRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();

builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddDbContext<EventManagementSystemDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventManagementSystemDbContextConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 0;
})
    .AddDefaultUI()
    .AddEntityFrameworkStores<EventManagementSystemDbContext>();

builder.Services.AddSingleton(sp =>
{
    DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
    var cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
    cloudinary.Api.Secure = true;
    return cloudinary;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "catchall",
    pattern: "{*url}",
    defaults: new { controller = "CatchAll", action = "Index" }
    );

app.MapRazorPages(); // for identity

app.UseAntiforgery(); // blazor protect anonymous data

app.MapRazorComponents<App>().AddInteractiveServerRenderMode(); // plug-in blazor server

// ========================FOR INITIALIZE===========================

using (var scopeInitializeRole = app.Services.CreateScope()) // Calling RoleInitializer
{
    var roleInitializer = scopeInitializeRole.ServiceProvider.GetRequiredService<RoleInitializer>();
    roleInitializer.InitializeRolesAsync().Wait(); // Seeding roles
}

using (var scopeAddAdmin = app.Services.CreateScope())
{
    var adminManager = scopeAddAdmin.ServiceProvider.GetRequiredService<UserManager<User>>();
    var admin = await adminManager.FindByNameAsync("admin@eventjui.com");
    if (admin is not null)
    {
        await adminManager.RemoveFromRoleAsync(admin, nameof(UserRoles.User));
        await adminManager.AddToRoleAsync(admin, nameof(UserRoles.Admin));
    }
}

using (var scopeDbInit = app.Services.CreateScope())
{
    var context = scopeDbInit.ServiceProvider.GetRequiredService<EventManagementSystemDbContext>();
    DbInitializer.Seed(context);
}
//======================== FOR INITIALIZE ===========================

app.Run();
