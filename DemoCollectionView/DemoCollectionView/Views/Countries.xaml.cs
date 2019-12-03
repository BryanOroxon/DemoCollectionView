using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DemoCollectionView.ViewModels;

namespace DemoCollectionView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Countries : ContentPage
    {
        public CountryViewModel viewModel;
        public Countries()
        {
            InitializeComponent();
            BindingContext = viewModel = new CountryViewModel();
            if (viewModel.Countries.Count == 0)
            {
                viewModel.GetCountriesCommand.Execute(null);
                CollectionViewSource.ItemsSource = viewModel.Countries;
            }
        }
    }
}