using Microsoft.AspNetCore.Components;
using zPayment.BlazorWebApp.CuongCLA.Services;

namespace zPayment.BlazorWebApp.CuongCLA.Components.Pages
{
    public class AuthenticatedComponentBase : ComponentBase
    {
        [Inject]
        protected AuthenticationStateService AuthService { get; set; } = default!;

        [Inject]
        protected NavigationManager Navigation { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            var isAuthenticated = await AuthService.IsAuthenticated();
            if (!isAuthenticated)
            {
                Navigation.NavigateTo("/login", forceLoad: true);
            }
            await base.OnInitializedAsync();
        }
    }
}
