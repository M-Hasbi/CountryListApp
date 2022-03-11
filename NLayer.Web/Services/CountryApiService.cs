using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class CountryApiService
    {
        private readonly HttpClient _httpClient;

        public CountryApiService(HttpClient httpClient)
        {

           
            _httpClient = httpClient;
        }

        public async Task<List<CountryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CountryDto>>>("countries");
            return response.Data;
        }

    }
}
