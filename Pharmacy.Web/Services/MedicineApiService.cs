namespace Pharmacy.Web.Services
{
    public class MedicineApiService
    {
        private readonly HttpClient _httpClient;

        public MedicineApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
