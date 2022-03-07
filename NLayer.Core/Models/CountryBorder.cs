namespace NLayer.Core
{
    public class CountryBorder : BaseEntity
    {
        public List<string> Names { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
