using EventManagementSystem.Models;
using EventManagementSystem.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading;

namespace EventManagementSystem.App.Layout;

public partial class NavMenu : ComponentBase
{
    [Inject]
    private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }
    [Inject]
    private UserManager<User>? UserManager { get; set; }
    [Inject]
    private IUserService UserService { get; set; }
    private User? CurrentUser { get; set; }
    private bool isAdmin = false;

    protected override async Task OnInitializedAsync()
    {
        UserService.Clear();
        if (AuthenticationStateProvider is not null && UserManager is not null)
        {
            AuthenticationState? authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            ClaimsPrincipal? UserClaims = authState.User;

            if (UserClaims.Identity!.IsAuthenticated)
            {
                CurrentUser = await UserManager.GetUserAsync(UserClaims);
                if (CurrentUser is not null)
                {
                    isAdmin = await UserManager.IsInRoleAsync(CurrentUser, nameof(UserRoles.Admin));
                }
            }
        }
        UserService.Initailize();
    }
}
