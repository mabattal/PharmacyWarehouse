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
    }
}
