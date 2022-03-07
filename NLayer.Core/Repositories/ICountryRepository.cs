namespace NLayer.Core.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {

        Task<Country> GetSingleCountryByIdWithCountryBordersAsync(int countryId);
    }
}
//TODO
//Product = CountryBorder
//Catagory = Country