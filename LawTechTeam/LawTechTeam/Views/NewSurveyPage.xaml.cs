using LawTechTeam.Views;
using LawTechTeam.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LawTechTeam.Views
{
    public partial class NewSurveyPage : ContentPage
    {
        public Survey Survey { get; set; }

        public NewSurveyPage()
        {
            InitializeComponent();
            BindingContext = new NewSurveyViewModel();
        }
    }
}