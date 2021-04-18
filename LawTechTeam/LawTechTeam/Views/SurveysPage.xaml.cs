using LawTechTeam.ViewModels;
using LawTechTeam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LawTechTeam.Models
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

        private void CaseIDButton_Clicked(object sender, EventArgs e)
        {
            if (CaseIDButton.Text == "Case ID ▲")
            {
                CaseIDButton.Text = "Case ID ▼";
            }
            else
            {
                CaseIDButton.Text = "Case ID ▲";
                PoliceStationButton.Text = "Police Station";
                DateButton.Text = "Date";
            }
        }

        private void PoliceStationButton_Clicked(object sender, EventArgs e)
        {
            if (PoliceStationButton.Text == "Police Station ▲")
            {
                PoliceStationButton.Text = "Police Station ▼";
            }
            else
            {
                PoliceStationButton.Text = "Police Station ▲";
                CaseIDButton.Text = "Case ID";
                DateButton.Text = "Date";
            }
        }

        private void DateButton_Clicked(object sender, EventArgs e)
        {
            if (DateButton.Text == "Date ▲")
            {
                DateButton.Text = "Date ▼";
            }
            else
            {
                DateButton.Text = "Date ▲";
                CaseIDButton.Text = "Case ID";
                PoliceStationButton.Text = "Police Station";
            }
        }

    }
}