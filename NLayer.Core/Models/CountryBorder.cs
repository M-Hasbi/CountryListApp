using System.ComponentModel.DataAnnotations.Schema;

namespace NLayer.Core
{
    
    public class CountryBorder : BaseEntity
    {
        public ICollection<string> Names { get; set; } 

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
