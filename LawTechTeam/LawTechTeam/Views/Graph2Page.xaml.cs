using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Microcharts;
using Xamarin.Forms;
using LawTechTeam.Models;

namespace LawTechTeam.Views
{
    public partial class Graph2Page : ContentPage
    {
        private readonly ChartEntry[] entries = new[]
        {
            new ChartEntry(40)
            {
                Color = SKColor.Parse(Constants.colour1),
                Label = "Male",
                ValueLabel = "40%",
                ValueLabelColor = SKColor.Parse(Constants.colour1)
            },
            new ChartEntry(35)
            {
                Color = SKColor.Parse(Constants.colour2),
                Label = "Female",
                ValueLabel = "35%",
                ValueLabelColor = SKColor.Parse(Constants.colour2)
            },
            new ChartEntry(15)
            {
                Color = SKColor.Parse(Constants.colour3),
                Label = "Other",
                ValueLabel = "15%",
                ValueLabelColor = SKColor.Parse(Constants.colour3)
            },
            new ChartEntry(10)
            {
                Color = SKColor.Parse(Constants.colour4),
                Label = "Prefer Not To Say",
                ValueLabel = "10%",
                ValueLabelColor = SKColor.Parse(Constants.colour4)
            }
        };
        public Graph2Page()
        {
            InitializeComponent();

            graph.Chart = new PieChart
            {
                Entries = entries,
                LabelTextSize = 40,
                LabelMode = LabelMode.RightOnly
            };
        }
    }
}