using DemoCollectionView.Models;
using DemoCollectionView.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebDataService))]
namespace DemoCollectionView.Services
{

      public class WebDataService : IDataService
  {
      HttpClient httpClient;

      HttpClient Client => httpClient ?? (httpClient = new HttpClient());

  public async Task<IEnumerable<Countries>> GetCountriesAsync()
      {
          var json = await Client.GetStringAsync("https://raw.githubusercontent.com/BryanOroxon/CollectionViewChallenge/master/CollectionViewChallenge/CollectionViewChallenge/Data/moviedata.json");
          var all = Countries.FromJson(json);
          return all;
      }
  } 
}
