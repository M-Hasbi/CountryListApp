namespace NLayer.Core
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CountryBorder> CountryBorders { get; set; }
    }
}
