using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EventManagementSystem.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // for identity
builder.Services.AddRazorComponents().AddInteractiveServerComponents(); // Add blazor server

builder.Services.AddHttpClient();

builder.Services.AddDbContext<EventManagementSystemDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventManagementSystemDbContextConnection"));
    options.EnableSensitiveDataLogging();
});

//use one Identity
//builder.Services.AddDefaultIdentity<User> ().AddEntityFrameworkStores<EventManagementSystemDbContext>();

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

builder.Services.AddScoped<RoleInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
app.MapRazorPages(); // for identity

app.UseAntiforgery(); // blazor protect anonymous data

app.MapRazorComponents<App>().AddInteractiveServerRenderMode(); // plug-in blazor server

using (var scope = app.Services.CreateScope()) // Calling RoleInitializer
{
    var roleInitializer = scope.ServiceProvider.GetRequiredService<RoleInitializer>();
    roleInitializer.InitializeRolesAsync().Wait(); // Seeding roles
}

app.Run();
