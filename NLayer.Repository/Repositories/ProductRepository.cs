using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<CountryBorder>, ICountryBorderRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<CountryBorder>> GetProductsWitCategory()
        {

            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
