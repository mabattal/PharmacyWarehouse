using Pharmacy.Core.DTOs;

namespace Pharmacy.Web.Services
{
    public class MedicineApiService
    {
        private readonly HttpClient _httpClient;

        public MedicineApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MedicineWithSuplierDto>> GetMedicinesWithSuplierAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<MedicineWithSuplierDto>>>("medicines/GetMedicinesWithSuplier");

            return response.Data;
        }

        public async Task<MedicineDto> SaveAsync(MedicineDto newMedicine)
        {
            var response = await _httpClient.PostAsJsonAsync("medicines", newMedicine);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<MedicineDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(MedicineDto medicine)
        {
            var response = await _httpClient.PutAsJsonAsync("medicines", medicine);

            return response.IsSuccessStatusCode;
        }

        public async Task<MedicineDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<MedicineDto>>($"medicines/{id}");

            return response.Data;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"medicines/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
