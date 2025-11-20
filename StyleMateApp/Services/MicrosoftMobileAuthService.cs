using Microsoft.Maui.Authentication;
using System.Net.Http.Json;

namespace StyleMateApp.Services
{
    public class MicrosoftMobileAuthService
    {
        // ============================================================
        // ⚠ SUBSTITUI ESTES 3 CAMPOS PELOS TEUS DADOS
        // ============================================================
        private const string AzureClientId = "O_TEU_CLIENT_ID_AZURE";
        private const string RedirectUri = "com.stylemate.app://auth";
        private const string BackendBaseUrl = "https://localhost:7218";
        // OU -> https://teu-api.azurewebsites.net

        private readonly HttpClient _http;

        public MicrosoftMobileAuthService(HttpClient http)
        {
            _http = http;
        }

        // ============================================================
        // LOGIN MICROSOFT VIA WEBAUTHENTICATOR (ANDROID/iOS)
        // ============================================================
        public async Task<MobileLoginResult> LoginWithMicrosoftAsync()
        {
            var authorizeUrl =
                "https://login.microsoftonline.com/common/oauth2/v2.0/authorize" +
                $"?client_id={AzureClientId}" +
                "&response_type=token%20id_token" +
                $"&redirect_uri={Uri.EscapeDataString(RedirectUri)}" +
                "&scope=openid%20email%20profile" +
                "&response_mode=fragment" +
                "&prompt=select_account";

            try
            {
                var result = await WebAuthenticator.AuthenticateAsync(
                    new Uri(authorizeUrl),
                    new Uri(RedirectUri)
                );

                result.Properties.TryGetValue("access_token", out var accessToken);
                result.Properties.TryGetValue("id_token", out var idToken);

                if (string.IsNullOrWhiteSpace(idToken))
                {
                    return new MobileLoginResult
                    {
                        Success = false,
                        Error = "id_token não devolvido pela Microsoft"
                    };
                }

                var dto = new
                {
                    IdToken = idToken,
                    AccessToken = accessToken,
                    ExternalId = ""
                };

                var response = await _http.PostAsJsonAsync($"{BackendBaseUrl}/auth/microsoft-mobile-login", dto);

                if (!response.IsSuccessStatusCode)
                {
                    var err = await response.Content.ReadAsStringAsync();
                    return new MobileLoginResult
                    {
                        Success = false,
                        Error = "Erro backend: " + err
                    };
                }

                var payload = await response.Content.ReadFromJsonAsync<MobileLoginResponse>();

                return new MobileLoginResult
                {
                    Success = true,
                    Provider = payload.provider,
                    Email = payload.email,
                    Jwt = payload.token
                };
            }
            catch (TaskCanceledException)
            {
                return new MobileLoginResult
                {
                    Success = false,
                    Error = "Login cancelado."
                };
            }
            catch (Exception ex)
            {
                return new MobileLoginResult
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }
    }

    // resposta que vem do backend
    public class MobileLoginResponse
    {
        public string provider { get; set; }
        public string email { get; set; }
        public string token { get; set; }
    }

    public class MobileLoginResult
    {
        public bool Success { get; set; }
        public string Provider { get; set; }
        public string Email { get; set; }
        public string Jwt { get; set; }
        public string Error { get; set; }
    }
}
