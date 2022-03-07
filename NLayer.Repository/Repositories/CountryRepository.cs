using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Country> GetSingleCountryByIdWithCountryBordersAsync(int countryId)
        {
            return await _context.Countries.Include(x => x.CountryBorders).Where(x => x.Id == countryId).SingleOrDefaultAsync();
        }
    }
}
