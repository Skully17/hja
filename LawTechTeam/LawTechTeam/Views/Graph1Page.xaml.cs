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
    public partial class Graph1Page : ContentPage
    {
        public static ChartEntry[] entries = new[]
        {
            new ChartEntry(75)
            {
                Color = SKColor.Parse(Constants.colour1),
                Label = "Yes",
                ValueLabel = "75",
                ValueLabelColor = SKColor.Parse(Constants.body_text)
            },
            new ChartEntry(250)
            {
                Color = SKColor.Parse(Constants.colour1),
                Label = "No",
                ValueLabel = "250"
            },
            new ChartEntry(0)
            {
                Color = SKColor.Parse(Constants.blank)
            },
            new ChartEntry(120)
            {
                Color = SKColor.Parse(Constants.colour2),
                Label = "Yes",
                ValueLabel = "120"
            },
            new ChartEntry(200)
            {
                Color = SKColor.Parse(Constants.colour2),
                Label = "No",
                ValueLabel = "200"
            },
            new ChartEntry(0)
            {
                Color = SKColor.Parse(Constants.blank)
            },
            new ChartEntry(90)
            {
                Color = SKColor.Parse(Constants.colour3),
                Label = "Yes",
                ValueLabel = "90"
            },
            new ChartEntry(200)
            {
                Color = SKColor.Parse(Constants.colour3),
                Label = "No",
                ValueLabel = "200"
            },
            new ChartEntry(0)
            {
                Color = SKColor.Parse(Constants.blank)
            },
            new ChartEntry(150)
            {
                Color = SKColor.Parse(Constants.colour4),
                Label = "Yes",
                ValueLabel = "150"
            },
            new ChartEntry(200)
            {
                Color = SKColor.Parse(Constants.colour4),
                Label = "No",
                ValueLabel = "200"
            },
            new ChartEntry(0)
            {
                Color = SKColor.Parse(Constants.blank)
            },
            new ChartEntry(20)
            {
                Color = SKColor.Parse(Constants.colour5),
                Label = "Yes",
                ValueLabel = "20"
            },
            new ChartEntry(50)
            {
                Color = SKColor.Parse(Constants.colour5),
                Label = "No",
                ValueLabel = "50"
            }
        };
        public Graph1Page()
        {
            InitializeComponent();

            graph.Chart = new BarChart
            {
                Entries = entries,
                LabelTextSize = 40,
                Margin = 20,
                LabelColor = SKColor.Parse(Constants.body_text)
            };
        }
    }
}