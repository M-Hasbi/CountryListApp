namespace NLayer.Core.DTOs
{
    public class CountryBorderUpdateDto
    {
        public int Id { get; set; }
        public List<string> Names { get; set; }
        public int CountryId { get; set; }
    }
}
