using Microsoft.JSInterop;
using System.Text.Json;
using zEVRental.Repositories.CuongCLA.Models;

namespace zPayment.BlazorWebApp.CuongCLA.Services
{
    public class AuthenticationStateService
    {
        private const string USER_KEY = "currentUser";
        private SystemUserAccount? _currentUser;
        private readonly IJSRuntime _jsRuntime;

        public event Action? OnAuthenticationStateChanged;

        public AuthenticationStateService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> IsAuthenticated()
        {
            if (_currentUser != null)
                return true;

            try
            {
                var userJson = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", USER_KEY);
                if (!string.IsNullOrEmpty(userJson))
                {
                    _currentUser = JsonSerializer.Deserialize<SystemUserAccount>(userJson);
                    return _currentUser != null;
                }
            }
            catch
            {
                // If session storage is not available, user is not authenticated
            }

            return false;
        }

        public async Task<SystemUserAccount?> GetCurrentUser()
        {
            if (_currentUser != null)
                return _currentUser;

            try
            {
                var userJson = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", USER_KEY);
                if (!string.IsNullOrEmpty(userJson))
                {
                    _currentUser = JsonSerializer.Deserialize<SystemUserAccount>(userJson);
                }
            }
            catch
            {
                // If session storage is not available, return null
            }

            return _currentUser;
        }

        public async Task Login(SystemUserAccount user)
        {
            _currentUser = user;
            var userJson = JsonSerializer.Serialize(user);
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", USER_KEY, userJson);
            NotifyAuthenticationStateChanged();
        }

        public async Task Logout()
        {
            _currentUser = null;
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", USER_KEY);
            NotifyAuthenticationStateChanged();
        }

        private void NotifyAuthenticationStateChanged()
        {
            OnAuthenticationStateChanged?.Invoke();
        }
    }
}
