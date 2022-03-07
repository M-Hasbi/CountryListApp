namespace NLayer.Core.DTOs
{
    public class CountryWithCountryBordersDto : CountryDto
    {
        public List<CountryBorderDto> CountryBorders { get; set; }
    }
}
