using EventManagementSystem.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EventManagementSystem.App.Layout;

public partial class NavMenu : ComponentBase
{
    [Inject]
    private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }
    [Inject]
    private UserManager<User>? UserManager { get; set; }

    private User? UserLogin { get; set; }
    private bool isAdmin = false;

    protected override async Task OnInitializedAsync()
    {
        if (AuthenticationStateProvider is not null && UserManager is not null)
        {
            AuthenticationState? authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            ClaimsPrincipal? UserClaims = authState.User;

            if (UserClaims.Identity!.IsAuthenticated)
            {
                UserLogin = await UserManager.GetUserAsync(UserClaims);
                if (UserLogin is not null)
                    isAdmin = await UserManager.IsInRoleAsync(UserLogin, nameof(UserRoles.Admin));
            }
        }
    }
}
