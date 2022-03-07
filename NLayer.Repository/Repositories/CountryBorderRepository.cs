using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class CountryBorderRepository : GenericRepository<CountryBorder>, ICountryBorderRepository
    {
        public CountryBorderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<CountryBorder>> GetCountryBordersWitCountry()
        {

            return await _context.CountryBorders.Include(x => x.Country).ToListAsync();
        }
    }
}
