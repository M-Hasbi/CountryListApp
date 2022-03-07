using NLayer.Core.DTOs;

namespace NLayer.Core.Services
{
    public interface ICountryBorderService : IService<CountryBorder>
    {
        Task<CustomResponseDto<List<CountryBorderWithCountryDto>>> GetCountryBordersWithCountry();


    }
}
