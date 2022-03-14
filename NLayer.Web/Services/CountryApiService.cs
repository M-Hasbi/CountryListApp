using Newtonsoft.Json;
using NLayer.Core.DTOs;
using System.Text;

namespace NLayer.Web.Services
{
    public class CountryApiService
    {
        private readonly HttpClient _httpClient;

        public CountryApiService(HttpClient httpClient)
        {


            _httpClient = httpClient;
        }

        public async Task<CountryDto> AddAsync(CountryDto categoryDTO)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(categoryDTO), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("countries", stringContent);

            if (response.IsSuccessStatusCode)
            {
                categoryDTO = JsonConvert.DeserializeObject<CountryDto>(await response.Content.ReadAsStringAsync());
                return categoryDTO;
            }
            else
            {
                //do logg
                return null;
            }
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
        public async Task<CountryDto> GetByIdAsync(int id)
        {

            CustomResponseDto<CountryDto> response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CountryDto>>($"countries/{id}");
            return response.Data;


        }
        public async Task<bool> UpdateAsync(CountryDto newCountry)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("countries", newCountry);

            return response.IsSuccessStatusCode;


        }
        public async Task<bool> RemoveAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"countries/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
