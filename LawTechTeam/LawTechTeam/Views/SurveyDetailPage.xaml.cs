﻿using LawTechTeam.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LawTechTeam.Views
{
    public partial class SurveyDetailPage : ContentPage
    {
        public SurveyDetailPage()
        {
            InitializeComponent();
            BindingContext = new SurveyDetailViewModel();
        }
    }
}