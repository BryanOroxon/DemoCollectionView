using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

using System.Linq;
using DemoCollectionView.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using MvvmHelpers;
using System.Windows.Input;

namespace DemoCollectionView.ViewModels
{
   public class CountryViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Countries> Countries { get; }
        public Command<string> GetCountriesCommand { get; }

        public CountryViewModel()
        {
            Countries = new ObservableRangeCollection<Countries>();
            GetCountriesCommand = new Command<string>(async (test) => await GetCountriesAsync(test));

            GetCountriesCommand.Execute("Hello Bryan");
        }

        async Task GetCountriesAsync(string test)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var countries = await DataService.GetCountriesAsync();

                Countries.ReplaceRange(countries);

                Title = $"Countries CollectionView ({Countries.Count})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get countries: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}