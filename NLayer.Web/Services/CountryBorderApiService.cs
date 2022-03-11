using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class CountryBorderApiService
    {
        private readonly HttpClient _httpClient;

        public CountryBorderApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CountryBorderWithCountryDto>> GetCountryBordersWithCountryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CountryBorderWithCountryDto>>>("countryborders/GetCountryBordersWithCountry");

            return response.Data;
        }

        public async Task<CountryBorderDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CountryBorderDto>>($"countryborders/{id}");
            return response.Data;


        }

        public async Task<CountryBorderDto> SaveAsync(CountryBorderDto newCountryBorder)
        {
            var response = await _httpClient.PostAsJsonAsync("countryborders", newCountryBorder);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CountryBorderDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(CountryBorderDto newProduct)
        {
            var response= await _httpClient.PutAsJsonAsync("countryborders", newProduct);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"countryborders/{id}");

            return response.IsSuccessStatusCode;
        }



     

    }
}
