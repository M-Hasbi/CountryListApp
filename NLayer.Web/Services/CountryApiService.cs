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
            CustomResponseDto<List<CountryDto>> response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CountryDto>>>("countries");
            return response.Data;
        }
        public async Task<CountryDto> SaveAsync(CountryDto newCountry)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("countries", newCountry);

            if (!response.IsSuccessStatusCode) return null;

            CustomResponseDto<CountryDto> responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CountryDto>>();

            return responseBody.Data;


        }
    }
}
