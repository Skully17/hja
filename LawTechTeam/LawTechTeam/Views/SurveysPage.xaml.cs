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
using SQLite;

namespace LawTechTeam.Views
{

    public partial class SurveysPage : ContentPage
    {
        SurveysViewModel _viewModel;
        //readonly SQLiteAsyncConnection database; NO LONGER NEEDED
        public SurveysPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SurveysViewModel();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var Surveys = await App.Database.GetSurveysAsync_ID_Desc();
            SurveysListView.ItemsSource = await App.Database.GetSurveysAsync_ID_Desc();
        }

        private async void CaseIDButton_Clicked(object sender, EventArgs e)
        {
            if (CaseIDButton.Text == "Case ID ▼")
            {
                CaseIDButton.Text = "Case ID ▲";
                var Surveys = await App.Database.GetSurveysAsync_ID_Asc();
                SurveysListView.ItemsSource = await App.Database.GetSurveysAsync_ID_Asc();
            }
            else
            {
                CaseIDButton.Text = "Case ID ▼";
                PoliceStationButton.Text = "Police Station";
                DateButton.Text = "Date";
                var Surveys = await App.Database.GetSurveysAsync_ID_Desc();
                SurveysListView.ItemsSource = await App.Database.GetSurveysAsync_ID_Desc();
            }
        }

        private async void PoliceStationButton_Clicked(object sender, EventArgs e)
        {
            if (PoliceStationButton.Text == "Police Station ▼")
            {
                PoliceStationButton.Text = "Police Station ▲";
                var Surveys = await App.Database.GetSurveysAsync_Station_Asc();
                SurveysListView.ItemsSource = await App.Database.GetSurveysAsync_Station_Asc();
            }
            else
            {
                PoliceStationButton.Text = "Police Station ▼";
                CaseIDButton.Text = "Case ID";
                DateButton.Text = "Date";
                var Surveys = await App.Database.GetSurveysAsync_Station_Desc();
                SurveysListView.ItemsSource = await App.Database.GetSurveysAsync_Station_Desc();
            }
        }

        private async void DateButton_Clicked(object sender, EventArgs e)
        {
            if (DateButton.Text == "Date ▼")
            {
                DateButton.Text = "Date ▲";
                var Surveys = await App.Database.GetSurveysAsync_Date_Asc();
                SurveysListView.ItemsSource = await App.Database.GetSurveysAsync_Date_Asc();
            }
            else
            {
                DateButton.Text = "Date ▼";
                CaseIDButton.Text = "Case ID";
                PoliceStationButton.Text = "Police Station";
                var Surveys = await App.Database.GetSurveysAsync_Date_Desc();
                SurveysListView.ItemsSource = await App.Database.GetSurveysAsync_Date_Desc();
            }
        }

        private async void SurveySearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Surveys = await App.Database.GetSurveysAsync_Search(SurveySearch.Text.ToLower());
            SurveysListView.ItemsSource = await App.Database.GetSurveysAsync_Search(SurveySearch.Text.ToLower());
        }
    }
}