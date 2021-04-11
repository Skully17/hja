using LawTechTeam.Models;
using LawTechTeam.ViewModels;
using LawTechTeam.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LawTechTeam.Views
{
    public partial class SurveysPage : ContentPage
    {
        SurveysViewModel _viewModel;

        public SurveysPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SurveysViewModel();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SurveysListView.ItemsSource = await App.Database.GetSurveysAsync();
        }
        
    }
}