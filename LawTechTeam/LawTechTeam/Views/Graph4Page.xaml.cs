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
    public partial class Graph4Page : ContentPage
    {
        private readonly ChartEntry[] entries = new[]
        {
            new ChartEntry(32)
            {
                Color = SKColor.Parse(constants.colour1),
                ValueLabel = "31.3%"
            },
            new ChartEntry(68)
            {
                Color = SKColor.Parse(constants.colour2),
                ValueLabel = "68.7%",
            }
        };
        public Graph4Page()
        {
            InitializeComponent();

            graph.Chart = new PieChart
            {
                Entries = entries,
                LabelTextSize = 40,
                LabelMode = LabelMode.None
            };
        }
    }
}