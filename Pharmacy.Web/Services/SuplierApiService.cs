namespace Pharmacy.Web.Services
{
    public class SuplierApiService
    {
        private readonly HttpClient _httpClient;
        public SuplierApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
