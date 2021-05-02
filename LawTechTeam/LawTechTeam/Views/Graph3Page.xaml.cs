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
    public partial class Graph3Page : ContentPage
    {
        private readonly ChartEntry[] entries = new[]
        {
            new ChartEntry(20)
            {
                Color = SKColor.Parse(Constants.colour1),
                Label = "Yes",
                ValueLabel = "20%"
            },
            new ChartEntry(80)
            {
                Color = SKColor.Parse(Constants.colour1),
                Label = "No",
                ValueLabel = "80%"
            },
            new ChartEntry(0)
            {
                Color = SKColor.Parse(Constants.blank),
                Label = ""
            },
            new ChartEntry(45)
            {
                Color = SKColor.Parse(Constants.colour2),
                Label = "Yes",
                ValueLabel = "45%"
            },
            new ChartEntry(55)
            {
                Color = SKColor.Parse(Constants.colour2),
                Label = "No",
                ValueLabel = "55%"
            }
        };
        public Graph3Page()
        {
            InitializeComponent();

            graph.Chart = new BarChart
            {
                Entries = entries,
                LabelTextSize = 40,
                Margin = 20,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                MaxValue = 100,
                LabelColor = SKColor.Parse(Constants.body_text)
            };
        }
    }
}