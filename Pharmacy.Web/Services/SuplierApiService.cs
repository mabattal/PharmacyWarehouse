using Pharmacy.Core.DTOs;

namespace Pharmacy.Web.Services
{
    public class SuplierApiService
    {
        private readonly HttpClient _httpClient;
        public SuplierApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SuplierDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<SuplierDto>>>("supliers");
            return response.Data;
        }

        public async Task<SuplierDto> SaveAsync(SuplierDto newSuplier)
        {
            var response = await _httpClient.PostAsJsonAsync("supliers", newSuplier);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<SuplierDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(SuplierDto suplier)
        {
            var response = await _httpClient.PutAsJsonAsync("supliers", suplier);

            return response.IsSuccessStatusCode;
        }

        public async Task<SuplierDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<SuplierDto>>($"supliers/{id}");

            return response.Data;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"supliers/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
