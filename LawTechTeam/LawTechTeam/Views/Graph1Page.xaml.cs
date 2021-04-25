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
            new ChartEntry(40)
            {
                Color = SKColor.Parse(constants.colour1),
                Label = "Yes"
            },
            new ChartEntry(35)
            {
                Color = SKColor.Parse(constants.colour1),
                Label = "No"
            },
            new ChartEntry(0)
            {
                Color = SKColor.Parse(constants.blank),
                Label = "|"
            },
            new ChartEntry(15)
            {
                Color = SKColor.Parse(constants.colour2),
                Label = "Yes"
            },
            new ChartEntry(5)
            {
                Color = SKColor.Parse(constants.colour2),
                Label = "No"
            },
            new ChartEntry(0)
            {
                Color = SKColor.Parse(constants.blank),
                Label = "|"
            },
            new ChartEntry(15)
            {
                Color = SKColor.Parse(constants.colour3),
                Label = "Yes"
            },
            new ChartEntry(5)
            {
                Color = SKColor.Parse(constants.colour3),
                Label = "No"
            },
            new ChartEntry(0)
            {
                Color = SKColor.Parse(constants.blank),
                Label = "|"
            },
            new ChartEntry(15)
            {
                Color = SKColor.Parse(constants.colour4),
                Label = "Yes"
            },
            new ChartEntry(5)
            {
                Color = SKColor.Parse(constants.colour4),
                Label = "No"
            },
            new ChartEntry(0)
            {
                Color = SKColor.Parse(constants.blank),
                Label = "|"
            },
            new ChartEntry(15)
            {
                Color = SKColor.Parse(constants.colour5),
                Label = "Yes"
            },
            new ChartEntry(5)
            {
                Color = SKColor.Parse(constants.colour5),
                Label = "No"
            }
        };
        public Graph1Page()
        {
            InitializeComponent();

            graph.Chart = new BarChart
            {
                Entries = entries,
                LabelTextSize = 40,
                Margin = 20
            }; ; 
        }
    }
}