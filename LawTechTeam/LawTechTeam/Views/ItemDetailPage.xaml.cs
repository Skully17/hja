using LawTechTeam.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LawTechTeam.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}