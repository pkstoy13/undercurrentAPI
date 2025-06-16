using System.Net.Http.Headers;
using System.Text.Json;
using undercurrentAPI.DTOs.Spotify;


namespace undercurrentAPI.Services
{
    public class SpotifyApiService
    {
        private readonly HttpClient _httpClient;
        private readonly SpotifyAuthService _authService;

        public SpotifyApiService(HttpClient httpClient, SpotifyAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        // Example: Search artists by name
        public async Task<SpotifySearchResponse?> SearchArtistsAsync(string artistName)
        {
            var token = await _authService.GetAccessTokenAsync();
            if (token == null) return null;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(artistName)}&type=artist&limit=10");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<SpotifySearchResponse>(content, options);
        }

        // You can add more methods to get artist details, albums, etc.
    }
}
