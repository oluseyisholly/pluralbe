using EcommerceWebApi.Common.Model;
using Microsoft.Extensions.Options;

namespace EcommerceWebApi.Service
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;
        private readonly PaymentApiSettings _settings;

        public HttpService(HttpClient httpClient, IOptions<PaymentApiSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;

            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_settings.ApiKey}");
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            return await _httpClient.GetAsync(path);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string path, T data)
        {
            return await _httpClient.PostAsJsonAsync(path, data);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string path, T data)
        {
            return await _httpClient.PutAsJsonAsync(path, data);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string path)
        {
            return await _httpClient.DeleteAsync(path);
        }
    }
}
