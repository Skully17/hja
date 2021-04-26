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
                //Label = "male",
                //ValueLabel = "40",
                //ValueLabelColor = SKColor.Parse("#0000ff")
            },
            new ChartEntry(35)
            {
                Color = SKColor.Parse(Constants.colour2)
            },
            new ChartEntry(15)
            {
                Color = SKColor.Parse(Constants.colour3)
            },
            new ChartEntry(5)
            {
                Color = SKColor.Parse(Constants.colour4)
            }
        };
        public Graph2Page()
        {
            InitializeComponent();

            graph.Chart = new PieChart
            {
                Entries = entries,
                LabelTextSize = 40,
                GraphPosition = GraphPosition.AutoFill
            };
        }
    }
}