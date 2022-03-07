using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
    public interface ICountryService : IService<Country>
    {
        public Task<CustomResponseDto<CountryWithCountryBordersDto>> GetSingleCountryByIdWithCountryBordersAsync(int countryId);

    }
}
