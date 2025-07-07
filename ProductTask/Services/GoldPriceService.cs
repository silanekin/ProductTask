using System.Text.Json;

namespace ProductTask.Services
{
    public class GoldPriceService
    {
        private readonly HttpClient _httpClient;

        public GoldPriceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> GetGoldPricePerGramAsync()
        {




            return 65.0;
        }
    }
}
