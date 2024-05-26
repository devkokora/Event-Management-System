using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace EventManagementSystem.Initializers
{
    public class RoleInitializer : IdentityRole
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleInitializer(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task InitializeRolesAsync()
        {
            await Console.Out.WriteLineAsync($"InitializeRolesAsync is call");
            foreach (var role in Enum.GetNames(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                    await Console.Out.WriteLineAsync($"Add role {role} done.");
                }
            }
        }
    }

}
