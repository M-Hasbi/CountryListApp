﻿using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CountryBorderWithCountryDto>> GetProductsWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CountryBorderWithCountryDto>>>("products/GetProductsWithCategory");

            return response.Data;
        }

        public async Task<CountryBorderDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CountryBorderDto>>($"products/{id}");
            return response.Data;


        }

        public async Task<CountryBorderDto> SaveAsync(CountryBorderDto newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("products", newProduct);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CountryBorderDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(CountryBorderDto newProduct)
        {
            var response= await _httpClient.PutAsJsonAsync("products", newProduct);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");

            return response.IsSuccessStatusCode;
        }



     

    }
}