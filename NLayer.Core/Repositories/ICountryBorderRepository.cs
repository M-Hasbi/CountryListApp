namespace NLayer.Core.Repositories
{
    public interface ICountryBorderRepository : IGenericRepository<CountryBorder>
    {
        Task<List<CountryBorder>> GetCountryBordersWithCountry();


    }
}
