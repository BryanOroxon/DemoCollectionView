using System.Collections.Generic;
using System.Threading.Tasks;
using DemoCollectionView.Models;

namespace DemoCollectionView.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Countries>> GetCountriesAsync();
    }
}
