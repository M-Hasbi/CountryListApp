namespace NLayer.Core.DTOs
{
    public class CountryBorderDto : BaseDto
    {


        public ICollection<string> Names { get; set; }

        public int CountryId { get; set; }
    }
}
