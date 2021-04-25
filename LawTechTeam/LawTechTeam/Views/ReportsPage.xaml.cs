using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LawTechTeam.ViewModels;

namespace LawTechTeam.Views
{
    public partial class ReportsPage : ContentPage
    {
        public ReportsPage()
        {
            InitializeComponent();
            BindingContext = new ReportsViewModel();
        }
    }
}